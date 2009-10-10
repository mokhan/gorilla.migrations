namespace gorilla.migrations.data
{
    public interface DatabaseGateway
    {
        void run(SqlFile file);
    }
}