using System;

namespace simple.migrations
{
    public class RunMigrationsCommand : ConsoleCommand
    {
        public void run_against(ConsoleArguments arguments)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(ConsoleArguments arguments)
        {
            return arguments.contains("migrations_dir")
                   && arguments.contains("connection_string")
                   && arguments.contains("data_provider");
        }
    }
}