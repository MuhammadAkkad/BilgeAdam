using DAL;
using imdb;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services
{
    public class MovieService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public string Add(string movieDTOjson) {
            Movie movie = new Movie();
            movie = new JavaScriptSerializer().Deserialize<Movie>(movieDTOjson);
            if (!unitOfWork.MovieRepository.EntityExists(m => m.Link == movie.Link))
            {
                unitOfWork.MovieRepository.Add(movie);
                return "Movie Added successfully";
            }
            return "Movie already exists";
        }
        public string GetAllMovies()
        {
            List<Movie> mlist = unitOfWork.MovieRepository.GetAll();
            var json = new JavaScriptSerializer().Serialize(mlist);
            return json;
        }        
        public void Delete(string movieDTOjson)
        {
            Movie movie = new Movie();
            movie = new JavaScriptSerializer().Deserialize<Movie>(movieDTOjson);
            unitOfWork.MovieRepository.Delete(movie);
        }



        //MovieDTO EntityToDtoConverter(Movie entity) {
        //    MovieDTO dto = new MovieDTO();
        //    dto.Name = entity.Name;
        //    dto.Year = entity.Year;
        //    dto.Description = entity.Description;
        //    dto.Link = entity.Link;
        //    dto.Photo = entity.Photo;
        //    dto.Rank = entity.Rank;
        //    return dto;
        //}
        //Movie DtoToEntityCinverter(MovieDTO dto)
        //{
        //    Movie entity = new Movie();
        //    entity.Name = dto.Name;
        //    entity.Year = dto.Year;
        //    entity.Description = dto.Description;
        //    entity.Link = dto.Link;
        //    entity.Photo = dto.Photo;
        //    entity.Rank = dto.Rank;
        //    return entity;
        //}

    }
}
