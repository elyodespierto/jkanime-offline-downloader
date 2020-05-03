using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloader.Utils
{
    public static class WebBrowserExtensions
    {
        public static Task NavigateAsync(this WebBrowser browser, string url)
        {
            var manualEvent = new ManualResetEvent(false);

            browser.Navigate(url);

            browser.DocumentCompleted += (s, e) => { manualEvent.Set(); };

            return Task.Factory.StartNew((() =>
            {
                manualEvent.WaitOne();
                manualEvent.Reset();
            }));
        }
    }
}