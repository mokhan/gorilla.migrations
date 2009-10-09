using System.Collections.Generic;
using simple.migrations.Data;

namespace simple.migrations.io
{
    public interface FileSystem
    {
        IEnumerable<SqlFile> all_sql_files_from(string directory);
    }
}