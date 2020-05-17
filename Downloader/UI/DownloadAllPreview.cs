using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Downloader.Model;

namespace Downloader.UI
{
    public partial class DownloadAllPreview : BaseProcessForm
    {
        private MainForm _main;
        private List<PreviewGridItem> _previewSource;

        public DownloadAllPreview(MainForm main)
        {
            _main = main;
            _previewSource = new List<PreviewGridItem>();

            InitializeComponent();
        }

        protected override TextBox InternalLogStatus => Status;

        protected override async Task ProcessFile(UrlSource source, int fromIndex, int toIndex, int amount, string mediaName, string fileDestination, string destination)
        {
            _previewSource.Add(new PreviewGridItem
            {
                Checked = true,
                Source = source,
                MediaName = mediaName,
                Destination = destination
            });

            await ProcessNext(source, fromIndex + 1, toIndex, amount - 1);
        }

        protected override void OnFinishProcessing()
        {
            var config = _repository.ReadConfig();
            var favourites = _previewSource.Select(x => x.Source).Distinct().Select(x => new RememberGridItem
            {
                Checked = true,
                Source = x,
            }).ToList();

            if (config.Favourites != null && config.Favourites.Any())
            {
                var foundFavourites = favourites.Where(x => config.Favourites.Contains(x.Source.Text));

                if (foundFavourites.Any())
                {
                    favourites.ForEach(x => x.Checked = false);
                    _previewSource.ForEach(x => x.Checked = false);

                    foreach (var favourite in foundFavourites)
                    {
                        favourite.Checked = true;
                        _previewSource.Where(x => x.Source == favourite.Source).ToList().ForEach(x => x.Checked = true);
                    }
                }
            }

            PreviewGrid.DataSource = _previewSource;
            RememberGrid.DataSource = favourites;

            RememberGrid.CellMouseUp += (s, e) =>
            {
                RememberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            RememberGrid.CellValueChanged += (s, e) =>
            {
                foreach (var favourite in favourites)
                {
                    _previewSource.Where(x => x.Source.Text == favourite.Source.Text).ToList().ForEach(x => x.Checked = favourite.Checked);
                }

                PreviewGrid.DataSource = null;
                PreviewGrid.DataSource = _previewSource;
            };
        }

        private async void DownloadAllPreview_Load(object sender, EventArgs e)
        {
            await ProcessAllSources(null);

            if (_previewSource.All(x => x.Checked))
            {
                SelectAll.Checked = true;
            }
        }

        public override IndexParams GetIndexParams(UrlSource source)
        {
            return _main.GetIndexParams(source);
        }

        public override string GetFinalDestination(UrlSource source)
        {
            return _main.GetFinalDestination(source);
        }

        private async void AcceptSources_Click(object sender, EventArgs e)
        {
            if (RememberSources.Checked)
            {
                var config = _repository.ReadConfig();

                var rememberList = RememberGrid.DataSource as List<RememberGridItem>;

                if (!rememberList.Any(x => x.Checked) || rememberList.All(x => x.Checked))
                {
                    config.Favourites = new List<string>();
                }
                else
                {
                    config.Favourites = rememberList.Where(x => x.Checked).Select(x => x.Source.Text).ToList();
                }

                _repository.WriteConfig(config);
            }

            Close();

            await _main.ProcessAllSources(_previewSource.Where(x => x.Checked));
        }

        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            var favourites = RememberGrid.DataSource as List<RememberGridItem>;
            var previews = PreviewGrid.DataSource as List<PreviewGridItem>;

            favourites.ForEach(x => x.Checked = SelectAll.Checked);
            previews.ForEach(x => x.Checked = SelectAll.Checked);

            RememberGrid.DataSource = null;
            RememberGrid.DataSource = favourites;
            PreviewGrid.DataSource = null;
            PreviewGrid.DataSource = previews;

            RememberGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            PreviewGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}