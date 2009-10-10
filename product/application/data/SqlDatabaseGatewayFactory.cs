using System.Data.Common;

namespace gorilla.migrations.data
{
    public class SqlDatabaseGatewayFactory : DatabaseGatewayFactory
    {
        public DatabaseGateway gateway_to(string connection_string, string database_provider)
        {
            return new SqlDatabaseGateway(new SqlDatabaseCommandFactory(DbProviderFactories.GetFactory(database_provider), connection_string));
        }
    }
}