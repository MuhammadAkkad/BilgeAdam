using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        Boolean EntityExists(Expression<Func<TEntity, bool>> expression);
        void Delete(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}
