namespace gorilla.migrations.console.infrastructure
{
    public interface ComponentRegistration
    {
        void scoped_as<T>() where T : Scope, new();
        ComponentRegistration as_an<Contract>();
    }
}