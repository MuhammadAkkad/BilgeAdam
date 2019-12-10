using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            // add movies title to the lable
            lblMovieLable.Text = movie.Name;

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

            //string des = getDescription();
            //txtDescription.Text = movie.Description;


            txtDescription.Text = getDescription();
            //lbDirectors.Items.Add(directors);

            //List<string> writers = new List<string>();
            //writers = getWriters();

            //List<string> stars = new List<string>();
            //stars = getStars();



            //string htmlCode;

            //using (WebClient client = new WebClient())
            //{
            //    htmlCode = client.DownloadString(link);
            //}
            //foreach (Match m in Regex.Matches(htmlCode, "\"name\":\\s\"(.*)\""))
            //{
            //    // MessageBox.Show(m.Groups[1].Value);
            //}




        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMovieLable_Click(object sender, EventArgs e)
        {
           
        }

        public List<string> getDirectors() {
            string htmlCode;
            List<string> directors = new List<string>();

            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString("https://www.imdb.com"+link);
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
            foreach (Match m in Regex.Matches(htmlCode, "\n\" >(.*)</a> "))
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



        // count word
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
        // get substring 
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
        // delete
        string delete(string strSource, string deleteWord)
        {
            int start;

            start = strSource.IndexOf(deleteWord) + deleteWord.Length;
            return strSource = strSource.Substring(start);

        }

        private void lbDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
