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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TradeAutomation;

namespace Downloader
{
    public partial class MainForm : Form
    {
        private string _selectedFolder;
        private UrlSource _currentSource;
        private WebClient _currentClient;
        private ConfigRepository _configRepository;
        private LogRepository _log;

        public MainForm()
        {
            InitializeComponent();

            _configRepository = new ConfigRepository();
            _log = new LogRepository();
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
            if (_currentSource != null)
            {
                await DownloadNext(_currentSource);
            }
            else
            {
                Status.Append("No se ha seleccionado una configuración");
            }
        }

        private async void DownloadAll_Click(object sender, EventArgs e)
        {
            var config = _configRepository.ReadConfig();
            var tasks = new ConcurrentBag<Task>();

            foreach (var source in config.Sources)
            {
                UpdateUI(source);

                await DownloadNext(source);
            }
        }

        private async Task DownloadNext(UrlSource source)
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

                await DownloadNext(source, fromIndex, toIndex, amount);

                SaveDefaultFolder();
            }
            catch (Exception ex)
            {
                _log.Append(ex);
                Status.Append("-> Fatal: error no handleado en DownloadNext(source). Ver log.");
            }
        }

        private async Task DownloadNext(UrlSource source, int fromIndex, int toIndex, int amount)
        {
            try
            {
                using (var client = new WebClient())
                {
                    if (fromIndex > toIndex || amount < 1)
                    {
                        _log.Append($"Proceso [{source.Text}] finalizado.");
                        Status.Append($"-> Proceso [{source.Text}] finalizado.");
                    }
                    else
                    {
                        _currentClient = client;

                        var episodeNumber = fromIndex.ToString(source.Format);

                        var season = string.Empty;

                        if (source.Season.HasValue)
                        {
                            season = $"S{source.Season.Value.ToString("00")}";
                        }

                        var episodeFormat = source.IsLongSeason ? "000" : source.Format;

                        var mediaName = $"{source.Name}_{season}E{fromIndex.ToString(episodeFormat)}.mp4";

                        string destination = GetFinalDestination(FinalDestination, source);

                        Directory.CreateDirectory(destination);

                        var fileDestination = Path.Combine(destination, mediaName);

                        if (File.Exists(fileDestination))
                        {
                            await DownloadNext(source, fromIndex + 1, toIndex, amount);
                        }
                        else
                        {
                            Status.Append($"Descargando {mediaName}");

                            var tasks = new ConcurrentBag<Task>();

                            var finalUrl = Helper.CreateURL(source.AddSlash, source.Mp4Url, episodeNumber);

                            if (!string.IsNullOrEmpty(source.SiteUrl))
                            {
                                finalUrl = Helper.Combine(source.SiteUrl, fromIndex.ToString());
                            }

                            client.DownloadFileCompleted += (s, e) =>
                            {
                                if (e.Cancelled)
                                {
                                    _log.Append($"Ultima descarga cancelada");
                                    Status.Append($"-> Ultima descarga cancelada: {mediaName}");

                                    if (File.Exists(fileDestination))
                                    {
                                        File.Delete(fileDestination);
                                    }
                                }
                                else if (e.Error != null)
                                {
                                    _log.Append($"Error al descargar {mediaName}. " +
                                        $"{Environment.NewLine}" +
                                        $"Error: {e.Error.Message}" +
                                        $"{Environment.NewLine}" +
                                        $"URLError: {finalUrl}");
                                    Status.Append($"-> Error al descargar {mediaName}");

                                    if (File.Exists(fileDestination))
                                    {
                                        File.Delete(fileDestination);
                                    }
                                }
                                else
                                {
                                    tasks.Add(DownloadNext(source, fromIndex + 1, toIndex, amount - 1));
                                }
                            };

                            if (!string.IsNullOrEmpty(source.SiteUrl))
                            {
                                var browser = new WebBrowser();

                                browser.ScriptErrorsSuppressed = true;

                                tasks.Add(browser.NavigateAsync(Path.Combine(source.SiteUrl, fromIndex.ToString())));

                                browser.DocumentCompleted += async (s, e) =>
                                {
                                    var htmlDocument = browser.Document.Window.Frames
                                        .Cast<HtmlWindow>()
                                        .Select(x => x.GetDocument())
                                        .FirstOrDefault(x => x.Url.ToString().Contains("jkanime"));

                                    if (htmlDocument != null)
                                    {
                                        try
                                        {
                                            browser.Dispose();

                                            var chromeDriver = new ChromeDriver();

                                            chromeDriver.Navigate().GoToUrl(htmlDocument.Url.ToString());

                                            var tag = chromeDriver.FindElementByTagName("source").GetAttribute("src");

                                            var videoUrl = chromeDriver.FindElementByTagName("video").FindElement(By.TagName("source")).GetAttribute("src");

                                            chromeDriver.Quit();

                                            await client.DownloadFileTaskAsync(videoUrl, fileDestination).ContinueWith(WaitTasks(tasks));
                                        }
                                        catch (Exception ex)
                                        {
                                            _log.Append(ex);
                                            Status.Append("-> Fatal: error al intentar obtener video URL. Ver log.");
                                        }
                                    }
                                };
                            }
                            else
                            {
                                await client.DownloadFileTaskAsync(finalUrl, fileDestination).ContinueWith(WaitTasks(tasks));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Append(ex);
                Status.Append("-> Fatal: error no handleado en DownloadNext(source, int, int, int). Ver log.");
            }
        }

        private static Action<Task> WaitTasks(ConcurrentBag<Task> tasks)
        {
            return clientTask =>
            {
                Thread.Sleep(100);

                Task.WaitAll(tasks.ToArray());
            };
        }

        private string GetFinalDestination(Label updatingLabel, UrlSource source)
        {
            var destination = _selectedFolder;

            if (source != null)
            {
                destination = source.Folder;

                if (!string.IsNullOrEmpty(destination))
                {
                    destination = Path.Combine(_selectedFolder, source.Folder);
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
                    GetFinalDestination(FinalDestination, _currentSource);
                    SetAsDefault.Checked = false;
                }
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void FolderNameTextBox_TextChanged(object sender, EventArgs e)
        {
            GetFinalDestination(FinalDestination, _currentSource);
        }

        private void URLSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSource = URLCombo.SelectedItem as UrlSource;

            UpdateUI(_currentSource);
        }

        private void UpdateUI(UrlSource source)
        {
            URL.Text = source.Url;
            FolderName.Text = source.Folder;
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
            URLCombo.Items.Insert(0, new EmptyUrlSource());

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

                    _log.Append($"Cancelando descarga. Aguarde...");
                    Status.Append($"-> Cancelando descarga. Aguarde...");
                }
            }
        }

        private void SetAsDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}