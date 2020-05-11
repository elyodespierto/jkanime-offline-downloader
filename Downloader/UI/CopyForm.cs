using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Downloader.Extensions;
using Downloader.Model;
using Downloader.Repository;

namespace Downloader.UI
{
    public partial class CopyForm : Form
    {
        private MainForm _mainForm;
        private ConfigRepository _repository;
        private LogRepository _log;

        public CopyForm(MainForm mainForm, ConfigRepository repository, LogRepository log)
        {
            _mainForm = mainForm;
            _repository = repository;
            _log = log;

            InitializeComponent();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            try
            {
                Append($"-> Copiando");

                Copy.Enabled = false;

                foreach (var item in SelectedToCopyGrid.DataSource as List<SelectedToCopyGridItem>)
                {
                    var inner = item.GetInnerItem();
                    var forzadoText = string.Empty;

                    File.Copy(inner.Origin(), inner.Destin(), inner.ForceCopy);

                    if (inner.ForceCopy)
                    {
                        forzadoText = "(forzado)";
                    }

                    Append($"-> Copiado {inner.Origin()} -> {inner.Destin()} {forzadoText}");
                }

                Append($"-> Proceso de copiado finalizado");

                FillGrid(_repository.ReadConfig());

                Copy.Enabled = true;
            }
            catch (Exception ex)
            {
                Append("-> FATAL: Error al copiar", ex);
            }
        }

        private void CopyForm_Load(object sender, EventArgs e)
        {
            try
            {
                var config = _repository.ReadConfig();

                if (config.DefaultFolder.IsNullOrEmpty())
                {
                    _log.Append(new ArgumentNullException("La carpeta de origen debe estar seleccionada"));

                    MessageBox.Show("Error", $"La carpeta de origen debe estar seleccionada");

                    Close();
                    return;
                }

                if (config.CopyDestination.IsNullOrEmpty())
                {
                    SelectFolder(config);
                }
                else
                {
                    Destination.Text = config.CopyDestination;
                }

                if (config.CopyDestination.IsNullOrEmpty())
                {
                    MessageBox.Show("Copiar", $"La carpeta de destino debe estar seleccionada");

                    return;
                }

                FillGrid(config);
            }
            catch (Exception ex)
            {
                Append("-> FATAL: Error al cargar el formulario de copiado", ex);
            }
        }

        private void FillGrid(AppConfig config)
        {
            try
            {
                Append($"-> Cargando grillas");

                var gridSource = new List<CopyGridItem>();
                var originFiles = Directory.GetFiles(config.DefaultFolder, "*", SearchOption.AllDirectories);
                var destinFiles = Directory.GetFiles(config.CopyDestination, "*", SearchOption.AllDirectories);

                foreach (var ofile in originFiles)
                {
                    var gridItem = new CopyGridItem();

                    gridItem.FileName = Path.GetFileName(ofile);

                    var dfile = destinFiles.FirstOrDefault(x => x.Contains(gridItem.FileName));

                    gridItem.OriginFilePath = Path.GetDirectoryName(ofile);

                    if (dfile.IsNullOrEmpty())
                    {
                        gridItem.SelectedToCopy = true;
                        gridItem.HasCopy = false;

                        gridItem.DestinFilePath = config.CopyDestination + gridItem.OriginFilePath.Replace(config.DefaultFolder, string.Empty);
                    }
                    else
                    {
                        gridItem.SelectedToCopy = false;
                        gridItem.HasCopy = true;

                        gridItem.DestinFilePath = Path.GetDirectoryName(dfile);
                    }

                    gridSource.Add(gridItem);
                }

                UpdateSelectedToCopyGrid(gridSource);

                AllFilesCount.Text = gridSource.Count.ToString();

                CopyGrid.DataSource = gridSource;

                CopyGrid.CellMouseUp += (s, e) =>
                {
                    CopyGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };

                CopyGrid.CellValueChanged += (s, e) =>
                {
                    UpdateSelectedToCopyGrid(gridSource);
                };

                Append($"<- Finalizado cargar grillas");
            }
            catch (Exception ex)
            {
                Append("-> FATAL: Error al cargar las grillas", ex);
            }
        }

        private void UpdateSelectedToCopyGrid(List<CopyGridItem> gridSource)
        {
            var selectedToCopy = gridSource.Where(x => x.SelectedToCopy).Select(x => new SelectedToCopyGridItem(x)).ToList();
            SelectedFilesCount.Text = selectedToCopy.Count.ToString();
            SelectedToCopyGrid.DataSource = selectedToCopy;
        }

        private void SelectFolder(AppConfig config)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    config.CopyDestination = fbd.SelectedPath;
                    Destination.Text = config.CopyDestination;

                    _repository.WriteConfig(config);

                    FillGrid(config);
                }
            }
        }

        private void SelectDestination_Click(object sender, EventArgs e)
        {
            SelectFolder(_repository.ReadConfig());
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
    }
}