using gorilla.migrations.console.infrastructure;
using gorilla.migrations.utility;

namespace gorilla.migrations.console
{
    class Program
    {
        static void Main(string[] args)
        {
            new WireUpContainer()
                .then(new RegisterConsoleCommands())
                .run();

            ComponentRegistry.get_a<Console>().run_against(args);
        }
    }
}