using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var registerInfo = new // thu thập set thông tin
            {
                username = txtUsername.Text,
                email = txtEmail.Text,
                password = txtPassword.Text,
                first_name = txtFirstName.Text,
                last_name = txtLastName.Text,
                sex = int.Parse(txtSex.Text),
                birthday = dateTimePickerBirthday.Value.ToString("yyyy-MM-dd"),
                language = txtLanguage.Text,
                phone = txtPhone.Text
            };

            string json = JsonConvert.SerializeObject(registerInfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient()) // chuyển đổi thông tin trên thành json file sau đó gửi resquest HTTP POST cho API 
            {
                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/user/signup", data);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại!");
                }
            }
        }
    }

}
