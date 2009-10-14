using System.Collections.Generic;
using System.Data;

namespace gorilla.migrations.data
{
    public class SqlDatabaseCommand : DatabaseCommand
    {
        readonly IDbConnection connection;

        public SqlDatabaseCommand(IDbConnection connection)
        {
            this.connection = connection;
			this.connection.Open();
        }

        public IEnumerable<DataRow> run(string sql)
        {
            var table = new DataTable();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                table.Load( command.ExecuteReader());
            }
            foreach (DataRow row in table.Rows)
            {
                yield return row;
            }
        }

        public void run(SqlFile sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql.raw_sql();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
