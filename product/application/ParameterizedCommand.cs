namespace gorilla.migrations
{
    public interface ParameterizedCommand<T>
    {
        void run_against(T item);
    }
}