namespace simple.migrations
{
    public class ConsoleArguments
    {
        readonly string[] arguments;

        ConsoleArguments(string[] arguments)
        {
            this.arguments = arguments;
        }

        public static implicit operator ConsoleArguments(string[] arguments)
        {
            return new ConsoleArguments(arguments);
        }

        public static implicit operator string[](ConsoleArguments arguments)
        {
            return arguments.arguments;
        }

        public bool contains(string key)
        {
            return arguments[0].Contains(key);
        }
    }
}