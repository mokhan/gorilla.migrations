namespace gorilla.migrations.console.infrastructure
{
    public interface ComponentFactory : ComponentRegistration
    {
        bool is_for<T>();
        object build();
    }
}