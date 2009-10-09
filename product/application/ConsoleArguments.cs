using System.Text.RegularExpressions;

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
            return
                new Regex(@"^-{0}:\'[A-Za-z0-9\]\'$".format_using(argument_name), RegexOptions.Singleline)
                .Match( arguments[0]).Value;
        }

        public bool Equals(ConsoleArguments other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.arguments, arguments);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ConsoleArguments)) return false;
            return Equals((ConsoleArguments) obj);
        }

        public override int GetHashCode()
        {
            return (arguments != null ? arguments.GetHashCode() : 0);
        }
    }
}