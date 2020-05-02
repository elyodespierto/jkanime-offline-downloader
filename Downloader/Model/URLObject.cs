namespace Downloader
{
    public class EmptiURLObject : URLObject
    {
        public EmptiURLObject()
        {
            Value = string.Empty;
        }

        public override string Text => string.Empty;
    }

    public class URLObject
    {
        public bool AddSlash { get; set; }
        public bool IsLongSeason { get; set; }
        public string Value { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public int? Season { get; set; }
        public string Folder => Name;
        public virtual string Text => Season.HasValue ? $"{Name}   |    temporada-{Season}" : $"{Name}";
        public override string ToString()
        {
            return Text;
        }
    }
}