namespace gorilla.migrations.data
{
    public interface DatabaseGatewayFactory
    {
        DatabaseGateway gateway_to(string connection_string, string database_provider);
    }
}