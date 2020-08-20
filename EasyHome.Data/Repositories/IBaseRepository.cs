using EasyHome.Shared;
using EasyHome.Shared.Utilis;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyHome.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, object>> order, OrderDirectory orderDirectory);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order, OrderDirectory orderDirectory);
        Task<TEntity> GetByID(int id);
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
    }
}
