namespace gorilla.migrations.console.infrastructure
{
    public interface Registration
    {
        void scope<T>() where T : Scope, new();
        Registration As<T>();
    }

    public interface Reg : Registration
    {
        bool is_for<T>();
        object build();
    }
}