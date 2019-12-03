using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDB
{
    public partial class IMDB : Form
    {
        public IMDB()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            string search = txtSearch.Text;
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


            List<Film> filmList = new List<Film>();
            for (int i = 1; i <= count; i++)
            {

                Film film = new Film();
                int resultIndex = result.IndexOf("<td class=\"result_text\"> <a href=\"") + "<td class=\"result_text\"> <a href=\"".Length;
                string newResult = result.Substring(resultIndex);
                int hrefStart = newResult.IndexOf("\"");
                string link = newResult.Substring(0, hrefStart);
                film.link = link;
                result = newResult.Remove(0, link.Length + 3);

                int startIndex = result.IndexOf("</a>");
                string title = result.Substring(0, startIndex);
                film.name = title;

                result = result.Remove(0, title.Length + 6);

                int yearIndex = result.IndexOf(")");
                string year = result.Substring(0, yearIndex);
                film.year = year;
                filmList.Add(film);

            }
            Film.films = filmList;
            lbFilmList.Items.Clear();
            foreach (var item in filmList)
            {
                lbFilmList.Items.Add(item);
            }
        }

        List<Director> directorsList = new List<Director>();
        List<Writer> writersList = new List<Writer>();
        List<Star> starsList = new List<Star>();
        private void lbFilmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string result;
            lbDescription.Items.Clear();

            

            foreach (var item in Film.films)
            {
                if (item == lbFilmList.SelectedItem)
                {
                    result = wc.DownloadString("https://www.imdb.com" + item.link);

                    int rankIndedx = result.IndexOf("<span itemprop=\"ratingValue\">") + "<span itemprop=\"ratingValue\">".Length;
                    string rank = result.Substring(rankIndedx, 3);
                    item.rank = rank;

                    int descriptionIndex = result.IndexOf("<div class=\"summary_text\">") + "<div class=\"summary_text\">".Length;
                    result = result.Substring(descriptionIndex);

                    int divIndex = result.IndexOf("</div>");
                    string description = result.Substring(0, divIndex).Trim();


                    var firstHalf = description.Substring(0, (int)(description.Length / 2)) + "-";
                    var lastHalf = description.Substring((int)(description.Length / 2), (int)(description.Length / 2));
                    description = null;
                    description = firstHalf + lastHalf;

                    item.description = description;

                    int summaryIndex = result.IndexOf("<div class=\"credit_summary_item\">");
                    result = result.Substring(summaryIndex);
                    string[] items = result.Split('_', '"');
                    int drTag = 0;
                    int wrTag = 0;
                    int smTag = 0;
                    foreach (var word in items)
                    {
                        if (word == "dr")
                        {
                            drTag++;
                        }
                        else if (word == "wr")
                        {
                            wrTag++;
                        }
                        else if (word == "sm")
                        {
                            smTag++;
                        }
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


                   string tmp = getBetween(result, "=\"inline\">Director", "credit_summary_item");
                    int count = getCount(tmp, "href=\"/name");

                    
                    // Get director's link and name
                    for (int i = 0; i < count; i++)
                    {
                        Director d = new Director();
                        string link = getBetween(tmp, "href=\"", "/?");
                        tmp = delete(tmp, "href=");

                        string name = getBetween(tmp, ">", "</a>");
                        tmp = delete(tmp, ">");


                        d.directorLink = link;
                        d.directorName = name;
                       directorsList.Add(d);
                    }
                    
                    // Get directors loop
                    //for (int i = 0; i< drTag; i++)
                    //{
                    //    Director d = new Director();
                    //    int drIndex = result.IndexOf("dr") + 5;
                    //    result = result.Substring(drIndex);
                    //    int directorIndex = result.IndexOf("</a>");
                    //    string directorName = result.Substring(0, directorIndex);
                    //    d.directorName = directorName;
                    //    directorsList.Add(d);
                    //}
                     item.directors = directorsList;

                    // get writers loop
                    for (int i = 0; i < wrTag; i++)
                    {
                        int drIndex = result.IndexOf("wr") + 5;
                        result = result.Substring(drIndex);

                        int writerIndex = result.IndexOf("</a>");
                        string writerName = result.Substring(0, writerIndex);
                        Writer w = new Writer();
                        w.writerName = writerName;
                        writersList.Add(w);
                    }
                    item.writers = writersList;

                    // get stars loop
                    for (int i = 0; i < smTag; i++)
                    {
                        int drIndex = result.IndexOf("sm") + 5;
                        result = result.Substring(drIndex);
                        int starIndex = result.IndexOf("</a>");
                        string starName = result.Substring(0, starIndex);
                        Star s = new Star();
                        s.starName = starName;
                        starsList.Add(s);
                    }
                    item.stars = starsList;

                    // send description and rank to description box
                    lbDescription.Items.Add(description);
                    lbDescription.Items.Add("Rank: " + rank);
                    foreach (var directorName in item.directors)
                    {
                        lbDirectors.Items.Add("Director: " + directorName.directorName);
                    }


                    foreach (var writerName in item.writers)
                    {
                        lbWriters.Items.Add("Writers: " + writerName.writerName);
                    }


                    foreach (var starName in item.stars)
                    {
                        lbStars.Items.Add("Stars: " + starName.starName);
                    }

                }
            }
        }

        private void lbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbDirectors.SelectedIndex;
            string link = directorsList[index].directorLink;
            string name = directorsList[index].directorName;


        }

        private void lbWriters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbStars_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {

        }
    }
}
