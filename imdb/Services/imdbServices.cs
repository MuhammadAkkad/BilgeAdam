using DAL;
using imdb;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Services
{
    public class imdbServices
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public WebClient client = new WebClient();
        MovieDTO movieDTO = new MovieDTO();
        public List<MovieDTO> movieList = new List<MovieDTO>();
        //public Repository<MovieDTO> repositoryMovie;
        //public Repository<CastDTO> repositoryCast = new Repository<CastDTO>();
        //public Repository<CastRole> repositoryCastRole = new Repository<CastRole>();
        //public Repository<MovieCastDTO> repositoryMovieCast = new Repository<MovieCastDTO>();
        public imdbServices()
        {
            //repositoryMovie = new Repository<MovieDTO>();
            //Database.SetInitializer(
            //new DropCreateDatabaseIfModelChanges<imdbContext>());
        }
        public imdbServices(MovieDTO movieDTO)
        {
            this.movieDTO = movieDTO;
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<imdbContext>());
        }
        public List<MovieDTO> Search(string search)
        {

            string result = client.DownloadString("https://www.imdb.com/find?ref_=nv_sr_fn&q=" + search + "&s=all");
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
                MovieDTO movieDTO = new MovieDTO();
                int resultIndex = result.IndexOf("<td class=\"result_text\"> <a href=\"") + "<td class=\"result_text\"> <a href=\"".Length;
                string newResult = result.Substring(resultIndex);
                int hrefStart = newResult.IndexOf("\"");
                string link = newResult.Substring(0, hrefStart);
                movieDTO.Link = link;
                result = newResult.Remove(0, link.Length + 3);
                int startIndex = result.IndexOf("</a>");
                string title = result.Substring(0, startIndex);
                movieDTO.Name = title;
                result = result.Remove(0, title.Length + 6);
                int yearIndex = result.IndexOf(")");
                string year = result.Substring(0, yearIndex);
                movieList.Add(movieDTO);
            }
            return movieList;
        }
        public List<string> Top100()
        {
            string htmlCode = client.DownloadString("https://www.imdb.com/list/ls055592025/");
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
            string html = htmlCode;
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
            string html = htmlCode;
            return html = getBetween(html, "<meta name=\"description\" content=\"", "\" />");
        }
        public string getRank(string htmlCode)
        {
            string html = htmlCode;
            html = getBetween(html, "ratingValue\": \"", "\"");
            return html;
        }
        public PictureBox getPoster(PictureBox pictureBox, string htmlCode, MovieDTO movieDTO)
        {
            string html = htmlCode;
            string link = movieDTO.Link;
            html = client.DownloadString("https://www.imdb.com" + link);
            html = getBetween(html, "<link rel='image_src' href=\"", "/>");
            try
            {
                client.DownloadFile(html, @"C:\Users\BA\Desktop\BilgeAdam\IMDB\imdb\Images\" + movieDTO.Name + ".jpg");
            }
            catch (Exception)
            {
               throw;
            }
           
            pictureBox.Image = Image.FromFile(@"C:\Users\BA\Desktop\BilgeAdam\IMDB\imdb\Images\" + movieDTO.Name + ".jpg");
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
        public Boolean EntityExist(string movieLink)
        {
            return unitOfWork.MovieRepository.EntityExists(x => x.Link == movieLink);
        }
    }
}
