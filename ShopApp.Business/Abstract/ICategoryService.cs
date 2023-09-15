using ShopApp.Entity;
using System.Collections.Generic;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
    }
}
