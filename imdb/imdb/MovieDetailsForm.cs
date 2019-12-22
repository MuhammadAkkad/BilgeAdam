using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace imdb
{
    public partial class MovieDetailsForm : Form
    {
        string link;
        MovieDTO movieDTO = new MovieDTO();
        WebClient client = new WebClient();
        imdbServices service = new imdbServices();
        MovieService movieService = new MovieService();
        CastService castService = new CastService();
        List<string> directorList = new List<string>();
        List<string> writerList = new List<string>();
        List<string> starList = new List<string>();
        public MovieDetailsForm()
        {
            InitializeComponent();
        }
        public MovieDetailsForm(MovieDTO movieDTO)
        {
            InitializeComponent();
            this.movieDTO = movieDTO;
            link = movieDTO.Link;
        }
        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
            string htmlCode = client.DownloadString("https://www.imdb.com" + link);
            lblMovieLable.Text = movieDTO.Name;
            txtDescription.Text = service.getDescription(htmlCode);
            lblRank.Text = service.getRank(htmlCode);
            service.getPoster(imgMovie, htmlCode, movieDTO);

            movieDTO.Description = txtDescription.Text;
            movieDTO.Name = lblMovieLable.Text;
            movieDTO.Photo = @"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg";
            movieDTO.Rank = lblRank.Text;
            movieDTO.Year = service.getYear(htmlCode);

            directorList = service.getDirectors(htmlCode);
            foreach (var item in directorList)
            {
                lbDirectors.Items.Add(item);
            }

            writerList = service.getWriters(htmlCode);
            foreach (var item in writerList)
            {
                lbWriters.Items.Add(item);
            }

            starList = service.getStars(htmlCode);
            foreach (var item in starList)
            {
                lbStars.Items.Add(item);
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        { }
        private void lblMovieLable_Click(object sender, EventArgs e)
        { }
        private void lbDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lblRank_Click(object sender, EventArgs e)
        {

        }
        private void btnSave2Db_Click(object sender, EventArgs e)
        {
            
            var MovieJson = new JavaScriptSerializer().Serialize(movieDTO);

            string result = movieService.Add(MovieJson);
            foreach (var director in directorList)
            {
                castService.Add("Director", director, movieDTO.Name);
            }
            foreach (var writer in writerList)
            {
                castService.Add("Writer", writer, movieDTO.Name);
            }
            foreach (var star in starList)
            {
                castService.Add("Star", star, movieDTO.Name);
            }
            MessageBox.Show(result);
            this.Close();
        }

        private void imgMovie_Click(object sender, EventArgs e)
        {

        }
    }
}
