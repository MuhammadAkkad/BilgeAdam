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
    public class CastService
    {        
        public Repository<Movie> repositoryMovie = new Repository<Movie>();
        public Repository<Cast> repositoryCast = new Repository<Cast>();
        public Repository<CastRole> repositoryCastRole = new Repository<CastRole>();
        public Repository<MovieCast> repositoryMovieCast = new Repository<MovieCast>();
        public void Add(string role, string castName, string movieName)
        {
            CastRole castRole = new CastRole();
            Cast cast = new Cast();
            MovieCast movieCast = new MovieCast();

            castRole.Role = role;
            if (!repositoryCastRole.EntityExists(x => x.Role == role))
            {
                repositoryCastRole.Add(castRole);
            }
            cast.Name = castName;
            if (!repositoryCast.EntityExists(c => c.Name == castName))
            {
                repositoryCast.Add(cast);
            }

            movieCast.CastId = repositoryCast.GetIdByString(c => c.Name == cast.Name, c => c.CastId);
            movieCast.CastRoleId = repositoryCastRole.GetIdByString(c => c.Role == castRole.Role, c => c.CastRoleId);
            movieCast.MovieId = repositoryMovie.GetIdByString(c => c.Name == movieName, c => c.MovieId);
            repositoryMovieCast.Add(movieCast);
        }
    }
}
