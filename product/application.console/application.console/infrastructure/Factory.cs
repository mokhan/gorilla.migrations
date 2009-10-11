using System;

namespace gorilla.migrations.console.infrastructure
{
    public class Factory : Scope
    {
        public T apply_to<T>(Func<T> factory)
        {
            return factory();
        }
    }
}