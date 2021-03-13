using System;
using System.IO;
using Downloader.Extensions;

namespace Downloader.Utils
{
    public static class Helper
    {
        public static string CreateURL(bool addSlash, string url, string episodeNumber)
        {
            var mp4formatNumber = $"{episodeNumber}.mp4";

            if (addSlash)
            {
                return Path.Combine(url, episodeNumber).Replace("\\", "/");
            }
            else
            {
                return url + mp4formatNumber;
            }
        }

        public static string Combine(string part1, string part2)
        {
            var finalPath = Path.Combine(part1, part2).Replace("\\", "/");

            if (!finalPath.EndsWith("/"))
            {
                finalPath += "/";
            }

            return finalPath;
        }

        public static string GetLogTime()
        {
            return $"[{DateTime.Now.ToString("MM/dd/yyyy H:mm")}]";
        }
    }
}