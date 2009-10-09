namespace simple.migrations
{
    public static class StringExtensions
    {
        public static string format_using(this string formatted_string, params object[] arguments)
        {
            return string.Format(formatted_string, arguments);
        }
    }
}