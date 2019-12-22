using DAL;
using imdb;

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
            unitOfWork.MovieCastRoleRepository.Add(movieCast);
        }
    }
}
