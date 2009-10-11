using System;

namespace gorilla.migrations.console.infrastructure
{
    public class FactoryScope : Scope
    {
        public object apply_to(Func<object> factory)
        {
            return factory();
        }
    }
}