using EasyHome.Shared;
using EasyHome.Shared.Utilis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyHome.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly EasyHomeDbContext _easyHomeDbContext;

        public BaseRepository(EasyHomeDbContext easyHomeDbContext)
        {
            _easyHomeDbContext = easyHomeDbContext;
        }

        public async Task Create(TEntity entity)
        {
            entity.InsertDate = DateTime.Now;
            await _easyHomeDbContext.Set<TEntity>().AddAsync(entity);
            await _easyHomeDbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _easyHomeDbContext.Set<TEntity>().Remove(entity);
            await _easyHomeDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _easyHomeDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where)
        {
            var test = _easyHomeDbContext.Set<TEntity>().Where(where);
            return await test.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, object>> order, OrderDirectory orderDirectory)
        {
            var query = _easyHomeDbContext.Set<TEntity>();

            if (orderDirectory == OrderDirectory.Asc)
            {
                return await query.OrderBy(order).ToListAsync();
            }
            else
            {
                return await query.OrderByDescending(order).ToListAsync();
            }
        }
        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> order, OrderDirectory orderDirectory)
        {
            var query = _easyHomeDbContext.Set<TEntity>().Where(where);

            if (orderDirectory == OrderDirectory.Asc)
            {
                return await query.OrderBy(order).ToListAsync();
            }
            else
            {
                return await query.OrderByDescending(order).ToListAsync();
            }
        }

        public async Task<TEntity> GetByID(int id)
        {
            return await _easyHomeDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task Update(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;

            var entityToChange = await GetByID(entity.ID);

            var props = entity.GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(NotToUpdate)) == false);

            foreach (var prop in props)
            {
                prop.SetValue(entityToChange, prop.GetValue(entity));
            }

            _easyHomeDbContext.Set<TEntity>().Update(entityToChange);
            await _easyHomeDbContext.SaveChangesAsync();
        }
    }
}
