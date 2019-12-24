using DAL;
using imdb;
using Services.DTO;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Services
{
    public class CastService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public void Add(string role, string castName, string movieName)
        {
            CastRole castRole = new CastRole();
            Cast cast = new Cast();
            MovieCast movieCast = new MovieCast();

            castRole.Role = role;
            if (!unitOfWork.CastRoleRepository.EntityExists(x => x.Role == role))
            {
                unitOfWork.CastRoleRepository.Add(castRole);
            }
            cast.Name = castName;
            if (!unitOfWork.CastRepository.EntityExists(c => c.Name == castName))
            {
                unitOfWork.CastRepository.Add(cast);
            }

            movieCast.CastId = unitOfWork.CastRepository.GetIdByString(c => c.Name == cast.Name, c => c.CastId);
            movieCast.CastRoleId = unitOfWork.CastRoleRepository.GetIdByString(c => c.Role == castRole.Role, c => c.CastRoleId);
            movieCast.MovieId = unitOfWork.MovieRepository.GetIdByString(c => c.Name == movieName, c => c.MovieId);

            if (!unitOfWork.MovieCastRepository.EntityExists(c => c.CastId == movieCast.CastId &&
                                                             c.MovieId == movieCast.MovieId &&
                                                             c.CastRoleId == movieCast.CastRoleId))
            {
                unitOfWork.MovieCastRepository.Add(movieCast);
            }
        }

        public string GetCasts(MovieDTO movieDTO, int role)
        {
            List<string> casts = new List<string>();

            foreach (var item in unitOfWork.MovieCastRepository.GetAll())
            {
                if (item.MovieId == movieDTO.MovieId)
                {

                    var cast = unitOfWork.CastRepository.GetByID(item.CastId);

                    if (item.CastRoleId == role)
                    {

                        casts.Add(cast.Name);

                    }
                }
            }
            string json = new JavaScriptSerializer().Serialize(casts);
            return json;
        }
    }
}
