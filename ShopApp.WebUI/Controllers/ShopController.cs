using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
using System.Linq;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            this._productService = productService;
        }
        // localhost/products/telefon?page=1
        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 3;
            ProductListViewModel productViewModel = new ProductListViewModel();
            productViewModel.Products = _productService.GetProductsByCategory(category, page, pageSize);
            productViewModel.PageInfo = new PageInfo()
            {
                TotalItems = _productService.GetCountByCategory(category),
                CurrentPage = page,
                ItemsPerPage = pageSize,
                CurrentCategory = category
            };
            return View(productViewModel);
        }

        public IActionResult Details(string productname)
        {
            if (productname == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails(productname);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel
            {
                Product = product,
                Categories = product.ProductCategories.Select(c => c.Category).ToList()
            }); ;
        }
        public IActionResult Search(string q)
        {
            ProductListViewModel productViewModel = new ProductListViewModel();
            productViewModel.Products = _productService.GetSearchResult(q);
          
            return View(productViewModel);
        }
    }
}
