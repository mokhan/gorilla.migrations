using System;

namespace gorilla.migrations.console.infrastructure
{
    public class Factory : Scope
    {
        public object apply_to(Func<object> factory)
        {
            return factory();
        }
    }
}