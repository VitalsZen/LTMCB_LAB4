using System.Net;

namespace Lab04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e)
        {
            //TestGetAllEndPointWithUrl(tbGetUrl.Text);
            rtbGetContent.Text = getHTML(tbGetUrl.Text);
        }

        private string getHTML(string szUrl) //lấy nội dung html
        {
            WebRequest request = WebRequest.Create(szUrl);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(dataStream);
            string responseFromServer = sr.ReadToEnd();
            
            response.Close();
            return responseFromServer;
            
        }

        //public void TestGetAllEndPoint(string Url)
        //{
        //    // Create Http Client 
        //    HttpClient client = new HttpClient();
        //    // Create request and execute it
        //    client.GetAsync(Url).Wait();
            
        //    //Close the connection
        //    client.Dispose();
        //}
        //public void TestGetAllEndPointWithUrl(string Url) //request Get sử dụng httpclient
        //{
        //    // Create Http Client 
        //    HttpClient client = new HttpClient();

        //    // Create request and execute it
        //    Uri getUrl = new Uri(Url);

        //    // Extract response content 
        //    Task<HttpResponseMessage> httpresponse = client.GetAsync(getUrl);
        //    HttpResponseMessage response = httpresponse.Result;

        //    // Write down response content
        //    rtbGetContent.Text = response.ToString();

        //    //Close the connection
        //    client.Dispose();
        //}
    }
}
