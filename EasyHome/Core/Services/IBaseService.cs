using EasyHome.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHome.Core.Services
{
    public interface IBaseService<TEntity> where TEntity:BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByID(int id);
        Task Create(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
    }
}
