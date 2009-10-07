using System;

namespace simple.migrations
{
    public class ConsoleArguments
    {
        string[] arguments;

        public static implicit operator ConsoleArguments(string[] arguments)
        {
            return new ConsoleArguments {arguments = arguments};
        }

        public static implicit operator string[](ConsoleArguments arguments)
        {
            return arguments.arguments;
        }

        public virtual bool contains(string key)
        {
            return arguments[0].Contains(key);
        }

        public virtual string parse_for(string argument_name)
        {
            throw new NotImplementedException();
        }
    }
}