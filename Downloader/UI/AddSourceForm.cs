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
                Link.Text = _currentObject.Url;
                SeasonTextBox.Text = _currentObject.Season.ToString();
                AnimeName.Text = _currentObject.Name;
                EpisodeName.Text = _currentObject.ExtraName;
                IsLongSeason.Checked = _currentObject.IsLongSeason;
                EsArchivo.Checked = _currentObject.IsFile;
                EpisodeAmount.Text = _currentObject.EpisodeAmount?.ToString();
                EsPelicula.Checked = _currentObject.IsMovie;
                EsOva.Checked = _currentObject.IsOva;
                EsCapitulo.Checked = _currentObject.IsEpisode;
                EsTemporada.Checked = _currentObject.IsSeason;
                Solo.Checked = _currentObject.OneOnly;

                if (!EsPelicula.Checked && !EsOva.Checked && !EsCapitulo.Checked && !EsTemporada.Checked)
                {
                    EsTemporada.Checked = true;
                }

                _oldURL = Link.Text;
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

            var source = config.Sources.FirstOrDefault(x => x.Url == _oldURL);

            if (source != null)
            {
                var dialogResult = MessageBox.Show("Seguro?", $"Modificar {source.Text}", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FillSource(source);

                    _configRepo.WriteConfig(config);

                    ItemSaved(sender, e);
                }
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
            source.Name = AnimeName.Text;
            source.ExtraName = EpisodeName.Text;
            source.Link = Link.Text;
            source.AddSlash = AddSlash.Checked;
            source.OneOnly = Solo.Checked;
            source.IsMovie = EsPelicula.Checked;
            source.IsOva = EsOva.Checked;
            source.IsSeason = EsTemporada.Checked;
            source.IsLongSeason = IsLongSeason.Checked;
            source.IsEpisode = EsCapitulo.Checked;
            source.IsFile = EsArchivo.Checked;

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
        }

        private void DeleteSource_Click(object sender, EventArgs e)
        {
            var config = _configRepo.ReadConfig();

            var source = config.Sources.FirstOrDefault(x => x.Url == _oldURL);

            if (source != null)
            {
                var dialogResult = MessageBox.Show("Seguro?", $"Eliminar {source.Text}", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    config.Sources.Remove(source);

                    _configRepo.WriteConfig(config);

                    ItemSaved(sender, e);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el elemento a eliminar");
            }

            Close();
        }

        private void EpisodeFormat_TextChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }

        private void IsLongSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (IsLongSeason.Checked)
            {
                EpisodeFormat.Enabled = false;
                EpisodeFormat.Text = "000";
            }
            else
            {
                EpisodeFormat.Enabled = true;
                EpisodeFormat.Text = "00";
            }
        }

        private void EsTemporada_CheckedChanged(object sender, EventArgs e)
        {
            if (EsTemporada.Checked)
            {
                IsLongSeason.Enabled = true;
            }
            else
            {
                IsLongSeason.Enabled = false;
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            UpdateNames();
        }

        private void UpdateNames()
        {
            var source = new UrlSource();

            FillSource(source);

            FileNamePreview.Text = source.GetMediaName(0);
            if (EsArchivo.Checked)
            {
                UrlPreview.Text = Link.Text;
            }
            else
            {
                UrlPreview.Text = source.GetFinalUrl(0);
            }
        }
    }
}