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
        private URLObject _currentObject;
        private string _oldURL;
        private ConfigRepository _configRepo;

        public event ItemSavedEventHandler ItemSaved;

        public AddSourceForm(URLObject currentObject)
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
                URL.Text = _currentObject.Value;
                SeasonTextBox.Text = (_currentObject.Season).ToString();
                NameTextBox.Text = _currentObject.Name;
                IsLongSeason.Checked = _currentObject.IsLongSeason;

                _oldURL = _currentObject.Value;
            }

            _configRepo = new ConfigRepository();
        }

        private void AddSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();

            config.Sources.Add(new URLObject
            {
                AddSlash = AddSlash.Checked,
                IsLongSeason = IsLongSeason.Checked,
                Format = EpisodeFormat.Text,
                Name = NameTextBox.Text,
                Value = URL.Text,
                Season = string.IsNullOrEmpty(SeasonTextBox.Text) ? (int?)null : Convert.ToInt32(SeasonTextBox.Text)
            });

            _configRepo.WriteConfig(config);

            ItemSaved(sender, e);

            Close();
        }

        private void UpdateSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();

            var source = config.Sources.FirstOrDefault(x => x.Value == _oldURL);

            if (source != null)
            {
                source.Format = EpisodeFormat.Text;
                source.Value = URL.Text;
                try
                {
                    source.Season = Convert.ToInt32(SeasonTextBox.Text);
                }
                catch (Exception)
                {
                }
                source.Name = NameTextBox.Text;
                source.IsLongSeason = IsLongSeason.Checked;
                source.AddSlash = AddSlash.Checked;

                _configRepo.WriteConfig(config);
                ItemSaved(sender, e);
            }
            else
            {
                MessageBox.Show("No se encontró el elemento a modificar");
            }

            Close();
        }

        private void DeleteSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();

            var source = config.Sources.FirstOrDefault(x => x.Value == _oldURL);

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
    }
}