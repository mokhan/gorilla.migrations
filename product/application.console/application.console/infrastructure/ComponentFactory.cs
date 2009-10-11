using System;

namespace gorilla.migrations.console.infrastructure
{
    public interface ComponentFactory : ComponentRegistration
    {
        bool is_for<T>();
        bool is_for(Type type);
        object build();
    }
}