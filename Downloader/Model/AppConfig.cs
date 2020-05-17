using System.Collections.Generic;

namespace Downloader.Model
{

    public class AppConfig
    {
        public List<UrlSource> Sources { get; set; }

        public string DefaultFolder { get; set; }

        public string CopyDestination { get; set; }

        public List<string> Favourites { get; set; }
    }
}