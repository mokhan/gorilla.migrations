using System.Collections.Generic;
using gorilla.migrations.data;

namespace gorilla.migrations.io
{
    public interface FileSystem
    {
        IEnumerable<SqlFile> all_sql_files_from(string directory);
    }
}