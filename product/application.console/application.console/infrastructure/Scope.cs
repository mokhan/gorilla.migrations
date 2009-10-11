using System;

namespace gorilla.migrations.console.infrastructure
{
    public interface Scope
    {
        object apply_to(Func<object> factory);
    }
}