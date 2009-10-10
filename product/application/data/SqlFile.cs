using System;
using System.IO;
using simple.migrations.utility;

namespace simple.migrations.Data
{
    public class SqlFile : IEquatable<SqlFile>, IComparable<SqlFile>
    {
        public virtual string path { get; set; }

        public virtual bool is_greater_than(int version)
        {
            return this.version() > version;
        }

        int version()
        {
            return version_number(file_name()).convert_to<int>();
        }

        string version_number(string name)
        {
            return name.Substring(0, name.IndexOf("_"));
        }

        string file_name()
        {
            return new FileInfo(path).Name;
        }

        public virtual int CompareTo(SqlFile other)
        {
            return version().CompareTo(other.version());
        }

        public virtual string raw_sql()
        {
            throw new NotImplementedException();
        }

        static public implicit operator SqlFile(string file_path)
        {
            return new SqlFile {path = file_path.ToLower()};
        }

        public bool Equals(SqlFile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.path, path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SqlFile)) return false;
            return Equals((SqlFile) obj);
        }

        public override int GetHashCode()
        {
            return (path != null ? path.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return path;
        }
    }
}