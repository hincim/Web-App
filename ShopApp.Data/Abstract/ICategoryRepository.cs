using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);

    }
}
