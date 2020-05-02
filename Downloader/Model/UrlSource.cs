namespace Downloader
{
    public class EmptyUrlSource : UrlSource
    {
        public EmptyUrlSource()
        {
            Mp4Url = string.Empty;
        }

        public override string Text => string.Empty;
    }

    public class UrlSource
    {
        public bool AddSlash { get; set; }
        public bool IsLongSeason { get; set; }
        public string SiteUrl { get; set; }
        public string Mp4Url { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public int? Season { get; set; }
        public string Folder => Name;
        public virtual string Text => Season.HasValue ? $"{Name}   |    temporada-{Season}" : $"{Name}";
        public string Url => string.IsNullOrEmpty(SiteUrl) ? Mp4Url : SiteUrl;
        public override string ToString()
        {
            return Text;
        }
    }
}