using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //private ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(/*ICategoryRepository categoryRepository,*/ IUnitOfWork unitOfWork)
        {
            //_categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(Category entity)
        {
            //_categoryRepository.Create(entity);
            _unitOfWork.Categories.Create(entity);
            _unitOfWork.Save();
        }
        public async Task<Category> CreateAsync(Category entity)
        {
            await _unitOfWork.Categories.CreateAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity;
        }
        public void Delete(Category entity)
        {
            //_categoryRepository.Delete(entity);
            _unitOfWork.Categories.Delete(entity);
            _unitOfWork.Save();
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            //_categoryRepository.DeleteFromCategory(productId, categoryId);
            _unitOfWork.Categories.DeleteFromCategory(productId, categoryId);
        }

        public async Task<List<Category>> GetAll()
        {
            
            //return _categoryRepository.GetAll();
            return await _unitOfWork.Categories.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            //return _categoryRepository.GetById(id);
            return await _unitOfWork.Categories.GetById(id);
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            //return _categoryRepository.GetByIdWithProducts(categoryId);
            return _unitOfWork.Categories.GetByIdWithProducts(categoryId);
        }

        public void Update(Category entity)
        {
            //_categoryRepository.Update(entity);
            _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();
        }

        public bool Validation(Category entity)
        {
            throw new System.NotImplementedException();
        }
        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    }
}
