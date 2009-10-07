namespace simple.migrations
{
    public interface ConsoleCommand : ParameterizedCommand<ConsoleArguments>
    {
        bool can_handle(ConsoleArguments arguments);
    }
}