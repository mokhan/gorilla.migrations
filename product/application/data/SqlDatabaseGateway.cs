using System.Data;
using System.Linq;
using simple.migrations.utility;

namespace simple.migrations.Data
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
                if (command.run("select * from migration_scripts")
                    .Rows
                    .Cast<DataRow>()
                    .Any(x => !file.is_greater_than(x["version"].convert_to<int>()))) return;

                command.run(file);
            }
        }
    }
}