using System;
using System.Collections.Generic;

namespace IMDB
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { MovieName = "Frans", Link = "joomla.org", Rank = 5 });
            movies.Add(new Movie() { MovieName = "Gatling", Link = "independent.co.uk", Rank = 6 });
            movies.Add(new Movie() { MovieName = "Aldo", Link = "vistaprint.com", Rank = 7 });
            movies.Add(new Movie() { MovieName = "McCloud", Link = "soundcloud.com", Rank = 5 });
            movies.Add(new Movie() { MovieName = "Mayer", Link = "ucoz.ru", Rank = 8 });
            movies.Add(new Movie() { MovieName = "Portis", Link = "fema.gov", Rank = 1 });
            movies.Add(new Movie() { MovieName = "Sheri", Link = "hud.gov", Rank = 4 });
            movies.Add(new Movie() { MovieName = "Mougeot", Link = "myspace.com", Rank = 5 });
            movies.Add(new Movie() { MovieName = "Ferne", Link = "eepurl.com", Rank = 9 });
            movies.Add(new Movie() { MovieName = "Oakley", Link = "sphinn.com", Rank = 1 });
            movies.Add(new Movie() { MovieName = "Anna", Link = "Yewdell.org", Rank = 5 });




            //using (var ctx = new IMDBContext())
            //{
            //    foreach (Movie mvi in movies) {
            //        ctx.movies.Add(mvi);
            //    }                
            //    ctx.SaveChanges();
            //}
        }
    }
}
