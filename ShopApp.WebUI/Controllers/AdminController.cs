using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    Url = model.Url,

                };

                if (_productService.Create(entity))
                {

                    CreateMessage($"{entity} isimli ürün eklendi","success");

                    return RedirectToAction("productlist");
                }
                CreateMessage(_productService.ErrorMessage, "danger");
                return View(model);
            }
            return View(model);

        }
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            if (ModelState.IsValid)
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
            return View();
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
                IsHome = entity.IsHome,
                IsApproved = entity.IsApproved,
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model, int[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.ProductId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.Url = model.Url;
                entity.IsApproved = model.IsApproved;
                entity.IsHome = model.IsHome;

                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extension}");

                    entity.ImageUrl = randomName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",randomName);

                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await stream.CopyToAsync(stream);
                    }
                }

                if (_productService.Update(entity,categoryIds))
                {
                    CreateMessage($"{entity.Name} isimli ürün güncellendi","success");
                    return RedirectToAction("ProductList");
                }
                CreateMessage(_productService.ErrorMessage, "danger");

            }
            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
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
            if (ModelState.IsValid)
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
            return View(model);
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

        private void CreateMessage(string message, string alertType)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alertType
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
