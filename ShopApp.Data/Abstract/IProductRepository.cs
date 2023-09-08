using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetPopularProducts();
    }
}
