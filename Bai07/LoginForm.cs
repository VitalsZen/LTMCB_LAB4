using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Bai07
{
    public static class Tokens // lưu thông tin của token kiểm duyệt
    {
        public static string TokenType {  get; set; }
        public static string AccessToken {  get; set; }
    }

    public static class User //class dùng để lưu thông tin logged in user
    { 
        public static string LogginUser { get; set; }
    }

    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await ConnectToApiAsync(); 
        }

        private async Task ConnectToApiAsync()
        {
            string url = "https://nt106.uitiot.vn/auth/token"; 
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(username), "username");
            formData.Add(new StringContent(password), "password");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Send a POST request with the form data
                    HttpResponseMessage response = await client.PostAsync(url, formData);
                    string responseContent = await response.Content.ReadAsStringAsync(); 

                    if (response.IsSuccessStatusCode) // 200 code
                    {
                        User.LogginUser = username; // lưu thông tin logginuser
                        
                        var jsonResponse = JObject.Parse(responseContent);
                        Tokens.TokenType = jsonResponse["token_type"].ToString();
                        Tokens.AccessToken = jsonResponse["access_token"].ToString();
                        
                        MessageBox.Show("Đăng nhập thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                        
                        this.Hide(); // mở MainForm
                        var mainForm = new MainForm();
                        mainForm.Show();
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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
        }
    }

}


