namespace simple.migrations.Data
{
    public interface DatabaseGateway
    {
        void run(SqlFile file);
    }
}