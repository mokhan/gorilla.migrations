namespace simple.migrations
{
    public interface ConsoleCommand : ParameterizedCommand<string[]>
    {
        bool can_handle(string[] arguments);
    }
}