using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
using System.Linq;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        public IActionResult ProductCreate() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductCreate(ProductModel model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Url = model.Url,
                
            };
            _productService.Create(entity);

            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün eklendi.",
                AlertType = "success"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("productlist");
        }
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name,
                Url = model.Url,

            };
            _categoryService.Create(entity);

            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori eklendi.",
                AlertType = "success"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("categorylist");
        }
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByIdWithCategories((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                ProductId = entity.ProductId,
                SelectedCategories = entity.ProductCategories.Select(c=>c.Category).ToList(),
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                Url = entity.Url,
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }
        [HttpPost]
        public IActionResult ProductEdit(ProductModel model, int[] categoryIds)
        {
            var entity = _productService.GetById(model.ProductId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Price = model.Price;
            entity.Url = model.Url;
            
            _productService.Update(entity, categoryIds);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün güncellendi.",
                AlertType = "warning"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }

        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _categoryService.GetByIdWithProducts((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Products = entity.ProductCategories.Select(p=>p.Product).ToList(),
                Name = entity.Name,
                Url = entity.Url,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.CategoryId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Url = model.Url;

            _categoryService.Update(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori güncellendi.",
                AlertType = "warning"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("categoryList");
        }

        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün silindi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli kategori silindi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("categoryList");
        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId,categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }
    }
}
