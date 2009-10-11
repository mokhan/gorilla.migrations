using gorilla.migrations.console.infrastructure;

namespace gorilla.migrations.console
{
    class RegisterConsoleCommands : Command
    {
        public void run()
        {
            ComponentRegistry.get_a<CommandRegistry>().register(ComponentRegistry.get_a<RunMigrationsCommand>());
        }
    }
}