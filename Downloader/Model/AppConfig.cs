using System.Collections.Generic;

namespace Downloader.Model
{
    public static class AppConfigConstants
    {
        public const string ConfigFileName = "config.json";
    }

    public class AppConfig
    {
        public List<URLObject> Sources { get; set; }

        public string DefaultFolder { get; set; }
    }
}