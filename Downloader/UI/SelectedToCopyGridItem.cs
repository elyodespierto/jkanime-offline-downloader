using Downloader.Model;

namespace Downloader.UI
{
    public class SelectedToCopyGridItem
    {
        private CopyGridItem _gridItem;

        public SelectedToCopyGridItem(CopyGridItem gridItem)
        {
            _gridItem = gridItem;
        }

        public string FileName => _gridItem.FileName;

        public CopyGridItem GetInnerItem()
        {
            return _gridItem;
        }
    }
}