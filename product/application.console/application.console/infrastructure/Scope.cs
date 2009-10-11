using System;

namespace gorilla.migrations.console.infrastructure
{
    public interface Scope
    {
        T apply_to<T>(Func<T> factory);
    }
}