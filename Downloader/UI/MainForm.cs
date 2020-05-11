using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Downloader.Extensions;
using Downloader.Logic;
using Downloader.Repository;
using Downloader.UI;
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
        private bool _bulkStarted;

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

            _bulkStarted = true;

            foreach (var source in config.Sources.OrderBy(x => x.Name))
            {
                if (_bulkStarted)
                {
                    UpdateUI(source);

                    Append($"-> Bulk Comenzado ({source.Text})");

                    await DownloadNext(source);

                    Append($"-> Bulk Finalizado ({source.Text})");
                }
                else
                {
                    Append($"-> Descarga Cancelada: {source.Url}");
                }
            }
        }

        private void Append(string log)
        {
            _log.Append(log);
            Status.Append(log);
        }

        private void Append(string status, string log)
        {
            _log.Append(status);
            _log.Append(log);
            Status.Append(status);
        }

        private void Append(string log, Exception ex)
        {
            _log.Append(log);
            _log.Append(ex);
            Status.Append(log);
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
                    if (source.EpisodeAmount.HasValue)
                    {
                        toIndex = source.EpisodeAmount.Value;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(To.Text))
                        {
                            toIndex = Convert.ToInt32(To.Text);
                        }
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
                Append("-> FATAL: error no handleado en DownloadNext(source). Ver log.", ex);
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
                    }
                    else
                    {
                        _currentClient = client;

                        string mediaName = GetMediaName(source, fromIndex);

                        string destination = GetFinalDestination(FinalDestination, source);

                        Directory.CreateDirectory(destination);

                        var fileDestination = Path.Combine(destination, mediaName);

                        if (File.Exists(fileDestination))
                        {
                            _log.Append($"-> Ya Existe {mediaName}");

                            await DownloadNext(source, fromIndex + 1, toIndex, amount);
                        }
                        else
                        {
                            var tasks = new ConcurrentBag<Task>();

                            string finalUrl = GetFinalUrl(source, fromIndex);

                            client.DownloadFileCompleted += (s, e) =>
                            {
                                if (e.Cancelled)
                                {
                                    Append($"-> Ultima descarga cancelada: {mediaName}");

                                    if (File.Exists(fileDestination))
                                    {
                                        File.Delete(fileDestination);
                                    }
                                }
                                else if (e.Error != null)
                                {
                                    Append($"-> Error al descargar {mediaName}", $"Error: {e.Error.Message}{Environment.NewLine}URLError: {finalUrl}");

                                    if (File.Exists(fileDestination))
                                    {
                                        File.Delete(fileDestination);
                                    }
                                }
                                else
                                {
                                    Append($"-> Finalizado {mediaName}");

                                    tasks.Add(DownloadNext(source, fromIndex + 1, toIndex, amount - 1));
                                }
                            };

                            if (!string.IsNullOrEmpty(source.SiteUrl))
                            {
                                var browser = new WebBrowser();

                                browser.ScriptErrorsSuppressed = true;

                                tasks.Add(browser.NavigateAsync(finalUrl));

                                browser.DocumentCompleted += (s, e) =>
                                {
                                    try
                                    {
                                        var htmlDocument = browser.Document.Window.Frames
                                        .Cast<HtmlWindow>()
                                        .Select(x => x.GetDocument())
                                        .FirstOrDefault(x => x.Url.ToString().Contains("jkanime"));

                                        if (htmlDocument != null)
                                        {
                                            browser.Dispose();

                                            var driver = new ChromeDriver();

                                            driver.Navigate().GoToUrl(htmlDocument.Url.ToString());

                                            var tag = driver.FindElementByTagName("source").GetAttribute("src");

                                            finalUrl = driver.FindElementByTagName("video").FindElement(By.TagName("source")).GetAttribute("src");

                                            driver.Quit();
                                        }
                                        else
                                        {
                                            //ISSUE: Este fue un intento para descargar desde https://www3.jkanime.video/ pero allí los videos eran streameados en paquetes pequeños (.ts)
                                            //       Estos pequeños paquetes luego eran unidos para formar el mp4, pero el video nunca es revelado en la pagina 
                                            //       En otras palabras... es otro level de streming.
                                            //var driver = new ChromeDriver();
                                            //driver.Navigate().GoToUrl(finalUrl);
                                            //var iframe = driver.FindElements(By.TagName("iframe")).FirstOrDefault(x => x.GetAttribute("src").Contains("cloud9"));
                                            //driver.SwitchTo().Frame(iframe);
                                            //var pageSource = driver.PageSource;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Append("-> FATAL: error al intentar obtener video URL. Ver log.", ex);
                                    }
                                };

                                await Task.WhenAll(tasks.ToArray());
                            }

                            URL.Text = finalUrl;

                            Append($"<- Descargando {mediaName}");

                            await client.DownloadFileTaskAsync(finalUrl, fileDestination).ContinueWith(task =>
                            {
                                Thread.Sleep(500);

                                Task.WaitAll(tasks.ToArray());
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Append("-> FATAL: error no handleado en DownloadNext(source, int, int, int). Ver log.", ex);
            }
        }

        private static string GetFinalUrl(UrlSource source, int fromIndex)
        {
            var finalUrl = source.Url;

            if (!string.IsNullOrEmpty(source.SiteUrl))
            {
                finalUrl = Helper.Combine(source.Url, fromIndex.ToString());
            }
            else
            {
                finalUrl = Helper.CreateURL(source.AddSlash, source.Url, fromIndex.ToString(source.Format));
            }

            return finalUrl;
        }

        private static string GetMediaName(UrlSource source, int fromIndex)
        {
            var season = string.Empty;

            if (source.Season.HasValue)
            {
                season = $"S{source.Season.Value.ToString("00")}";
            }

            var episodeFormat = source.IsLongSeason ? "000" : source.Format;

            var mediaName = $"{source.Name}_{season}E{fromIndex.ToString(episodeFormat)}.mp4";

            return mediaName;
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

            if (source.EpisodeAmount.HasValue)
            {
                To.Text = source.EpisodeAmount.ToString();
            }
            else
            {
                To.Text = string.Empty;
            }

            From.Text = "1";
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
            _bulkStarted = false;

            if (_currentClient != null)
            {
                if (_currentClient.IsBusy)
                {
                    _currentClient.CancelAsync();

                    Append($"-> Cancelando descarga. Aguarde...");
                }
            }
        }

        private void SetAsDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (_currentClient != null && _currentClient.IsBusy)
            {
                _currentClient.DownloadFileCompleted += (s2, e2) =>
                {
                    Close();
                };

                Append("-> Esperando última descarga para cerrar. ESPERE!");
            }
            else
            {
                Close();
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            new CopyForm(this, _configRepository, _log).Show();
        }
    }
}