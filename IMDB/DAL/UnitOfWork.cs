using imdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private imdbContext context = new imdbContext();
        private Repository<Movie> movieRepository;
        private Repository<Cast> castRepository;
        private Repository<CastRole> castRoleRepository;
        private Repository<MovieCast> movieCastRepository;


        public Repository<Movie> MovieRepository
        {
            get
            {

                if (this.movieRepository == null)
                {
                    this.movieRepository = new Repository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public Repository<Cast> CastRepository
        {
            get
            {

                if (this.castRepository == null)
                {
                    this.castRepository = new Repository<Cast>(context);
                }
                return castRepository;
            }
        }

        public Repository<CastRole> CastRoleRepository
        {
            get
            {

                if (this.castRoleRepository == null)
                {
                    this.castRoleRepository = new Repository<CastRole>(context);
                }
                return castRoleRepository;
            }
        }

        public Repository<MovieCast> MovieCastRoleRepository
        {
            get
            {

                if (this.movieCastRepository == null)
                {
                    this.movieCastRepository = new Repository<MovieCast>(context);
                }
                return movieCastRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

