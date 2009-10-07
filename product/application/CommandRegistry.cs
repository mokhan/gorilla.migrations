namespace simple.migrations
{
    public interface CommandRegistry
    {
        ParameterizedCommand<ConsoleArguments> command_for(string[] arguments);
        void register(ConsoleCommand command);
    }
}