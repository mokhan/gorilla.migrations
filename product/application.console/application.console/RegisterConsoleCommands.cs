using gorilla.migrations.console.infrastructure;

namespace gorilla.migrations.console
{
    class RegisterConsoleCommands : Command
    {
        public void run()
        {
            Ioc.get_a<CommandRegistry>().register(Ioc.get_a<RunMigrationsCommand>());
        }
    }
}