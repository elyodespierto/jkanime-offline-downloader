using System;
using Downloader.Extensions;
using Downloader.Utils;

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
        public bool IsFile { get; set; }
        public string Mp4Url { get; set; }
        public string SiteUrl { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public int? Season { get; set; }
        public int? EpisodeAmount { get; set; }
        public string Folder => Name;

        //new
        public bool IsMovie { get; set; }
        public string Link { get; set; }
        public bool OneOnly { get; set; }
        public bool IsOva { get; set; }
        public bool IsSeason { get; set; }
        public bool IsEpisode { get; set; }
        public string ExtraName { get; set; }

        public virtual string Text
        {
            get
            {
                var name = Name;

                if (Season.HasValue)
                {
                    if (IsMovie)
                    {
                        name += $"  •  Movie_{Season}";
                    }
                    else if (IsOva)
                    {
                        name += $"  •  Ova_{Season}";
                    }
                    else if (IsSeason || Season.HasValue)
                    {
                        name += $"  •  Season_{Season}";
                    }
                }

                return name;
            }
        }

        public string Url
        {
            get
            {
                if (Link.IsNullOrEmpty())
                {
                    return string.IsNullOrEmpty(SiteUrl) ? Mp4Url : SiteUrl;
                }
                else
                {
                    return Link;
                }
            }
        }

        public override string ToString()
        {
            return Text;
        }

        public string GetMediaName(int fromIndex)
        {
            var extra = string.Empty;

            if (!ExtraName.IsNullOrEmpty())
            {
                extra += $"_{ExtraName}";
            }

            var episodeFormat = IsLongSeason ? "000" : Format;

            var episode = fromIndex.ToString(episodeFormat);

            if (IsMovie)
            {
                var season = string.Empty;

                if (Season.HasValue)
                {
                    season = $"_M{Season.Value.ToString("00")}";
                }

                var mediaName = $"{Name}{season}{extra}.mp4";

                return mediaName;
            }
            else if (IsOva)
            {
                var season = string.Empty;

                if (Season.HasValue)
                {
                    season = $"_O{Season.Value.ToString("00")}";
                }

                var mediaName = $"{Name}{season}{extra}.mp4";

                return mediaName;
            }
            else if (IsEpisode)
            {
                var season = string.Empty;

                var mediaName = $"{Name}_{season}E{episode}{extra}.mp4";

                return mediaName;
            }
            else
            {
                var season = string.Empty;

                if (Season.HasValue)
                {
                    season = $"S{Season.Value.ToString("00")}";
                }

                var mediaName = $"{Name}_{season}E{episode}.mp4";

                return mediaName;
            }
        }

        public string GetFinalUrl(int fromIndex)
        {
            var finalUrl = Url;

            if (!IsFile)
            {
                if (!OneOnly)
                {
                    if (!finalUrl.IsNullOrEmpty())
                    {
                        finalUrl = Helper.Combine(finalUrl, fromIndex.ToString(Format));
                        //finalUrl = Helper.CreateURL(AddSlash, finalUrl, fromIndex.ToString(Format));
                    }
                }
            }

            return finalUrl;
        }
    }
}