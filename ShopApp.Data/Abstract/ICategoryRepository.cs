using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetPopularCategories();
    }
}
