using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai06
{
    public partial class Form1 : Form
    {
        // các biến lưu token
        private string accessToken; 
        private string tokenType;
        public Form1()
        {
            InitializeComponent();
        }

        
        private async void btConnect_Click(object sender, EventArgs e) 
        {
            await ConnectToApiAsync(); // Gọi hàm connect tới API chỉ định
        }

        
        private async Task ConnectToApiAsync()
        {
            // Lưu thông tin url, username, password
            string url = tbUrl.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            // tạo Data lƯu thông tin trên
            var Data = new MultipartFormDataContent();
            Data.Add(new StringContent(username), "username");
            Data.Add(new StringContent(password), "password");

            try
            {
                using (HttpClient client = new HttpClient()) 
                {
                    
                    HttpResponseMessage response = await client.PostAsync(url, Data); // gửi request cho API
                    string responseContent = await response.Content.ReadAsStringAsync(); // Đọc nội dung API trả về

                    if (response.IsSuccessStatusCode)
                    {
                        // Chuyển đổi file nhận được thành file json ( NewstoSoft.Json) 
                        var jsonResponse = JObject.Parse(responseContent);
                        tokenType = jsonResponse["token_type"].ToString();
                        accessToken = jsonResponse["access_token"].ToString();

                        rtbContent.Text = $"{tokenType} {accessToken}";
                        MessageBox.Show("Đăng nhập thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                    else
                    {
                        var jsonResponse = JObject.Parse(responseContent);
                        string detail = jsonResponse["detail"].ToString();
                        MessageBox.Show(detail, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private async void btGetUserInfo_Click(object sender, EventArgs e)
        {
            await GetUserInfoAsync();
        }

        private async Task GetUserInfoAsync() // Hàm lấy thông tin User
        {
            if (string.IsNullOrEmpty(accessToken)) //Kiểm tra đăng nhập chưa ( đăng nhập rồi -> Có token )
            {
                MessageBox.Show("Bạn cần đăng nhập trước", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string url = "https://nt106.uitiot.vn/api/v1/user/me"; // url API mục tiêu

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Thêm header của request bằng Token để được phê duyệt cho lần request này
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

                    
                    HttpResponseMessage response = await client.GetAsync(url); //Gửi yêu câu GET 
                    string responseContent = await response.Content.ReadAsStringAsync(); 

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = JObject.Parse(responseContent);
                        string userInfo = $"User Info:\n" +
                                          $"Id: {jsonResponse["id"]}\n" +
                                          $"Username: {jsonResponse["username"]}\n" +
                                          $"Email: {jsonResponse["email"]}\n" +
                                          $"Email Verified: {jsonResponse["email_verified"]}\n" +
                                          $"First Name: {jsonResponse["first_name"]}\n" +
                                          $"Last Name: {jsonResponse["last_name"]}\n" +
                                          $"Avatar: {jsonResponse["avatar"]}\n" +
                                          $"Sex: {jsonResponse["sex"]}\n" +
                                          $"Birthday: {jsonResponse["birthday"]}\n" +
                                          $"Language: {jsonResponse["language"]}\n" +
                                          $"Phone: {jsonResponse["phone"]}\n" +
                                          $"Phone Verified: {jsonResponse["phone_verified"]}\n" +
                                          $"Is Active: {jsonResponse["is_active"]}\n" +
                                          $"Is Superuser: {jsonResponse["is_superuser"]}";
                        rtbContent.Text = userInfo; // Display user info in the RichTextBox
                    }
                    else
                    {
                        var jsonResponse = JObject.Parse(responseContent);
                        string detail = jsonResponse["detail"].ToString();
                        MessageBox.Show(detail, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show exception message
            }
        }


    }
}
