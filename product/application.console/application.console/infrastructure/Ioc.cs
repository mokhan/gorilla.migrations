namespace gorilla.migrations.console.infrastructure
{
    static public class Ioc
    {
        static Container underlying_container;

        static public T get_a<T>()
        {
            return underlying_container.get_a<T>();
        }

        static public void initialize_with(Container container)
        {
            underlying_container = container;
        }
    }
}