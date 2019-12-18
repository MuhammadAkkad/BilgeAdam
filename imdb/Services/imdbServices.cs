using DAL;
using imdb;
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
        public imdbContext db = new imdbContext();
       // public Movie movie = new Movie();
        public WebClient client = new WebClient();
        public List<Movie> movieList = new List<Movie>();
        public Repository<Movie> repositoryMovie;
        public Repository<Cast> repositoryCast = new Repository<Cast>();
        public Repository<CastRole> repositoryCastRole = new Repository<CastRole>();
        public Repository<MovieCast> repositoryMovieCast = new Repository<MovieCast>();
        public imdbServices()
        {
            repositoryMovie = new Repository<Movie>();
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<imdbContext>());
        }
        //public imdbServices(Movie movie)
        //{
        //    this.movie = movie;
        //    Database.SetInitializer(
        //    new DropCreateDatabaseIfModelChanges<imdbContext>());
        //}
        public List<Movie> Search(string search)
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
        public PictureBox getPoster(PictureBox pictureBox, string htmlCode, string mlink)
        {
            string html = htmlCode;
            string link = mlink;
            html = client.DownloadString("https://www.imdb.com" + link);
            html = getBetween(html, "<link rel='image_src' href=\"", "/>");
            client.DownloadFile(html, @"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + movie.Name + ".jpg");
            pictureBox.Image = Image.FromFile(@"C:\Users\BA\Desktop\GitHub\BilgeAdam\imdb\imdb\Images\" + movie.Name + ".jpg");
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
        public void AddCast(string role, string castName, string movieName)
        {
            CastRole castRole = new CastRole();
            MovieCast map = new MovieCast();
            Cast cast = new Cast();

            if (!repositoryCastRole.EntityExists(x => x.Role == role))
            {
                repositoryCastRole.Add(castRole);
            }

            cast.Name = castName;
            
            if (!repositoryCast.EntityExists(x => x.Name == castName))
            {
                repositoryCast.Add(cast);
            }

            map.CastId = repositoryCast.GetIdByString(c => c.Name == cast.Name, c => c.CastId);
            map.CastRoleId = repositoryCastRole.GetIdByString(c => c.Role == castRole.Role, c => c.CastRoleId);
            map.MovieId = repositoryMovie.GetIdByString(c => c.Name == movieName, c => c.MovieId);
            repositoryMovieCast.Add(map);
        }
        public Boolean EntityExist(string movieLink) {
           return repositoryMovie.EntityExists(x => x.Link == movieLink);
        }
        public string AddMovie(Movie movie) {

            if (!repositoryMovie.EntityExists(m => m.Link == movie.Link))
            {
                repositoryMovie.Add(movie);
                return "Movie Added successfully";
            }
            return "Movie already exists";
        }
        public List<Movie> GetAllMovies()
        {
            return repositoryMovie.GetAll();
        }
        public void Delete(Movie movie)
        {
            repositoryMovie.Delete(movie);
        }
    }
}
