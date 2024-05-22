using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Bai07
{ 
   
    public partial class MainForm : Form
    {
        private List<Food> foodList;
        private int currentUserPage = 1;
        private int currentAllPage = 1;
        private string currentList = "AllFood"; // phân biệt tab thức ăn cộng đồng/ thức ăn tự tạo


        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load); // Load Main Form
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadFoodDataAsync(); // gọi hàm 
        }

        private async Task LoadFoodDataAsync() // Tải dữ liệu món ăn từ API
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new 
                    System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenType, Tokens.AccessToken); // kèm Token vào header để được phê duyệt 

                var requestBody = new
                {
                    current = 1, 
                    pageSize = 5
                }; // nọi dung request 

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/all", content); // thực hiện request HTTP POST với nội dung trên

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    
                    System.IO.File.WriteAllText("food_data.json", jsonResponse); // lưu nội dung nhận được vào file food_data.json

                    
                    var foodResponse = JsonConvert.DeserializeObject<FoodResponse>(jsonResponse);
                    foodList = foodResponse.Data;

                    
                    listBoxFood.Items.Clear();
                    foreach (var food in foodList) // load món ăn lên listbox
                    {
                        listBoxFood.Items.Add(food);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load food data.");
                }
            }
        }

        private void btnRandomFood_Click(object sender, EventArgs e) // Hàm chọn random món ăn tại tab đang hiện hành
        {
            if (foodList != null && foodList.Count > 0) //check foodlist phải khác null và count > 0
            {
                var random = new Random();
                var randomFood = foodList[random.Next(foodList.Count)];
                MessageBox.Show($"Hôm nay ăn: {randomFood.ten_mon_an}\nGiá: {randomFood.gia}\nMô tả: {randomFood.mo_ta}\nĐịa chỉ: {randomFood.dia_chi}");
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu món ăn.");
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e) // Hàm mở form thêm món ăn
        {
            var addFoodForm = new AddFoodForm();
            addFoodForm.Show();
        }

        private async Task LoadUserCreatedFoodAsync(int currentUserPage) // Hàm load món ăn tự tạo
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenType, Tokens.AccessToken);

                var requestBody = new
                {
                    current = currentUserPage, // sử dụng page user hiện tại
                    pageSize = 5
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/my-dishes", content); // request url phù hợp

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var foodResponse = JsonConvert.DeserializeObject<FoodResponse>(jsonResponse);
                    foodList = foodResponse.Data;

                    listBoxFood.Items.Clear();
                    foreach (var food in foodList)
                    {
                        listBoxFood.Items.Add(food);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load user-created food data.");
                }
            }
        }

        private async Task LoadAllFoodAsync(int currentAllPage)// Hàm load món ăn all, tương tự với hàm LoadUserCreatedFoodAsync(int) 
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenType, Tokens.AccessToken);

                var requestBody = new
                {
                    current = currentAllPage, // Use currentAllPage value
                    pageSize = 5
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/all", content); // request url phù hợp

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var foodResponse = JsonConvert.DeserializeObject<FoodResponse>(jsonResponse);
                    foodList = foodResponse.Data;

                    listBoxFood.Items.Clear();
                    foreach (var food in foodList)
                    {
                        listBoxFood.Items.Add(food);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load all food data.");
                }
            }
        }

        private async void btnNext_Click(object sender, EventArgs e) // hàm chuyển sang trang kế tiếp
        { 
            if (currentList == "AllFood") // tùy vào load loại tab nào để có thể chọn số trang phù hợp
            {
                currentAllPage++;
                await LoadAllFoodAsync(currentAllPage);
            }
            else if (currentList == "UserCreatedFood")
            {
                currentUserPage++;
                await LoadUserCreatedFoodAsync(currentUserPage);
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e) // hàm chuyển sang trang trước đó
        {
            if (currentList == "AllFood")
            {
                if (currentAllPage > 1)
                {
                    currentAllPage--;
                    await LoadAllFoodAsync(currentAllPage);
                }
            }
            else if (currentList == "UserCreatedFood")
            {
                if (currentUserPage > 1)
                {
                    currentUserPage--;
                    await LoadUserCreatedFoodAsync(currentAllPage);
                }
            }
        }

        private async void btnUserCreatedFood_Click(object sender, EventArgs e) // hàm load load tab món ăn tự tạo
        {
            currentUserPage = 1;
            currentList = "UserCreatedFood";
            await LoadUserCreatedFoodAsync(currentUserPage);
        }

        private async void btnAllFood_Click(object sender, EventArgs e) //hàm load tab món ăn all
        {
            currentAllPage = 1;
            currentList = "AllFood";
            await LoadAllFoodAsync(currentAllPage);
        }

        private async void btnDeleteFood_Click(object sender, EventArgs e) // hàm xóa món ăn tư tạo 
        {
            if (listBoxFood.SelectedItem is Food selectedFood && selectedFood.nguoi_dong_gop == User.LogginUser) 
                // xét trường hợp món ăn phải được selected và biến global trong namespace hiện tại logginUser phải trùng với nguoi_dong_gop
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Tokens.TokenType, Tokens.AccessToken);

                    var response = await client.DeleteAsync($"https://nt106.uitiot.vn/api/v1/monan/{selectedFood.id}"); // gửi request HTTP DELETE cho API kèm theo id của món ăn được chọn

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var deletedFood = JsonConvert.DeserializeObject<Food>(jsonResponse);

                        MessageBox.Show($"Deleted Food:\n\n" +
                                        $"Tên món ăn: {deletedFood.ten_mon_an}\n" +
                                        $"Giá: {deletedFood.gia}\n" +
                                        $"Mô tả: {deletedFood.mo_ta}\n" +
                                        $"Hình ảnh: {deletedFood.hinh_anh}\n" +
                                        $"Địa chỉ: {deletedFood.dia_chi}\n" +
                                        $"Người đóng góp: {deletedFood.nguoi_dong_gop}");
                        // thông báo toàn bộ thông tin của món ăn mới được xóa
                        
                        // tải lại trang
                        if (currentList == "AllFood") // nếu xóa tại tab món ăn all
                        {
                            await LoadAllFoodAsync(currentAllPage);
                        }
                        else if (currentList == "UserCreatedFood")// nếu xóa tại tab món ăn tự tạo
                        {
                            await LoadUserCreatedFoodAsync(currentUserPage);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete food.");
                    }
                }
            }
            else
            {
                MessageBox.Show("You can only delete food items that you have created.");
            }
        }

    }
    
    public class Food// class Food tạo để phù hợp với bộ thông tin của file json được gửi từ API
    {
        public string id { get; set; } // Add this property to match JSON structure
        public string ten_mon_an { get; set; }
        public double gia { get; set; } // Change this to double
        public string mo_ta { get; set; }
        public string hinh_anh { get; set; }
        public string dia_chi { get; set; }
        public string nguoi_dong_gop { get; set; } // Add this property to match JSON structure

        // Override ToString to display food info in ListBox
        public override string ToString()
        {
            return $"{ten_mon_an} - {gia} VND - {dia_chi} - {nguoi_dong_gop}";
        }
    }

    public class FoodResponse // class phục vụ cho việc load món ăn khi chuyển trang
    {
        public List<Food> Data { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Current { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
