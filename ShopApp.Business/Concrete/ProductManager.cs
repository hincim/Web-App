using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concreate.EfCore;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //private IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(/*IProductRepository productRepository, */IUnitOfWork unitOfWork)
        {
            //_productRepository = productRepository;
            _unitOfWork = unitOfWork;

        }

        public bool Create(Product entity)
        {
            // apply business rules
            if (Validation(entity))
            {
                //_productRepository.Create(entity);
                _unitOfWork.Products.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        public async Task<Product> CreateAsync(Product entity)
        {
            await _unitOfWork.Products.CreateAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity;
        }
        public void Delete(Product entity)
        {
            //_productRepository.Delete(entity);
            _unitOfWork.Products.Delete(entity);
            _unitOfWork.Save();
        }
        public async Task DeleteAsync(Product entity)
        {
            _unitOfWork.Products.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
        public async Task<List<Product>> GetAll()
        {
            //return _productRepository.GetAll();
            return await _unitOfWork.Products.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            //return _productRepository.GetById(id);
            return await _unitOfWork.Products.GetById(id);

        }

        public Product GetByIdWithCategories(int id)
        {
            //return _productRepository.GetByIdWithCategories(id);
            return _unitOfWork.Products.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            //return _productRepository.GetCountByCategory(category);
            return _unitOfWork.Products.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            //return _productRepository.GetHomePageProducts();
            return _unitOfWork.Products.GetHomePageProducts();
        }

        public Product GetProductDetails(string productname)
        {
            //return _productRepository.GetProductDetails(productname);
            return _unitOfWork.Products.GetProductDetails(productname);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            //return _productRepository.GetProductsByCategory(name, page, pageSize);
            return _unitOfWork.Products.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            //return _productRepository.GetSearchResult(searchString);
            return _unitOfWork.Products.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            //_productRepository.Update(entity);
            _unitOfWork.Products.Update(entity);
            _unitOfWork.Save();
        }
        public async Task UpdateAsync(Product entityToUpdate, Product entity)
        {
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.Price = entity.Price;

            await _unitOfWork.SaveAsync();
        }
        public bool Update(Product entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelisiniz\n";
                    return false;
                }
                //_productRepository.Update(entity, categoryIds);
                _unitOfWork.Products.Update(entity, categoryIds);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Product entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz\n";
                isValid = false;
            }
            if (entity.Price < 0 )
            {
                ErrorMessage += "ürün fiyatı negatif olamaz\n";
                isValid = false;
            }
            if (entity.Price == null)
            {
                ErrorMessage += "ürün fiyatı boş olamaz\n";
                isValid = false;
            }

            return isValid;
        }
        public string ErrorMessage { get; set; }

    }
}
