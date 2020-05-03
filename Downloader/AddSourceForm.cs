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
                Mp4Url.Text = _currentObject.Mp4Url;
                SeasonTextBox.Text = (_currentObject.Season).ToString();
                NameTextBox.Text = _currentObject.Name;
                IsLongSeason.Checked = _currentObject.IsLongSeason;
                IncludeSiteUrl.Checked = !string.IsNullOrEmpty(_currentObject.SiteUrl);
                EpisodeAmount.Text = _currentObject.EpisodeAmount?.ToString();

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
            source.Mp4Url = Mp4Url.Text;
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

            try
            {
                source.EpisodeAmount = Convert.ToInt32(EpisodeAmount.Text);
            }
            catch (Exception)
            {
            }

            if (IncludeSiteUrl.Checked)
            {
                source.SiteUrl = SiteUrl.Text;
                source.Mp4Url = null;
            }
            else
            {
                source.Mp4Url = Mp4Url.Text;
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
            FinalURL.Text = Helper.CreateURL(AddSlash.Checked, Mp4Url.Text, EpisodeFormat.Text);
        }

        private void EpisodeFormat_TextChanged(object sender, EventArgs e)
        {
            FinalURL.Text = Helper.CreateURL(AddSlash.Checked, Mp4Url.Text, EpisodeFormat.Text);
        }

        private void AddSlash_CheckedChanged(object sender, EventArgs e)
        {
            FinalURL.Text = Helper.CreateURL(AddSlash.Checked, Mp4Url.Text, EpisodeFormat.Text);
        }

        private void IncludeSiteUrl_CheckedChanged(object sender, EventArgs e)
        {
            SiteUrl.Enabled = IncludeSiteUrl.Checked;
            Mp4Url.Visible = !SiteUrl.Enabled;
            Shadow.Visible = SiteUrl.Enabled;
            AddSlash.Enabled = !SiteUrl.Enabled;

            if (SiteUrl.Enabled)
            {
                FinalURL.Text = Helper.Combine(SiteUrl.Text, EpisodeFormat.Text);
            }
            else
            {
                FinalURL.Text = Helper.CreateURL(AddSlash.Checked, Mp4Url.Text, EpisodeFormat.Text);
            }
        }

        private void Shadow_TextChanged(object sender, EventArgs e)
        {

        }

        private void SiteUrl_TextChanged(object sender, EventArgs e)
        {
            FinalURL.Text = Helper.Combine(SiteUrl.Text, EpisodeFormat.Text);
        }
    }
}