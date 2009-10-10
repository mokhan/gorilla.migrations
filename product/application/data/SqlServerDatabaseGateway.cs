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
                command.run(file);
            }
        }
    }
}