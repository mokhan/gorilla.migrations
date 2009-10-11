using System.Collections.Generic;

namespace gorilla.migrations.console.infrastructure
{
    public interface Container
    {
        T get_a<T>();
        IEnumerable<T> get_all<T>();
    }
}