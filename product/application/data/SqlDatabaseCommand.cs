using System;
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
        }

        public IEnumerable<DataRow> run(string sql)
        {
            throw new NotImplementedException();
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