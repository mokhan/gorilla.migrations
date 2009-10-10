namespace gorilla.migrations
{
    public interface CommandRegistry
    {
        ParameterizedCommand<ConsoleArguments> command_for(ConsoleArguments arguments);
        void register(ConsoleCommand command);
    }
}