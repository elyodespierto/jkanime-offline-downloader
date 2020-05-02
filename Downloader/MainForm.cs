using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Downloader.Extensions;
using Downloader.Repository;
using Downloader.Utils;

namespace Downloader
{
    public partial class MainForm : Form
    {
        private string _selectedFolder;
        private URLObject _currentSource;
        private WebClient _currentClient;
        private ConfigRepository _configRepository;

        public MainForm()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
        }

        private void SaveDefaultFolder()
        {
            if (SetAsDefault.Checked)
            {
                var config = _configRepository.ReadConfig();

                config.DefaultFolder = _selectedFolder;

                _configRepository.WriteConfig(config);
            }
        }

        private async void ButtonDownload_Click(object sender, EventArgs e)
        {
            await DownloadNext();
        }

        private async void DownloadAll_Click(object sender, EventArgs e)
        {
            var config = _configRepository.ReadConfig();
            var tasks = new ConcurrentBag<Task>();

            foreach (var source in config.Sources)
            {
                _currentSource = source;

                UpdateUI();

                await DownloadNext();
            }
        }

        private async Task DownloadNext()
        {
            try
            {
                int fromIndex = 1;
                int toIndex = int.MaxValue;
                int amount = int.MaxValue;

                try
                {
                    if (!string.IsNullOrEmpty(From.Text))
                    {
                        fromIndex = Convert.ToInt32(From.Text);
                    }
                }
                catch
                {
                }

                try
                {
                    if (!string.IsNullOrEmpty(To.Text))
                    {
                        toIndex = Convert.ToInt32(To.Text);
                    }
                }
                catch
                {
                }

                try
                {
                    if (!string.IsNullOrEmpty(Amount.Text))
                    {
                        amount = Convert.ToInt32(Amount.Text);
                    }
                }
                catch
                {
                }

                await DownloadNext(fromIndex, toIndex, amount);

                SaveDefaultFolder();
            }
            catch (Exception ex)
            {
                Status.AddLine($"Error {ex}");
            }
        }

        private async Task DownloadNext(int fromIndex, int toIndex, int amount)
        {
            try
            {
                using (var client = new WebClient())
                {
                    if (fromIndex > toIndex || amount < 1)
                    {
                        Status.AddLine($"Proceso Finalizado");
                    }
                    else
                    {
                        _currentClient = client;

                        var episodeNumber = fromIndex.ToString(_currentSource.Format);

                        var season = string.Empty;

                        if (_currentSource.Season.HasValue)
                        {
                            season = $"S{_currentSource.Season.Value.ToString("00")}";
                        }

                        var episodeFormat = _currentSource.IsLongSeason ? "000" : _currentSource.Format;

                        var mediaName = $"{_currentSource.Name}_{season}E{fromIndex.ToString(episodeFormat)}.mp4";

                        string destination = GetFinalDestination(FinalDestination);

                        Directory.CreateDirectory(destination);

                        var fileDestination = Path.Combine(destination, mediaName);

                        if (File.Exists(fileDestination))
                        {
                            await DownloadNext(fromIndex + 1, toIndex, amount);
                        }
                        else
                        {
                            Status.AddLine($"Descargando {mediaName}");

                            var finalUrl = Helper.CreateURL(_currentSource.AddSlash, URL.Text, episodeNumber);
                            var tasks = new ConcurrentBag<Task>();

                            client.DownloadFileCompleted += (s, e) =>
                            {
                                if (e.Cancelled)
                                {
                                    Status.AddLine(Environment.NewLine);
                                    Status.AddLine($"Ultima descarga cancelada");

                                    if (File.Exists(fileDestination))
                                    {
                                        File.Delete(fileDestination);
                                    }
                                }
                                else if (e.Error != null)
                                {
                                    Status.AddLine(Environment.NewLine);
                                    Status.AddLine($"Error al descargar {mediaName}. " +
                                        $"{Environment.NewLine}" +
                                        $"Error: {e.Error.Message}" +
                                        $"{Environment.NewLine}" +
                                        $"URLError: {finalUrl}");

                                    if (File.Exists(fileDestination))
                                    {
                                        File.Delete(fileDestination);
                                    }
                                }
                                else
                                {
                                    tasks.Add(DownloadNext(fromIndex + 1, toIndex, amount - 1));
                                }
                            };

                            await client.DownloadFileTaskAsync(finalUrl, fileDestination).ContinueWith(async task =>
                            {
                                Thread.Sleep(1000);

                                Task.WaitAll(tasks.ToArray());
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Status.AddLine(Environment.NewLine);
                Status.AddLine($"Error {ex}");
            }
        }

        private string GetFinalDestination(Label updatingLabel)
        {
            var destination = _selectedFolder;

            if (_currentSource != null)
            {
                destination = _currentSource.Folder;

                if (!string.IsNullOrEmpty(destination))
                {
                    destination = Path.Combine(_selectedFolder, _currentSource.Folder);
                }
            }

            updatingLabel.Text = destination;

            return destination;
        }

        private void SelectDestinButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _selectedFolder = fbd.SelectedPath;
                    SelectedFolder.Text = _selectedFolder;
                    GetFinalDestination(FinalDestination);
                    SetAsDefault.Checked = false;
                }
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void FolderNameTextBox_TextChanged(object sender, EventArgs e)
        {
            GetFinalDestination(FinalDestination);
        }

        private void URLSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSource = URLCombo.SelectedItem as URLObject;

            UpdateUI();
        }

        private void UpdateUI()
        {
            URL.Text = _currentSource.Value;
            FolderName.Text = _currentSource.Folder;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCombos();

            var config = _configRepository.ReadConfig();

            if (!string.IsNullOrWhiteSpace(config.DefaultFolder))
            {
                _selectedFolder = config.DefaultFolder;
                SelectedFolder.Text = _selectedFolder;
                SetAsDefault.Checked = true;
            }
        }

        private void LoadCombos()
        {
            URLCombo.Items.Clear();
            URLCombo.Items.Insert(0, new EmptiURLObject());

            var index = 1;

            var config = _configRepository.ReadConfig();

            var items = config.Sources.OrderBy(x => x.Name).ToList();

            foreach (var item in items)
            {
                URLCombo.Items.Insert(index, item);

                index++;
            }
        }

        private void AddConfigButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddSourceForm(_currentSource);

            addForm.ItemSaved += (s, e2) =>
            {
                LoadCombos();
            };

            addForm.Show();
        }

        private void CancelCurrentDownload_Click(object sender, EventArgs e)
        {
            if (_currentClient != null)
            {
                if (_currentClient.IsBusy)
                {
                    _currentClient.CancelAsync();

                    Status.AddLine($"Cancelando descarga. Aguarde...");
                }
            }
        }

        private void SetAsDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}