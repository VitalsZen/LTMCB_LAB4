using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Bai04 //form mở webview dựa vào url input
{
    public partial class MovieDetailForm : Form
    {
        public MovieDetailForm(string url)
        {
            InitializeComponent();
            webView.Source = new Uri(url);
        }

        private async void MovieDetailForm_Load(object sender, EventArgs e)
        {
            await webView.EnsureCoreWebView2Async(null);
        }
    }
}
