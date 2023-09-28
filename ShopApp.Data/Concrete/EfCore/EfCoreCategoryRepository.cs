using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Data.Concreate.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        private ShopContext context;
        public EfCoreCategoryRepository(ShopContext _context):base(_context) 
        {
            context = _context;
        }
     
        private ShopContext ShopContext
        {
            get
            {
                return context as ShopContext;
            }
        }
        public void DeleteFromCategory(int productId, int categoryId)
        {
            var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
            ShopContext.Database.ExecuteSqlRaw(cmd,productId,categoryId);
        }
        public Category GetByIdWithProducts(int categoryId)
        {
            return ShopContext.Categories.Where(c=> c.CategoryId == categoryId)
                .Include(c=>c.ProductCategories)
                .ThenInclude(c=>c.Product)
                .FirstOrDefault();
        }
    }
}
