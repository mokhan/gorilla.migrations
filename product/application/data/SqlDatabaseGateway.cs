using System.Linq;
using gorilla.migrations.utility;

namespace gorilla.migrations.data
{
    public class SqlDatabaseGateway : DatabaseGateway
    {
        DatabaseCommandFactory command_factory;

        public SqlDatabaseGateway(DatabaseCommandFactory command_factory)
        {
            this.command_factory = command_factory;
        }

        public void run(SqlFile file)
        {
            using (var command = command_factory.create())
            {
                if (command.run("select * from migration_scripts").Any(x => !file.is_greater_than(x["version"].convert_to<int>()))) return;

                command.run(file);
            }
        }
    }
}