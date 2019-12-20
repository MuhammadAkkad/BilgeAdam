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
            movie = DtoToEntityCinverter(movieDTO);

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

            Movie movie = new Movie();
            mlist = unitOfWork.MovieRepository.GetAll();
            foreach (var movieEntity in mlist)
            {
                MovieDTO movieDTO = new MovieDTO();
                movieDTO = EntityToDtoConverter(movieEntity);
                dlist.Add(movieDTO);
            }
            return dlist;
        }

        public void Delete(MovieDTO movieDTO)
        {
            Movie movie = new Movie();
            movie = DtoToEntityCinverter(movieDTO);
            unitOfWork.MovieRepository.Delete(movie);
        }

        MovieDTO EntityToDtoConverter(Movie entity) {
            MovieDTO dto = new MovieDTO();
            dto.Name = entity.Name;
            dto.Year = entity.Year;
            dto.Description = entity.Description;
            dto.Link = entity.Link;
            dto.Photo = entity.Photo;
            dto.Rank = entity.Rank;
            return dto;
        }
        Movie DtoToEntityCinverter(MovieDTO dto)
        {
            Movie entity = new Movie();
            entity.Name = dto.Name;
            entity.Year = dto.Year;
            entity.Description = dto.Description;
            entity.Link = dto.Link;
            entity.Photo = dto.Photo;
            entity.Rank = dto.Rank;
            return entity;
        }

    }
}
