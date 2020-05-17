using System;
using System.Windows.Forms;
using Downloader.Extensions;
using Downloader.Repository;

namespace Downloader
{

    public class BaseForm : Form
    {
        protected ConfigRepository _repository;
        protected LogRepository _log;

        public BaseForm()
        {
            _repository = new ConfigRepository();
            _log = new LogRepository();
        }

        protected virtual TextBox InternalLogStatus { get; }

        protected virtual void Append(string log)
        {
            _log.Append(log);
            InternalLogStatus.Append(log);
        }

        protected virtual void AppendInLog(string log)
        {
            _log.Append(log);
        }

        protected virtual void Append(string status, string log)
        {
            _log.Append(status);
            _log.Append(log);
            InternalLogStatus.Append(status);
        }

        protected virtual void Append(string log, Exception ex)
        {
            _log.Append(log);
            _log.Append(ex);
            InternalLogStatus.Append(log);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}