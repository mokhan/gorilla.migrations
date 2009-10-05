namespace simple.migrations
{
    public class ConsoleApplication : Console
    {
        readonly CommandRegistry registry;

        public ConsoleApplication(CommandRegistry registry)
        {
            this.registry = registry;
        }

        public void run_against(string[] arguments)
        {
            registry.command_for(arguments).run_against(arguments);
        }
    }
}