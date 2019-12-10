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
        /*
private string Title { get; set; }
private int Rank { get; set; }
private DateTime Year { get; set; }
private string Directors { get; set; }
private string Writers { get; set; }
private string Stars { get; set; }
private string Description { get; set; }
private string Url { get; set; }

private string siteUrl = "https://www.imdb.com/title/tt0133093/?ref_=nv_sr_srsg_0";
public string[] QueryTerms { get; } = { "Ocean", "Nature", "Pollution" };

internal async void ScrapeWebsite()
{
CancellationTokenSource cancellationToken = new CancellationTokenSource();
HttpClient httpClient = new HttpClient();
HttpResponseMessage request = await httpClient.GetAsync(siteUrl);
cancellationToken.Token.ThrowIfCancellationRequested();

Stream response = await request.Content.ReadAsStreamAsync();
cancellationToken.Token.ThrowIfCancellationRequested();

HtmlParser parser = new HtmlParser();
IHtmlDocument document = parser.ParseDocument(response);
}


private void GetScrapeResults(IHtmlDocument document)
{
IEnumerable<IElement> articleLink = Ieleme;

foreach (var term in QueryTerms)
{
articleLink = document.All.Where(x => x.ClassName == "views-field views-field-nothing" && (x.ParentElement.InnerHtml.Contains(term) || x.ParentElement.InnerHtml.Contains(term.ToLower())));
}

if (articleLink.Any())
{
// Print Results: See Next Step
}
}

public void PrintResults(string term, IEnumerable<IElement> articleLink)
{
// Clean Up Results: See Next Step

lbListResult.Text = $"{Title} - {Url}{Environment.NewLine}";
}

private void CleanUpResults(IElement result)
{
string htmlResult = result.InnerHtml.ReplaceFirst("        <span class=\"field-content\"><div><a href=\"", "https://www.oceannetworks.ca");
htmlResult = htmlResult.ReplaceFirst("\">", "*");
htmlResult = htmlResult.ReplaceFirst("</a></div>\n<div class=\"article-title-top\">", "-");
htmlResult = htmlResult.ReplaceFirst("</div>\n<hr></span>  ", "");

// Split Results: See Next Step
}

private void SplitResults(string htmlResult)
{
string[] splitResults = htmlResult.Split('*');
Url = splitResults[0];
Title = splitResults[1];
}

*/

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
    }

}




