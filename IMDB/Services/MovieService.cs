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
        private UnitOfWork unitOfWork = new UnitOfWork();


        public string Add(MovieDTO movieDTO) {
            Movie movie = new Movie();
            movie.Name = movieDTO.Name;
            movie.Year = movieDTO.Year;
            movie.Description = movieDTO.Description;
            movie.Link = movieDTO.Link;
            movie.Photo = movieDTO.Photo;
            movie.Rank = movieDTO.Rank;

            if (!unitOfWork.MovieRepository.EntityExists(m => m.Link == movieDTO.Link))
            {
                unitOfWork.MovieRepository.Add(movie);
                return "Movie Added successfully";
            }
            return "Movie already exists";
        }
        public List<MovieDTO> GetAllMovies()
        {
            List<Movie> mlist = new List<Movie>();
            List<MovieDTO> dlist = new List<MovieDTO>();
            MovieDTO movieDTO = new MovieDTO();
            Movie movie = new Movie();
            mlist = unitOfWork.MovieRepository.GetAll();
            foreach (var item in mlist)
            {
                movieDTO.Name = movie.Name;
                movieDTO.Year = movie.Year;
                movieDTO.Description = movie.Description;
                movieDTO.Link = movie.Link;
                movieDTO.Photo = movie.Photo;
                movieDTO.Rank = movie.Rank;
                dlist.Add(movieDTO);
            }
            return dlist;
        }

        public void Delete(MovieDTO movieDTO)
        {
            Movie movie = new Movie();
            movie.Name = movieDTO.Name;
            movie.Year = movieDTO.Year;
            movie.Description = movieDTO.Description;
            movie.Link = movieDTO.Link;
            movie.Photo = movieDTO.Photo;
            movie.Rank = movieDTO.Rank;
            unitOfWork.MovieRepository.Delete(movie);
        }

    }
}
