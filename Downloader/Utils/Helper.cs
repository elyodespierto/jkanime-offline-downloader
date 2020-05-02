using System.IO;

namespace Downloader.Utils
{
    public static class Helper
    {
        public static string CreateURL(bool addSlash, string part1, string episodeNumber)
        {
            var mp4formatNumber = $"{episodeNumber}.mp4";

            if (addSlash)
            {
                return part1 + "/" + mp4formatNumber;
            }
            else
            {
                return part1 + mp4formatNumber;
            }
        }

        public static string Combine(string part1, string part2)
        {
            return Path.Combine(part1, part2);
        }
    }
}