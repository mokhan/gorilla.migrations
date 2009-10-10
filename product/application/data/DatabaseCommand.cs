using System;
using System.Data;

namespace simple.migrations.Data
{
    public interface DatabaseCommand : IDisposable
    {
        DataTable run(string sql);
        void run(SqlFile sql);
    }
}