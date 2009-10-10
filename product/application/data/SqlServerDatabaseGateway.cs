using System;
using System.Data;
using System.Globalization;

namespace simple.migrations.Data
{
    public class SqlServerDatabaseGateway : DatabaseGateway
    {
        DatabaseCommandFactory command_factory;

        public SqlServerDatabaseGateway(DatabaseCommandFactory command_factory)
        {
            this.command_factory = command_factory;
        }

        public void run(SqlFile file)
        {
            using (var command = command_factory.create())
            {
                foreach (DataRow row in command.run("select * from migration_scripts").Rows)
                {
                    var version = (int) Convert.ChangeType(row["version"], typeof (int), CultureInfo.InvariantCulture);
                    if (!file.is_greater_than(version)) return;

                    command.run(file);
                }
            }
        }
    }
}