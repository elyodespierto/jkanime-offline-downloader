using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Downloader.Model;

namespace Downloader
{
    public class BaseProcessForm : BaseForm
    {
        private IEnumerable<PreviewGridItem> _previewList;
        protected bool _bulkStarted;
        protected bool _processStarted;

        protected virtual void SaveDefaultFolder()
        {
        }

        public async Task ProcessAllSources(IEnumerable<PreviewGridItem> previewList)
        {
            var config = _repository.ReadConfig();
            var tasks = new ConcurrentBag<Task>();

            _previewList = previewList;

            _bulkStarted = true;
            Append($"-> Comenzando proceso de descarga");
            OnStartingProcessing();

            foreach (var source in config.Sources.OrderBy(x => x.Name))
            {
                if (_bulkStarted)
                {
                    await Process(source);
                }
            }

            OnFinishProcessing();
            Append($"-> Proceso de descarga finalizado");
            _bulkStarted = false;
        }

        protected virtual void OnFinishProcessing()
        {
        }

        protected virtual void OnStartingProcessing()
        {
        }

        protected async Task Process(UrlSource source)
        {
            _processStarted = true;

            try
            {
                var indexParams = GetIndexParams(source);

                await ProcessNext(source, indexParams.FromIndex, indexParams.ToIndex, indexParams.Amount);

                SaveDefaultFolder();
            }
            catch (Exception ex)
            {
                Append($"-> FATAL: error no handleado en {nameof(ProcessNext)}(source). Ver log.", ex);
            }

            _processStarted = false;
        }

        protected async Task ProcessNext(UrlSource source, int fromIndex, int toIndex, int amount)
        {
            try
            {
                if (fromIndex <= toIndex && amount >= 1)
                {
                    string mediaName = GetMediaName(source, fromIndex);

                    string destination = GetFinalDestination(source);

                    var fileDestination = Path.Combine(destination, mediaName);

                    if (File.Exists(fileDestination))
                    {
                        AppendInLog($"-> Ya Existe {mediaName}");

                        await ProcessNext(source, fromIndex + 1, toIndex, amount);
                    }
                    else
                    {
                        if (_previewList == null || _previewList.Select(x => x.MediaName).Contains(mediaName))
                        {
                            await ProcessFile(source, fromIndex, toIndex, amount, mediaName, fileDestination, destination);
                        }
                        else
                        {
                            await ProcessNext(source, fromIndex + 1, toIndex, amount - 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Append($"-> FATAL: error no handleado en {nameof(ProcessNext)}(source, int, int, int, ..). Ver log.", ex);
            }
        }

        protected string GetMediaName(UrlSource source, int fromIndex)
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

        public virtual string GetFinalDestination(UrlSource source)
        {
            return null;
        }

        protected virtual Task ProcessFile(UrlSource source, int fromIndex, int toIndex, int amount, string mediaName, string fileDestination, string destination)
        {
            throw new NotImplementedException();
        }

        public virtual IndexParams GetIndexParams(UrlSource source)
        {
            return null;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseProcessForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseProcessForm";
            this.ResumeLayout(false);

        }
    }
}