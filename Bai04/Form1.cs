using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Bai04
{
    public partial class Form1 : Form
    {
        private FlowLayoutPanel movieFlowPanel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Hàm định dạng các controls mới khi load Form
        {
            movieFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown, //Đẩy các panel theo chiều hướng xuống 
                WrapContents = false 
            };
            Controls.Add(movieFlowPanel);

            progressBar = new ProgressBar
            {
                Dock = DockStyle.Top,
                Maximum = 100,
                Value = 0
            };
            Controls.Add(progressBar);

            LoadMoviesAsync(); // Gọi hàm 
        }

        private async Task LoadMoviesAsync() // Hàm điều hướng các hàm con trong quá trình load phim
        {
            try
            {
                var movies = await FetchMoviesAsync(); // triết xuất dữ liệu phim
                SaveMoviesToJson(movies); // lưu dữ liệu phim thành file json về máy
                DisplayMovies(movies); // Load phim lên Mainform từ dữ liệu file json
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async Task<List<Movie>> FetchMoviesAsync() // triết xuSất phim
        {
            var movies = new List<Movie>();
            string url = "https://betacinemas.vn/phim.htm";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url); // request GET cho url

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(response); // Load file html

            var MoviesNode = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4 col-md-4 col-sm-8 col-xs-16 pad" +
                "ding-right-30 padding-left-30 padding-bottom-30')]");
            //lấy node của movie
            if (MoviesNode == null || MoviesNode.Count == 0)
            {
                throw new Exception("No movies found. The XPath query did not return any results.");
            }

            progressBar.Maximum = MoviesNode.Count;
            progressBar.Value = 0;

            foreach (var node in MoviesNode) // triết xuất node con từ node của MoviesNode
            {
                var titleNode = node.SelectSingleNode(".//h3/a"); // xác định node "Tiêu đề phim"
                var linkNode = node.SelectSingleNode(".//h3/a");// xác định node "link truy cập"
                var imgNode = node.SelectSingleNode(".//img[@class='img-responsive border-radius-20']"); //xác định node "hình ảnh"

                if (titleNode != null && linkNode != null && imgNode != null)
                {
                    var detailUrl = "https://betacinemas.vn" + linkNode.Attributes["href"].Value;
                    var detailResponse = await client.GetStringAsync(detailUrl);
                    var detailDoc = new HtmlAgilityPack.HtmlDocument();
                    detailDoc.LoadHtml(detailResponse);

                    var genreNode = detailDoc.DocumentNode.SelectSingleNode("//ul[@class='list-unstyled font-lg font-family-san font-sm-15 font-xs-14']/li[1]");
                    var durationNode = detailDoc.DocumentNode.SelectSingleNode("//ul[@class='list-unstyled font-lg font-family-san font-sm-15 font-xs-14']/li[2]"); 
                    // xác định các node thể loại và thời lượng xem nhưng không load lên được 
                    //var genre = genreNode?.InnerText.Replace("Thể loại:", "").Trim(); 
                    //var durationText = durationNode?.InnerText.Replace("Thời lượng:", "").Replace("phút", "").Trim();
                    //int.TryParse(durationText, out int duration);

                    var movie = new Movie
                    {
                        Title = titleNode.InnerText.Trim(),
                        DetailUrl = detailUrl,
                        ImageUrl = imgNode.Attributes["src"].Value,
                        //Duration = duration,
                        //Genre = genre ?? "N/A"
                    };
                    movies.Add(movie);
                }
                progressBar.Value++; // ++ progressbar với mỗi node của 1 phim load hoàn thành
            }
            return movies;
        }

        private void SaveMoviesToJson(List<Movie> movies) //lưu thông tin phim vào file 
        {
            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            System.IO.File.WriteAllText("movies.json", json);
        }

        private void DisplayMovies(List<Movie> movies) // show các phim 
        {
            foreach (var movie in movies)
            { // định dạng các controls trong panel 
                var pictureBox = new PictureBox
                {
                    ImageLocation = movie.ImageUrl,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 150,
                    Height = 200,
                    Dock = DockStyle.Left, 
                    Cursor = Cursors.Hand
                };

                var LabelCha = new Label
                {
                    Text = movie.Title.Trim(),
                    Font = new Font("Arial", 19F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    ForeColor = Color.FromArgb(0, 192, 0),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Top,
                    Padding = new Padding(10),
                    Cursor = Cursors.Hand
                };

                var Labelcon = new Label
                {
                    Text = $"{movie.DetailUrl}",
                    Font = new Font("Arial", 13F, FontStyle.Italic, GraphicsUnit.Point, 0),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10),
                    Cursor = Cursors.Hand
                };

                var panel = new Panel
                {
                    Width = movieFlowPanel.ClientSize.Width - 20,
                    Height = 250,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };

                panel.Controls.Add(Labelcon);
                panel.Controls.Add(LabelCha);
                panel.Controls.Add(pictureBox);

                // các event của label + picturebox
                Labelcon.MouseEnter += (sender, e) => // rê chuột vào là gạch dưới với in nghiêng
                {
                    Labelcon.Font = new Font(Labelcon.Font, FontStyle.Italic | FontStyle.Underline);
                };
                Labelcon.MouseLeave += (sender, e) => // quay về bình thường
                {
                    Labelcon.Font = new Font(Labelcon.Font, FontStyle.Italic);
                };
                Labelcon.Click += (sender, e) =>
                {
                    ShowMovieDetail(movie.DetailUrl);
                };
                // tương tự Label con
                LabelCha.MouseEnter += (sender, e) => 
                {
                    LabelCha.Font = new Font(LabelCha.Font, FontStyle.Bold | FontStyle.Underline);
                };
                LabelCha.MouseLeave += (sender, e) =>
                {
                    LabelCha.Font = new Font(LabelCha.Font, FontStyle.Bold);
                };
                LabelCha.Click += (sender, e) =>
                {
                    ShowMovieDetail(movie.DetailUrl);
                };

                pictureBox.Click += (sender, e) =>
                {
                    ShowMovieDetail(movie.DetailUrl);
                };

                movieFlowPanel.Controls.Add(panel);
            }
        }

        private void ShowMovieDetail(string detailUrl)
        {
            var movieDetailForm = new MovieDetailForm(detailUrl);
            movieDetailForm.Show();
        }
    }

    public class Movie // Class để lưu trữ thông tin triết xuất của phim từ web
    {
        public string Title { get; set; }
        public string DetailUrl { get; set; }
        public string ImageUrl { get; set; }
        public int Duration { get; set; } // Thời lượng phim (phút)
        public string Genre { get; set; } // Thể loại phim
    }
}
