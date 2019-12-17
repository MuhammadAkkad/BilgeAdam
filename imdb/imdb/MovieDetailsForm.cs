using Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace imdb
{
    public partial class MovieDetailsForm : Form
    {
        string link;
        Movie movie;
        WebClient client = new WebClient();
        imdbServices service = new imdbServices();
        List<string> directorList = new List<string>();
        List<string> writerList = new List<string>();
        List<string> starList = new List<string>();
        public MovieDetailsForm()
        {
            InitializeComponent();
        }
        public MovieDetailsForm(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            link = movie.Link;
        }
        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
            string htmlCode = client.DownloadString("https://www.imdb.com" + link);
            lblMovieLable.Text = movie.Name;
            txtDescription.Text = service.getDescription(htmlCode);
            lblRank.Text = service.getRank(htmlCode);
            service.getPoster(imgMovie, htmlCode, link);

            movie.Description = txtDescription.Text;
            movie.Name = lblMovieLable.Text;
            movie.Photo = @"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg";
            movie.Rank = lblRank.Text;
            movie.Year = service.getYear(htmlCode);

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
        {}
        private void lblMovieLable_Click(object sender, EventArgs e)
        {}         
        
        private void lbDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lblRank_Click(object sender, EventArgs e)
        {

        }
        private void btnSave2Db_Click(object sender, EventArgs e)
        {
            imdbContext ctx = new imdbContext();

            if (ctx.Movies.Any(m => m.Link == movie.Link))
            {
                MessageBox.Show("Movie already exists");
            }
            else
            {
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
                foreach (var director in directorList)
                {
                    service.AddCast("Director", director, movie.Name);
                }

                foreach (var writer in writerList)
                {
                    service.AddCast("Writer", writer, movie.Name);
                }

                foreach (var star in starList)
                {
                    service.AddCast("Star", star, movie.Name);
                }
                MessageBox.Show("Movie added successfully");
            }
            this.Close();
        }

    }
}
