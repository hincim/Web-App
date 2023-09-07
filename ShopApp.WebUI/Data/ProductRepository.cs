using ShopApp.WebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.WebUI.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            _products = new List<Product>
            {
                new Product {ProductId=1, Name = "Test",Price= 100, Description="dsds", ImageUrl="samsung2.png", CategoryId=1},
                new Product {ProductId=2, Name = "Test2",Price= 200, Description="dsds",isApproved=true, ImageUrl="samsung.png", CategoryId=1},
                new Product {ProductId=3, Name = "Test3",Price= 300, Description="dsds",ImageUrl="samsung2.png", CategoryId=1},
                new Product {ProductId=4, Name = "Test4",Price= 400, Description="dsds",isApproved=true,ImageUrl="samsung.png", CategoryId=1},

                new Product {ProductId=5, Name = "Lenovo",Price= 100, Description="dsds", ImageUrl="samsung2.png", CategoryId=2},
                new Product {ProductId=6, Name = "Hp",Price= 200, Description="dsds",isApproved=true, ImageUrl="samsung.png", CategoryId=2},
                new Product {ProductId=7, Name = "Dell",Price= 300, Description="dsds",ImageUrl="samsung2.png", CategoryId=2},
                new Product {ProductId=8, Name = "Mac",Price= 400, Description="dsds",isApproved=true,ImageUrl="samsung.png", CategoryId=2},
            };
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
          _products.Add(product);
        }
        public static Product GetProductById(int productid)
        {
            return _products.FirstOrDefault(p => p.ProductId == productid);
        }

      
    }
}
