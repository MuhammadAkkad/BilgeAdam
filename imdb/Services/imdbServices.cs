using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using imdb;

namespace Services
{
    public class imdbServices
    {
        public imdbServices()
        {
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<imdbContext>());
        }
        Movie movie = new Movie();
        WebClient wc = new WebClient();
        List<Movie> movieList = new List<Movie>();

        public List<Movie> Search(string text) {
            string search = text;
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
                movieList.Add(movie);
            }
            return movieList;
        }

        public List<string> Top100() { 
            string htmlCode = wc.DownloadString("https://www.imdb.com/list/ls055592025/");
            htmlCode = getBetween(htmlCode, "lister-list", "footer filmosearch");
            List<string> list = new List<string>();
            foreach (Match m in Regex.Matches(htmlCode, "alt=\"(.*)\"\\sclass"))
            {
                list.Add(m.Groups[1].Value);
            }
            return list;
        
        }
        public string getBetween(string strSource, string strStart, string strEnd)
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
