namespace Downloader.Model
{
    public class PreviewGridItem
    {
        public bool Checked { get; set; }
        public string MediaName { get; internal set; }
        public string Destination { get; internal set; }
        public UrlSource Source { get; internal set; }
    }

    public class RememberGridItem
    {
        public bool Checked { get; set; }
        public UrlSource Source { get; internal set; }
    }
}