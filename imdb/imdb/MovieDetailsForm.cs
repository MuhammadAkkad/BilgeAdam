using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
            lblMovieLable.Text = movie.Name + " (" + getYear().Year.ToString() + ") ";
            txtDescription.Text = getDescription();
            lblRank.Text = getRank();
            getPoster(imgMovie);

            movie.Description = txtDescription.Text;
            movie.Name = lblMovieLable.Text;
            movie.Photo = imgMovie.Image;
            movie.Rank = lblRank.Text;
            movie.Year = getYear();

            List<string> directors = new List<string>();
            directors = getDirectors();
            foreach (var item in directors)
            {
                lbDirectors.Items.Add(item);
            }

            List<string> writers = new List<string>();
            writers = getWriters();
            foreach (var item in writers)
            {
                lbWriters.Items.Add(item);
            }

            List<string> stars = new List<string>();
            stars = getStars();
            foreach (var item in stars)
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

        public List<string> getDirectors()
        {
            string htmlCode;
            List<string> directors = new List<string>();

            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com" + link);
            }
            htmlCode = getBetween(htmlCode, "director", "creator");
            foreach (Match m in Regex.Matches(htmlCode, "\"name\":\\s\"(.*)\""))
            {
                directors.Add(m.Groups[1].Value);
            }
            return directors;
        }
        public List<string> getWriters()
        {
            string htmlCode;
            List<string> writers = new List<string>();

            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com" + link);
            }
            htmlCode = getBetween(htmlCode, "Writers", "summary");
            // TODO: fix 
            foreach (Match m in Regex.Matches(htmlCode, ">(.*)</a>"))
            {
                writers.Add(m.Groups[1].Value);
            }
            return writers;
        }
        public List<string> getStars()
        {
            string htmlCode;
            List<string> stars = new List<string>();

            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com" + link);
            }
            htmlCode = getBetween(htmlCode, "actor", "director");
            foreach (Match m in Regex.Matches(htmlCode, "\"name\":\\s\"(.*)\""))
            {
                stars.Add(m.Groups[1].Value);
            }
            return stars;
        }
        public string getDescription()
        {
            string htmlCode;
            string desc;

            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com" + link);
            }
            return htmlCode = getBetween(htmlCode, "<meta name=\"description\" content=\"", "\" />");
        }
        public string getRank()
        {
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com" + link);
            }
            htmlCode = getBetween(htmlCode, "ratingValue\": \"", "\"");

            return htmlCode;
        }
        public PictureBox getPoster(PictureBox pictureBox) {

            string htmlCode;
            using (WebClient client = new WebClient())
            {
            htmlCode = client.DownloadString("https://www.imdb.com" + link);                
            htmlCode = getBetween(htmlCode, "<link rel='image_src' href=\"", "/>");                
                client.DownloadFile(htmlCode, @"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg");
                pictureBox.Image = Image.FromFile(@"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + lblMovieLable.Text + ".jpg");
            }
            return pictureBox;
        }
        public DateTime getYear() {
            string date;
            string htmlCode;
            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com" + link);
            }
            date = getBetween(htmlCode, "datePublished\": \"", "\",");
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
    }
}
