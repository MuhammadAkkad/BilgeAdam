using imdb;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        imdbContext db;
        public Repository(imdbContext db)
        {
            this.db = db;
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        { 
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #region IRepository<T> Members


        #endregion
    }
}
