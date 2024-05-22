using System.Net;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            rtbGetContent.Text = getHTML(tbGetUrl.Text);
            getHTMLFile(tbGetUrl.Text, tbDownloadUrl.Text);
        }

        private string getHTML(string szUrl) //lấy và đọc nội dung file HTML bàng lớp WebRequest
        {
            WebRequest request = WebRequest.Create(szUrl);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(dataStream);
            string responseFromServer = sr.ReadToEnd();

            response.Close();
            return responseFromServer;

        }
        private void getHTMLFile(string Url, string FileUrl) //lưu nội dung file HTML bàng lớp WebClient
        {
            WebClient myclient = new WebClient();
            Stream response = myclient.OpenRead(Url);
            myclient.DownloadFile(Url, FileUrl);
        }
    }
}
