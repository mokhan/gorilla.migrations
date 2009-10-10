using System;
using System.Collections.Generic;
using System.Data;

namespace simple.migrations.Data
{
    public interface DatabaseCommand : IDisposable
    {
        IEnumerable<DataRow> run(string sql);
        void run(SqlFile sql);
    }
}