using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        //IQueryable<TEntity> Query { get; }
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
