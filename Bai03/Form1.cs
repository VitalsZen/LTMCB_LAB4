using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using HtmlAgilityPack;
namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize); // thay đổi kích thước Form

            //webView21.NavigationStarting += EnsureHttps; // các lệnh điều hướng webview để truy cập các url an toàn
            //InitializeAsync();
        }

        //async void InitializeAsync() // hàm báo cảnh báo khi truy cập url không an toàn 
        //{
        //    await webView21.EnsureCoreWebView2Async(null);
        //    webView21.CoreWebView2.WebMessageReceived += UpdateAddressBar;

        //    await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
        //    await webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        //}
        private void Form_Resize(object sender, EventArgs e) // Đổi kích thước giao diện các controls Skhi kích thước form thay đổi
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            btConnect.Left = this.ClientSize.Width - btConnect.Width;
            tbConnectUrl.Width = btConnect.Left - tbConnectUrl.Left;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (webView21 != null && webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate(tbConnectUrl.Text);
            }
        }

        //void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args) // Hàm ngăn chặn truy cập các url không an toàn - không sử dụng 
        //{
        //    String uri = args.Uri;
        //    if (!uri.StartsWith("https://"))
        //    {
        //        webView21.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
        //        args.Cancel = true;
        //    }
        //}
        /*void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)*/ // hàm thu nhận thông tin trả về từ web khi truy cập vào - không sử dụng 
        //{
        //    String uri = args.TryGetWebMessageAsString();
        //    tbConnectUrl.Text = uri;
        //    webView21.CoreWebView2.PostWebMessageAsString(uri);
        //}

        private void btDownloadHTMLContent_Click(object sender, EventArgs e) // Hàm event click dùng để tải các file HTML
        {
            // tạo tên file json để lưu về máy ( ví dụ: https://uit.edu.vn -> uit.edu.vn.json ) 
            string SaveUrl = tbConnectUrl.Text.Replace("https://", "").Replace("/", "") + ".html";
            getHTMLFile(tbConnectUrl.Text, SaveUrl); // gọi hàm 
            MessageBox.Show("HTML file downloaded as " + SaveUrl);
        }
        private void getHTMLFile(string Url, string FileUrl) // Hàm dùng để lưu file html của url chỉ định vào
                                                             // về đường dẫn trên máy tính Fileurl
        {
            WebClient myclient = new WebClient();
            Stream response = myclient.OpenRead(Url);
            myclient.DownloadFile(Url, FileUrl);
        }

        private void btDownloadResource_Click(object sender, EventArgs e) // Hàm event click dùng để tải
                                                                          // các hình ảnh đang sẵn có trên web hiện thời
        {
            string url = tbConnectUrl.Text;
            if (!string.IsNullOrEmpty(url))
            {
                DownloadAllImages(url);
                MessageBox.Show("Images downloaded from " + url);
            }
        }

        private void DownloadAllImages(string url) // hàm dùng để lưu tất cả các node //img của file html của web hiện thời
        {
            var html = new HtmlWeb();
            var document = html.Load(url);

            var imageNodes = document.DocumentNode.SelectNodes("//img");
            if (imageNodes != null)
            {
                foreach (var img in imageNodes)
                {
                    string src = img.GetAttributeValue("src", null);
                    if (!string.IsNullOrEmpty(src))
                    {
                        if (!Uri.IsWellFormedUriString(src, UriKind.Absolute))
                        {
                            Uri baseUri = new Uri(url);
                            Uri absoluteUri = new Uri(baseUri, src);
                            src = absoluteUri.ToString();
                        }
                        DownloadImage(src);
                    }
                }
            }
        }

        private void DownloadImage(string url) // lưu ảnh về máy
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(url);
            string fileName = Path.GetFileName(uri.LocalPath);
            client.DownloadFile(uri, fileName);
        }
    }
}
