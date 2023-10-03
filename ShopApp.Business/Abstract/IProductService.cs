using ShopApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IProductService: IValidator<Product>
    {
        Task<Product> GetById(int id);
        Product GetProductDetails(string productname);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        Task<List<Product>> GetAll();
        bool Create(Product entity);
        Task<Product> CreateAsync(Product entity);
        void Update(Product entity);
        Task UpdateAsync(Product entityToUpdate,Product entity);
        void Delete(Product entity);
        Task DeleteAsync(Product entity);
        int GetCountByCategory(string category);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        Product GetByIdWithCategories(int id);
        bool Update(Product entity, int[] categoryIds);
    }
}
