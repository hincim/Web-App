using ShopApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService: IValidator<Category>
    {
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        void Create(Category entity);
        Task<Category> CreateAsync(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
    }
}
