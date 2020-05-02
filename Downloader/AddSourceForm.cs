using System;
using System.Linq;
using System.Windows.Forms;
using Downloader.Repository;
using Downloader.Utils;

namespace Downloader
{
    public delegate void ItemSavedEventHandler(object sender, EventArgs e);

    public partial class AddSourceForm : Form
    {
        private UrlSource _currentObject;
        private string _oldURL;
        private ConfigRepository _configRepo;

        public event ItemSavedEventHandler ItemSaved;

        public AddSourceForm(UrlSource currentObject)
        {
            _currentObject = currentObject;
            InitializeComponent();
        }

        private void AddSourceForm_Load(object sender, EventArgs e)
        {
            if (_currentObject != null)
            {
                AddSlash.Checked = _currentObject.AddSlash;
                EpisodeFormat.Text = _currentObject.Format;
                URL.Text = _currentObject.Mp4Url;
                SeasonTextBox.Text = (_currentObject.Season).ToString();
                NameTextBox.Text = _currentObject.Name;
                IsLongSeason.Checked = _currentObject.IsLongSeason;
                IncludeSiteUrl.Checked = !string.IsNullOrEmpty(_currentObject.SiteUrl);

                if (IncludeSiteUrl.Checked)
                {
                    SiteUrl.Text = _currentObject.SiteUrl;
                }

                _oldURL = _currentObject.Mp4Url;
            }

            _configRepo = new ConfigRepository();
        }

        private void AddSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();
            var source = new UrlSource();

            FillSource(source);

            config.Sources.Add(source);

            _configRepo.WriteConfig(config);

            ItemSaved(sender, e);

            Close();
        }

        private void UpdateSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();

            var source = config.Sources.FirstOrDefault(x => x.Mp4Url == _oldURL);

            if (source != null)
            {
                FillSource(source);

                _configRepo.WriteConfig(config);

                ItemSaved(sender, e);
            }
            else
            {
                MessageBox.Show("No se encontró el elemento a modificar");
            }

            Close();
        }

        private void FillSource(UrlSource source)
        {
            source.Format = EpisodeFormat.Text;
            source.Mp4Url = URL.Text;
            source.Name = NameTextBox.Text;
            source.IsLongSeason = IsLongSeason.Checked;
            source.AddSlash = AddSlash.Checked;

            try
            {
                source.Season = Convert.ToInt32(SeasonTextBox.Text);
            }
            catch (Exception)
            {
            }

            if (IncludeSiteUrl.Checked)
            {
                source.SiteUrl = SiteUrl.Text;
            }
            else
            {
                source.SiteUrl = null;
            }
        }

        private void DeleteSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();

            var source = config.Sources.FirstOrDefault(x => x.Mp4Url == _oldURL);

            if (source != null)
            {
                config.Sources.Remove(source);

                _configRepo.WriteConfig(config);

                ItemSaved(sender, e);
            }
            else
            {
                MessageBox.Show("No se encontró el elemento a eliminar");
            }

            Close();
        }

        private void URL_TextChanged(object sender, EventArgs e)
        {
            FinalURL.Text = Helper.CreateURL(AddSlash.Checked, URL.Text, EpisodeFormat.Text);
        }

        private void EpisodeFormat_TextChanged(object sender, EventArgs e)
        {
            FinalURL.Text = Helper.CreateURL(AddSlash.Checked, URL.Text, EpisodeFormat.Text);
        }

        private void AddSlash_CheckedChanged(object sender, EventArgs e)
        {
            FinalURL.Text = Helper.CreateURL(AddSlash.Checked, URL.Text, EpisodeFormat.Text);
        }

        private void IncludeSiteUrl_CheckedChanged(object sender, EventArgs e)
        {
            SiteUrl.Enabled = IncludeSiteUrl.Checked;
        }
    }
}