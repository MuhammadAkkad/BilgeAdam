using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace imdb
{

    public partial class MovieDetailsForm : Form
    {
        string link;
        public MovieDetailsForm()
        {
            InitializeComponent();
        }
        Movie movie;
        public MovieDetailsForm(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            link = movie.Link;
        }

        List<string> directorInsert = new List<string>();
        List<string> writerInsert = new List<string>();
        List<string> starInsert = new List<string>();

        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
            string htmlCode = client.DownloadString("https://www.imdb.com" + link);
            lblMovieLable.Text = movie.Name + " (" + getYear(htmlCode).Year.ToString() + ") ";
            txtDescription.Text = getDescription(htmlCode);
            lblRank.Text = getRank(htmlCode);
            getPoster(imgMovie, htmlCode);

            movie.Description = txtDescription.Text;
            movie.Name = lblMovieLable.Text;
            movie.Photo = @"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg";
            movie.Rank = lblRank.Text;
            movie.Year = getYear(htmlCode);

            directorInsert = getDirectors(htmlCode);
            foreach (var item in directorInsert)
            {
                lbDirectors.Items.Add(item);
            }

            writerInsert = getWriters(htmlCode);
            foreach (var item in writerInsert)
            {
                lbWriters.Items.Add(item);
            }

            starInsert = getStars(htmlCode);
            foreach (var item in starInsert)
            {
                lbStars.Items.Add(item);
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
        private void lblMovieLable_Click(object sender, EventArgs e)
        {

        }




            
public List<string> getDirectors(string htmlCode)
        {
            string html = htmlCode;
            List<string> directors = new List<string>();
            html = getBetween(html, "director", "creator");
            foreach (Match m in Regex.Matches(html, "\"name\":\\s\"(.*)\""))
            {
                directors.Add(m.Groups[1].Value);
            }
            return directors;
        }
        public List<string> getWriters(string htmlCode)
        {
            string html= htmlCode;
            List<string> writers = new List<string>();
            html = getBetween(html, "Writers", "summary");
            foreach (Match m in Regex.Matches(html, ">(.*)</a>"))
            {
                writers.Add(m.Groups[1].Value);
            }
            return writers;
        }
        public List<string> getStars(string htmlCode)
        {
            string html = htmlCode;
            List<string> stars = new List<string>();
            html = getBetween(html, "actor", "director");
            foreach (Match m in Regex.Matches(html, "\"name\":\\s\"(.*)\""))
            {
                stars.Add(m.Groups[1].Value);
            }
            return stars;
        }
        public string getDescription(string htmlCode)
        {
            string html= htmlCode;
            return html = getBetween(html, "<meta name=\"description\" content=\"", "\" />");
        }
        public string getRank(string htmlCode)
        {
            string html = htmlCode;
            html = getBetween(html, "ratingValue\": \"", "\"");

            return html;
        }
        public PictureBox getPoster(PictureBox pictureBox, string htmlCode)
        {

            string html = htmlCode;
                html = client.DownloadString("https://www.imdb.com" + link);
                html = getBetween(html, "<link rel='image_src' href=\"", "/>");
                client.DownloadFile(html, @"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg");
                pictureBox.Image = Image.FromFile(@"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg");
            return pictureBox;
        }
        public DateTime getYear(string htmlCode)
        {
            string date;
            string html = htmlCode;
            date = getBetween(html, "datePublished\": \"", "\"");
            DateTime oDate = Convert.ToDateTime(date);
            return oDate;
        }
        int getCount(string source1, string word)
        {

            string word1 = word;
            string source = source1;

            int wordSize = word1.Length;
            int sourceSize = source.Length;

            string sourceNewSize = source.Replace(word1, "");
            int newSizeSource = sourceNewSize.Length;

            return (sourceSize - newSizeSource) / wordSize;

        }
        string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "Not Found!!";
            }
        }
        string delete(string strSource, string deleteWord)
        {
            int start;

            start = strSource.IndexOf(deleteWord) + deleteWord.Length;
            return strSource = strSource.Substring(start);

        }
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
                foreach (var director in directorInsert)
                {
                    AddCast("Director", director, movie.Name);
                }

                foreach (var writer in writerInsert)
                {
                    AddCast("Writer", writer, movie.Name);
                }

                foreach (var star in starInsert)
                {
                    AddCast("Star", star, movie.Name);
                }
                MessageBox.Show("Movie added successfully");
            }
            this.Close();
        }
        void AddCast(string role, string castName , string movieName) {
            imdbContext ctx = new imdbContext();
            CastRole castRole = new CastRole();
            MovieCast map = new MovieCast();
            Cast cast = new Cast();

            castRole.Role = role;
            if (!ctx.castRoles.Any(c => c.Role == castRole.Role))
            {
                ctx.castRoles.Add(castRole);
                ctx.SaveChanges();
            }

            cast.Name = castName;

            if (!ctx.Casts.Any(c => c.Name == cast.Name))
            {
                ctx.Casts.Add(cast);
                ctx.SaveChanges();
            }

            map.CastId = ctx.Casts.Where(c => c.Name == cast.Name).Select(c => c.CastId).FirstOrDefault();
            map.CastRoleId = ctx.castRoles.Where(c => c.Role == castRole.Role).Select(c => c.CastRoleId).FirstOrDefault();
            map.MovieId = ctx.Movies.Where(m => m.Name == movieName).Select(m => m.MovieId).FirstOrDefault();
            ctx.MovieCasts.Add(map);
            ctx.SaveChanges();
        }
        WebClient client = new WebClient();

    }
}
