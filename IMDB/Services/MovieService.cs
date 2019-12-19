using DAL;
using imdb;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MovieService
    {
        Repository<Movie> repository = new Repository<Movie>();
        public string Add(MovieDTO movieDTO) {
            Movie movie = new Movie();
            movie.Name = movieDTO.Name;
            movie.Year = movieDTO.Year;
            movie.Description = movieDTO.Description;
            movie.Link = movieDTO.Link;
            movie.Photo = movieDTO.Photo;
            movie.Rank = movieDTO.Rank;

            if (!repository.EntityExists(m => m.Link == movieDTO.Link))
            {
                repository.Add(movie);
                return "Movie Added successfully";
            }
            return "Movie already exists";
        }
    }
}
