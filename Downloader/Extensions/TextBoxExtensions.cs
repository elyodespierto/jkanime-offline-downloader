using System;
using System.Windows.Forms;

namespace Downloader.Extensions
{
    public static class TextBoxExtensions
    {
        private delegate void SafeCallDelegate(string text);

        public static void AddLine(this TextBox box, string line)
        {
            if (box.InvokeRequired)
            {
                var d = new SafeCallDelegate(box.AddLine);
                box.Invoke(d, new object[] { line });
            }
            else
            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    box.AppendText(line);
                    return;
                }

                box.AppendText(Environment.NewLine);
                box.AppendText(line);
            }
        }
    }
}