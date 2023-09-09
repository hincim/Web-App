using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Abstract;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public IActionResult Index()
        {
          
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productRepository.GetAll();

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
