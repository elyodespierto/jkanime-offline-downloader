using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Downloader.Extensions;
using Downloader.UI;
using Downloader.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TradeAutomation;

namespace Downloader
{
    public partial class MainForm : BaseProcessForm
    {
        private string _selectedFolder;
        private UrlSource _currentSource;
        private WebClient _currentClient;

        protected override TextBox InternalLogStatus => Status;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void SaveDefaultFolder()
        {
            if (SetAsDefault.Checked)
            {
                var config = _repository.ReadConfig();

                config.DefaultFolder = _selectedFolder;

                _repository.WriteConfig(config);
            }
        }

        private async void ButtonDownload_Click(object sender, EventArgs e)
        {
            if (_currentSource != null)
            {
                await Process(_currentSource);
            }
            else
            {
                Status.Append("No se ha seleccionado una configuración");
            }
        }

        private void DownloadAll_Click(object sender, EventArgs e)
        {
            var result = new DownloadAllPreview(this).ShowDialog();
        }

        protected override void OnFinishProcessing()
        {
            EnableDisableForm(true);
        }

        protected override void OnStartingProcessing()
        {
            EnableDisableForm(false);
        }

        private void EnableDisableForm(bool enabled)
        {
            Amount.Enabled = enabled;
            DownloadAll.Enabled = enabled;
            Download.Enabled = enabled;
            From.Enabled = enabled;
            To.Enabled = enabled;
            Copy.Enabled = enabled;
            SelectDestinButton.Enabled = enabled;
            URLCombo.Enabled = enabled;
            SetAsDefault.Enabled = enabled;
        }

        public override IndexParams GetIndexParams(UrlSource source)
        {
            var indexParams = new IndexParams();

            indexParams.FromIndex = 1;
            indexParams.ToIndex = int.MaxValue;
            indexParams.Amount = int.MaxValue;

            try
            {
                if (!string.IsNullOrEmpty(From.Text))
                {
                    indexParams.FromIndex = Convert.ToInt32(From.Text);
                }
            }
            catch
            {
            }

            try
            {
                if (source.EpisodeAmount.HasValue)
                {
                    indexParams.ToIndex = source.EpisodeAmount.Value;
                }
                else
                {
                    if (!string.IsNullOrEmpty(To.Text))
                    {
                        indexParams.ToIndex = Convert.ToInt32(To.Text);

                        if (indexParams.ToIndex > 333)
                        {
                            indexParams.ToIndex = 333;
                        }
                    }
                    else
                    {
                        indexParams.ToIndex = 333;
                    }
                }
            }
            catch
            {
            }

            try
            {
                if (!string.IsNullOrEmpty(this.Amount.Text))
                {
                    indexParams.Amount = Convert.ToInt32(this.Amount.Text);

                    if (indexParams.Amount > 333)
                    {
                        indexParams.Amount = 33;
                    }
                }
            }
            catch
            {
            }

            if (source.OneOnly)
            {
                indexParams.Amount = 1;
            }

            return indexParams;
        }

        protected override async Task ProcessFile(UrlSource source, int fromIndex, int toIndex, int amount, string mediaName, string fileDestination, string destination)
        {
            URLCombo.SelectedItem = URLCombo.Items.Cast<UrlSource>().FirstOrDefault(x => x.Url == source.Url);
            UpdateUI(source);

            using (var client = new WebClient())
            {
                Directory.CreateDirectory(destination);

                _currentClient = client;

                var tasks = new ConcurrentBag<Task>();

                string finalUrl = source.GetFinalUrl(fromIndex);
                FinalUrl.Text = finalUrl;

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

                        tasks.Add(ProcessNext(source, fromIndex + 1, toIndex, amount - 1));
                    }
                };

                if (!source.IsFile)
                {
                    var browser = new WebBrowser();

                    browser.ScriptErrorsSuppressed = true;

                    tasks.Add(browser.NavigateAsync(finalUrl));

                    browser.DocumentCompleted += (s, e) =>
                    {
                        try
                        {
                            var frames = browser.Document.Window.Frames.Cast<HtmlWindow>().ToList();

                            var documents = frames.Select(x => x.GetDocument()).ToList();
                            var htmlDocument = documents.FirstOrDefault(x => x.Url.ToString().Contains("jkanime"));

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

                Append($"<- Descargando {mediaName}");

                await client.DownloadFileTaskAsync(finalUrl, fileDestination).ContinueWith(task =>
                {
                    Thread.Sleep(500);

                    Task.WaitAll(tasks.ToArray());
                });
            }
        }

        public override string GetFinalDestination(UrlSource source)
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

            return destination;
        }

        private void UpdateFinalDestination(UrlSource source)
        {
            FinalDestination.Text = GetFinalDestination(source);
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
                    UpdateFinalDestination(_currentSource);
                    SetAsDefault.Checked = false;
                }
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void FolderNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateFinalDestination(_currentSource);
        }

        private void URLSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSource = URLCombo.SelectedItem as UrlSource;

            UpdateUIFull(_currentSource);
        }

        protected void UpdateUI(UrlSource source)
        {
            FinalUrl.Text = source.Url;
            FolderName.Text = source.Folder;
            UpdateFinalDestination(source);
        }

        protected void UpdateUIFull(UrlSource source)
        {
            UpdateUI(source);

            if (!_bulkStarted && !_processStarted)
            {
                if (source.EpisodeAmount.HasValue)
                {
                    To.Text = source.EpisodeAmount.ToString();
                    From.Text = "1";
                }
                else
                {
                    To.Text = string.Empty;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCombos();

            var config = _repository.ReadConfig();

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

            var config = _repository.ReadConfig();

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
            new CopyForm().Show();
        }
    }

    public class IndexParams
    {
        public IndexParams()
        {
        }

        public int FromIndex { get; internal set; }
        public int ToIndex { get; internal set; }
        public int Amount { get; internal set; }
    }
}