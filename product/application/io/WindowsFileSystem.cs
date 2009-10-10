using System.Collections.Generic;
using System.IO;
using gorilla.migrations.data;

namespace gorilla.migrations.io
{
    public class WindowsFileSystem : FileSystem
    {
        public IEnumerable<SqlFile> all_sql_files_from(string directory)
        {
            foreach (var file in Directory.GetFiles(directory, "*.sql", SearchOption.AllDirectories))
                yield return Path.Combine(directory, file);
        }
    }
}