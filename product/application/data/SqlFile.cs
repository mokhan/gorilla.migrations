using System;

namespace simple.migrations.Data
{
    public class SqlFile
    {
        public virtual string path { get; set; }

        public virtual int version()
        {
            throw new NotImplementedException();
        }

        public virtual string name()
        {
            throw new NotImplementedException();
        }

        public virtual bool is_greater_than(int version)
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