using gorilla.migrations.data;
using gorilla.migrations.io;
using gorilla.migrations.utility;

namespace gorilla.migrations
{
    public class RunMigrationsCommand : ConsoleCommand
    {
        FileSystem file_system;
        DatabaseGatewayFactory gateway_factory;

        public RunMigrationsCommand(FileSystem file_system, DatabaseGatewayFactory gateway_factory)
        {
            this.file_system = file_system;
            this.gateway_factory = gateway_factory;
        }

        public void run_against(ConsoleArguments arguments)
        {
            System.Console.Out.WriteLine("Running migrations...");
            var gateway = gateway_factory.gateway_to(arguments.parse_for("connection_string"), arguments.parse_for("data_provider"));
            file_system
                .all_sql_files_from(arguments.parse_for("migrations_dir"))
                .each(x => gateway.run(x));
        }

        public bool can_handle(ConsoleArguments arguments)
        {
            return arguments.contains("migrations_dir")
                   && arguments.contains("connection_string")
                   && arguments.contains("data_provider");
        }
    }
}