using System.Collections.Generic;

namespace Downloader.Model
{
    public static class Constants
    {
        public const string ConfigFileName = "config.json";
        public const string LogFileName = "log.txt";
    }

    public class AppConfig
    {
        public List<UrlSource> Sources { get; set; }

        public string DefaultFolder { get; set; }
    }
}