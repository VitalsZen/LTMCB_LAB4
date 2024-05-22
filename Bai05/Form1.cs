using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Bai05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btConnect_Click()
        {
            await ConnectToApiAsync();
        }

        private async Task ConnectToApiAsync()// hàm dùng để kết nối đến API
        {
            string url = tbUrl.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            var data = new MultipartFormDataContent(); // chuẩn bi data để kèm theo request
            data.Add(new StringContent(username), "username");
            data.Add(new StringContent(password), "password");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, data);// request HTTP POST đến API
                    string responseContent = await response.Content.ReadAsStringAsync(); 

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = JObject.Parse(responseContent);// nhận token từ API
                        string tokenType = jsonResponse["token_type"].ToString();
                        string accessToken = jsonResponse["access_token"].ToString();

                        rtbContent.Text = $"Bearer {accessToken}";

                        rtbContent.Text += '\n' + "Đăng nhập thành công";
                        MessageBox.Show("Đăng nhập thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                    else
                    {

                        var jsonResponse = JObject.Parse(responseContent);
                        string detail = jsonResponse["detail"].ToString();
                        MessageBox.Show(detail, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btConnect_Click_1(object sender, EventArgs e)
        {
            btConnect_Click();
        }
    }
}
