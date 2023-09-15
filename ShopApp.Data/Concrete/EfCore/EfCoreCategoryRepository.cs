using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Data.Concreate.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int productId, int categoryId)
        {
            using (var context = new ShopContext())
            {
                var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd,productId,categoryId);
            }
        }
        public Category GetByIdWithProducts(int categoryId)
        {
            using (var context = new ShopContext())
            {
                return context.Categories.Where(c=> c.CategoryId == categoryId)
                    .Include(c=>c.ProductCategories)
                    .ThenInclude(c=>c.Product)
                    .FirstOrDefault();
            }
        }
    }
}
