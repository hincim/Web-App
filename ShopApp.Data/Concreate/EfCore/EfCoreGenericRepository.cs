using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Data.Concreate.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class
        where TContext : DbContext, new()
    {
        public void Create(TEntity entity)
        {
            using (var _db = new TContext())
            {
                _db.Set<TEntity>().Add(entity);
                _db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var _db = new TContext())
            {
                _db.Set<TEntity>().Remove(entity);
                _db.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var _db = new TContext())
            {
                return _db.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var _db = new TContext())
            {
                return _db.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var _db = new TContext())
            {
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
