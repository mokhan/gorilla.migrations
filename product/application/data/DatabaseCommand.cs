using System;
using System.Collections.Generic;
using System.Data;

namespace gorilla.migrations.data
{
    public interface DatabaseCommand : IDisposable
    {
        IEnumerable<DataRow> run(string sql);
        void run(SqlFile sql);
    }
}