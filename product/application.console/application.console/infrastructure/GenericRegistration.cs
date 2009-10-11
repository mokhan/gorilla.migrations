using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace gorilla.migrations.console.infrastructure
{
    public class GenericRegistration<Implementation> : ComponentFactory
    {
        Func<Implementation> factory;
        ICollection<Type> contracts = new HashSet<Type>();
        Scope contract_scope = new Factory();

        public GenericRegistration(Expression<Func<Implementation>> factory)
        {
            this.factory = factory.Compile();
            as_an<Implementation>();
        }

        public void scoped_as<Scope>() where Scope : infrastructure.Scope, new()
        {
            contract_scope = new Scope();
        }

        public ComponentRegistration as_an<Contract>()
        {
            contracts.Add(typeof (Contract));
            return this;
        }

        public bool is_for<Contract>()
        {
            return is_for(typeof (Contract));
        }

        public bool is_for(Type type)
        {
            return contracts.Any(x => x.Equals(type));
        }

        public object build()
        {
            return contract_scope.apply_to(() => factory());
        }
    }
}