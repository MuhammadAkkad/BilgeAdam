using imdb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public TEntity GetByID(object id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(TEntity entityToUpdate)
        {
            db.Set<TEntity>().Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
        }

        #region IRepository<T> Members


        #endregion
    }
}
