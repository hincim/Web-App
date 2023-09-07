using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.WebUI.Data;
using ShopApp.WebUI.Models;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            Product product = new Product
            {
                Name = "Test",
                Price = 100,
                Description = "TestDsc",
            };
            //ViewData["Category"] = "Telefonlar";
            //ViewData["Product"] = product;


            //ViewBag.Category = "Telefonlar";
            //ViewBag.Product = product;

            return View();
        }

        public IActionResult list(int? id, string q)
        {
            //controller/action/id
            //product/list/3
            //RouteData.Values["controller"] => product
            //RouteData.Values["action"] => list
            //RouteData.Values["id"] => 3

            // QueryString
            //Console.Write(HttpContext.Request.Query["q"].ToString());

            var products = ProductRepository.Products;

            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(p => p.Name.ToLower().Contains(q.ToLower()) || p.Description.ToLower().Contains(q.ToLower())).ToList();
            }
            
            var productViewModel = new ProductViewModel { Products = products };
          

            return View(productViewModel);
        }

        public IActionResult Details(int id)
        {
            Product product = ProductRepository.GetProductById(id);

            return View(product);
        }


        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ProductRepository.AddProduct(product);
            return RedirectToAction("list");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            return View(ProductRepository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductRepository.EditProduct(product);
            return RedirectToAction("list");
        }
    }
}
