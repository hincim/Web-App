using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Extensions;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public AdminController(IProductService productService, 
            ICategoryService categoryService, 
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(x => x.Name);

                ViewBag.Roles = roles;
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles,

                });
            }
            return Redirect("~/admin/user/list");
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;
                    user.UserName = model.UserName;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] {};
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user,userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }
            return View(model);
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)? members : nonMembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
               Role = role,
               Members = members,
               NonMembers = nonMembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] {})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] {})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/"+model.RoleId);        
        }
        [AllowAnonymous]
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = await _productService.GetAll()
            });
        }
        public async Task<IActionResult> CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = await _categoryService.GetAll()
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

                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Ürün eklendi",
                        AlertType = "success",
                        Message = $"{entity} isimli ürün eklendi"
                    });
                    //CreateMessage($"{entity} isimli ürün eklendi","success");

                    return RedirectToAction("productlist");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Hata",
                    AlertType = "danger",
                    Message = _productService.ErrorMessage
                });
                //CreateMessage(_productService.ErrorMessage, "danger");
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

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Kategori eklendi",
                    AlertType = "success",
                    Message = $"{entity.Name} isimli kategori eklendi."
                });

                //var msg = new AlertMessage()
                //{
                //    Message = $"{entity.Name} isimli kategori eklendi.",
                //    AlertType = "success"
                //};

                //TempData["message"] = JsonConvert.SerializeObject(msg);

                return RedirectToAction("categorylist");
            }
            return View();
        }
        public async Task<IActionResult> ProductEdit(int? id)
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

            ViewBag.Categories = await _categoryService.GetAll();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model, int[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = await _productService.GetById(model.ProductId);
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
            ViewBag.Categories = await _categoryService.GetAll();

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
        public async Task<IActionResult> CategoryEdit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _categoryService.GetById(model.CategoryId);
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

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var entity = await _productService.GetById(productId);

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
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var entity = await _categoryService.GetById(categoryId);

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

        public IActionResult AccessDenied()
        {
            return View();
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
