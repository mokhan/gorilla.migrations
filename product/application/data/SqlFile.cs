namespace simple.migrations.Data
{
    public class SqlFile
    {
        public virtual string path { get; set; }

        static public implicit operator SqlFile(string file_path)
        {
            return new SqlFile {path = file_path};
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