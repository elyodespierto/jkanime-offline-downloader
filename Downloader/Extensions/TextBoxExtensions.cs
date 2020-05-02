using System;
using System.Windows.Forms;
using Downloader.Utils;

namespace Downloader.Extensions
{
    public static class TextBoxExtensions
    {
        private delegate void SafeCallDelegate(string text);

        public static void Append(this TextBox box, string line)
        {
            if (box.InvokeRequired)
            {
                var d = new SafeCallDelegate(box.Append);
                box.Invoke(d, new object[] { line });
            }
            else
            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    box.AppendText(AppendLine(line));
                    return;
                }

                box.AppendText(Environment.NewLine);
                box.AppendText(AppendLine(line));
            }
        }

        private static string AppendLine(string line)
        {
            return $"{Helper.GetLogTime()} {line}";
        }
    }
}