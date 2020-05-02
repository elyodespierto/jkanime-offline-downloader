using System.IO;
using Downloader.Model;
using Newtonsoft.Json;

namespace Downloader.Repository
{
    public class ConfigRepository
    {
        public AppConfig ReadConfig()
        {
            using (StreamReader r = new StreamReader(AppConfigConstants.ConfigFileName))
            {
                string json = r.ReadToEnd();

                return JsonConvert.DeserializeObject<AppConfig>(json);
            }
        }

        public void WriteConfig(AppConfig config)
        {
            using (StreamWriter r = new StreamWriter(AppConfigConstants.ConfigFileName))
            {
                var json = JsonConvert.SerializeObject(config);
                r.Write(json);
            }
        }
    }
}