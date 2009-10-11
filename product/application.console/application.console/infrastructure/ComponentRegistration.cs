namespace gorilla.migrations.console.infrastructure
{
    public interface ComponentRegistration
    {
        void scope<T>() where T : Scope, new();
        ComponentRegistration As<T>();
    }
}