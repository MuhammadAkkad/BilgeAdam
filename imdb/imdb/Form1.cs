using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace imdb
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<imdbContext>());
        }
        Movie movie = new Movie();
        List<Movie> movieList = new List<Movie>();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbListResult.Items.Clear();
            string search = txtLink.Text;
            WebClient wc = new WebClient();
            string result = wc.DownloadString("https://www.imdb.com/find?ref_=nv_sr_fn&q=" + search + "&s=all");

            int firstIndex, lastIndex;

            firstIndex = result.IndexOf("\"findList\"");
            string slimmedString = result.Substring(firstIndex);
            firstIndex = slimmedString.IndexOf("\"findList\"") + "\"findList\"".Length;
            lastIndex = slimmedString.IndexOf("</table>");
            result = slimmedString.Substring(firstIndex, lastIndex);

            string[] result_text = result.Split('"', '"');

            int count = 0;
            foreach (var item in result_text)
            {
                if (item == "result_text")
                {
                    count++;
                }
            }
            for (int i = 1; i <= count; i++)
            {

                Movie movie = new Movie();
                int resultIndex = result.IndexOf("<td class=\"result_text\"> <a href=\"") + "<td class=\"result_text\"> <a href=\"".Length;
                string newResult = result.Substring(resultIndex);
                int hrefStart = newResult.IndexOf("\"");
                string link = newResult.Substring(0, hrefStart);
                movie.Link = link;
                result = newResult.Remove(0, link.Length + 3);

                int startIndex = result.IndexOf("</a>");
                string title = result.Substring(0, startIndex);
                movie.Name = title;

                result = result.Remove(0, title.Length + 6);

                int yearIndex = result.IndexOf(")");
                string year = result.Substring(0, yearIndex);
                //movie.year = year;
                movieList.Add(movie);

            }
            foreach (var item in movieList)
            {
                lbListResult.Items.Add(item.Name);
            }
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbListResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void lbListResult_Click(object sender, EventArgs e)
        {
            int movieIndex = lbListResult.SelectedIndex;
            movie = movieList[movieIndex];
            MovieDetailsForm mdf = new MovieDetailsForm(movie);            
            mdf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //<img alt = "(.*)" class="
        //<a href = "/title/(.*)" > < img alt

        Movie movie100 = new Movie();
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
    }
}




