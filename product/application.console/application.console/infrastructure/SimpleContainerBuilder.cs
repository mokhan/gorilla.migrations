using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace gorilla.migrations.console.infrastructure
{
    public class SimpleContainerBuilder
    {
        IList<Reg> registered_items = new List<Reg>();

        public Registration register<T>(Expression<Func<T>> factory)
        {
            var registration = new GenericRegistration<T>(factory);
            registered_items.Add(registration);
            return registration;
        }

        public Container build()
        {
            return new SimpleContainer(registered_items);
        }
    }
}