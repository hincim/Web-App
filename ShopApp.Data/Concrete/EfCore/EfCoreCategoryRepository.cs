using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Data.Concreate.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public List<Category> GetPopularCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}
