using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {
          
            ProductListViewModel productViewModel = new ProductListViewModel();
            productViewModel.Products = _productService.GetHomePageProducts();

            return View(productViewModel);
        }
        public async Task<IActionResult> GetProductsFromRestApi()
        {
            var products = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44303/api/products"))
                {
                    string res = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(res);
                }
            }
            return View(products);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}
