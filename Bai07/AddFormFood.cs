using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Bai07
{
    public partial class AddFoodForm : Form
    { 
        public AddFoodForm()
        {
            InitializeComponent();
        }

        private async void btnAddFood_Click(object sender, EventArgs e) //thu thap thong tin can thiet
        {
            var foodInfo = new
            {
                ten_mon_an = txtFoodName.Text,
                gia = int.Parse(txtPrice.Text),
                mo_ta = txtDescription.Text,
                hinh_anh = txtImage.Text,
                dia_chi = txtAddress.Text,
            };

            string json = JsonConvert.SerializeObject(foodInfo);// convert set thong tin tren thanh json 
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // json ->string

            using (HttpClient client = new HttpClient())
            {
                // thêm header để được phê duyệt
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenType, Tokens.AccessToken);

                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/add", data);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm món ăn thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm món ăn thất bại!");
                }
            }
        }
    }
}
