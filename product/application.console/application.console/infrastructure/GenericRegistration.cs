using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace gorilla.migrations.console.infrastructure
{
    public class GenericRegistration<Implementation> : Reg
    {
        Func<Implementation> factory;
        ICollection<Type> contracts = new HashSet<Type>();
        Scope contract_scope;

        public GenericRegistration(Expression<Func<Implementation>> factory)
        {
            this.factory = factory.Compile();
        }

        void scope(Scope scope)
        {
            contract_scope = scope;
        }

        public void scope<Scope>() where Scope : infrastructure.Scope, new()
        {
            scope(new Scope());
        }

        public Registration As<Contract>()
        {
            contracts.Add(typeof (Contract));
            return this;
        }

        public bool is_for<Contract>()
        {
            var type = typeof (Contract);
            return type.Equals(typeof (Implementation)) || contracts.Any(x => x.Equals(type));
        }

        public object build()
        {
            return contract_scope.apply_to(() => factory());
        }
    }
}