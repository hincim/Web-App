using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string productname);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetSearchResult(string searchString);
        List<Product> GetHomePageProducts();
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);

    }
}
