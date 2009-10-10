using System.Data.Common;

namespace simple.migrations.Data
{
    public class SqlDatabaseCommandFactory : DatabaseCommandFactory
    {
        readonly DbProviderFactory factory;
        readonly string connection_string;

        public SqlDatabaseCommandFactory(DbProviderFactory factory, string connection_string)
        {
            this.factory = factory;
            this.connection_string = connection_string;
        }

        public DatabaseCommand create()
        {
            var connection = factory.CreateConnection();
            connection.ConnectionString = connection_string;
            return new SqlDatabaseCommand(connection);
        }
    }
}