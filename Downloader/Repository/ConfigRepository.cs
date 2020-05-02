using System.IO;
using Downloader.Model;
using Newtonsoft.Json;

namespace Downloader.Repository
{
    public class ConfigRepository
    {
        public AppConfig ReadConfig()
        {
            using (StreamReader r = new StreamReader(Constants.ConfigFileName))
            {
                string json = r.ReadToEnd();

                return JsonConvert.DeserializeObject<AppConfig>(json);
            }
        }

        public void WriteConfig(AppConfig config)
        {
            using (StreamWriter r = new StreamWriter(Constants.ConfigFileName))
            {
                var json = JsonConvert.SerializeObject(config);
                r.Write(json);
            }
        }
    }
}