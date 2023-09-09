using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;

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
            productViewModel.Products = _productService.GetAll();

            return View(productViewModel);
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
