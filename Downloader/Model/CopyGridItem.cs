using System.IO;

namespace Downloader.Model
{
    public class CopyGridItem
    {
        public bool SelectedToCopy { get; set; }
        public bool ForceCopy => SelectedToCopy && HasCopy;
        public bool HasCopy { get; internal set; }
        public string FileName { get; internal set; }
        public string OriginFilePath { get; internal set; }
        public string DestinFilePath { get; internal set; }

        internal string Origin()
        {
            return Path.Combine(OriginFilePath, FileName);
        }

        internal string Destin()
        {
            return Path.Combine(DestinFilePath, FileName);
        }
    }
}