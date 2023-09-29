using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using System.Collections.Generic;
using System.Linq;

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

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
           return dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
