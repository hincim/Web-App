using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Data.Concreate.EfCore
{
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext dbContext;
        public EfCoreGenericRepository(DbContext ctx)
        {
            dbContext = ctx;
        }
        public void Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
           return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
