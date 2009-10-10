using System.Text.RegularExpressions;

namespace gorilla.migrations
{
    public class ConsoleArguments
    {
        public string[] arguments { get; set; }

        static public implicit operator ConsoleArguments(string[] arguments)
        {
            return new ConsoleArguments {arguments = arguments};
        }

        static public implicit operator string[](ConsoleArguments arguments)
        {
            return arguments.arguments;
        }

        public virtual bool contains(string key)
        {
            return find_match_for(key).Success;
        }

        public virtual string parse_for(string argument_name)
        {
            var match = find_match_for(argument_name);
            return value_from(argument_name, match);
        }

        string value_from(string argument_name, Capture match)
        {
            var replace = match.Value.Replace("-{0}:'".format_using(argument_name), "");
            return replace.Remove(replace.Length - 1, 1);
        }

        Match find_match_for(string argument_name)
        {
            var pattern = @"-{0}:'.+?'".format_using(argument_name);
            var argument = arguments[0];
            return new Regex(pattern, RegexOptions.Singleline).Match(argument);
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