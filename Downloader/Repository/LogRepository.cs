using System;
using System.IO;
using Downloader.Model;
using Downloader.Utils;

namespace Downloader.Repository
{
    public class LogRepository
    {
        public string Read()
        {
            using (StreamReader r = new StreamReader(Constants.LogFileName))
            {
                return r.ReadToEnd();
            }
        }

        public void Append(string log)
        {
            using (StreamWriter r = new StreamWriter(Constants.LogFileName, true))
            {
                InsertTime(r);
                r.Write(log);
            }
        }

        public void Append(Exception ex)
        {
            using (StreamWriter r = new StreamWriter(Constants.LogFileName, true))
            {
                InsertTime(r);
                r.Write($"Exception: {ex}");
                if (ex.InnerException != null)
                {
                    r.Write(Environment.NewLine);
                    r.Write($"InnerException: {ex.InnerException}");
                }
            }
        }

        private static void InsertTime(StreamWriter r)
        {
            r.Write(Environment.NewLine);
            r.Write(Environment.NewLine);
            r.Write(Helper.GetLogTime());
        }
    }
}