using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace imdb
{
    public partial class ViewForm : Form
    {
        static List<MovieDTO> movies;
        List<string> casts = new List<string>();
        MovieService MovieServices = new MovieService();
        CastService castServices = new CastService();
        MovieDTO movieDTO = new MovieDTO();
        int Director = 18;
        int Writer = 19;
        int Star = 20;

        public ViewForm()
        {
            InitializeComponent();
        }
        public List<MovieDTO> GetAllMovies()
        {
            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/");
                //HTTP GET
                var responseTask = client.GetAsync("values");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var movies = readTask.Result;
                    movieDTOs = new JavaScriptSerializer().Deserialize<List<MovieDTO>>(movies);
                }
            }
            return movieDTOs;
        }

        private void lbMovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int movieIndex = lbMovieList.SelectedIndex;
            movieDTO = movies[movieIndex];
            txtTitle.Text = movieDTO.Name;
            txtRank.Text = movieDTO.Rank;
            txtYear.Text = movieDTO.Year.ToString();
            rtDesc.Text = movieDTO.Description;
            pbPoster.ImageLocation = movieDTO.Photo;

            string json = castServices.GetCasts(movieDTO, Director);
            lbDirectors.Items.Clear();
            casts = new JavaScriptSerializer().Deserialize<List<string>>(json);
            foreach (var item in casts)
            {
                lbDirectors.Items.Add(item);
            }

            json = castServices.GetCasts(movieDTO, Writer);
            lbWriters.Items.Clear();
            casts = new JavaScriptSerializer().Deserialize<List<string>>(json);
            foreach (var item in casts)
            {
                lbWriters.Items.Add(item);
            }

            json = castServices.GetCasts(movieDTO, Star);
            lbStars.Items.Clear();
            casts = new JavaScriptSerializer().Deserialize<List<string>>(json);
            foreach (var item in casts)
            {
                lbStars.Items.Add(item);
            }
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            movies = GetAllMovies();
            foreach (var item in movies)
            {
                lbMovieList.Items.Add(item.Name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var json = new JavaScriptSerializer().Serialize(movieDTO);
            MovieServices.Delete(json);
            ViewForm viewForm = new ViewForm();
            viewForm.Close();
        }
    }
}

