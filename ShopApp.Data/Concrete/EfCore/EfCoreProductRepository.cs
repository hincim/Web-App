using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ShopApp.Data.Concreate.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(p=>p.ProductId == id)
                    .Include(p=>p.ProductCategories)
                    .ThenInclude(p=>p.Category)
                    .FirstOrDefault();
                  
            }
        }
        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(p=>p.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(p => p.ProductCategories)
                    .ThenInclude(p => p.Category)
                        .Where(p => p.ProductCategories.Any(a => a.Category.Url == category.ToLower()));
                }
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(p=>p.IsApproved && p.IsHome).ToList();
            }
        }


        public Product GetProductDetails(string productname)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                    .Where(p => p.Url == productname)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(p=>p.IsApproved).AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    products = products.Include(p => p.ProductCategories)
                        .ThenInclude(p => p.Category)
                        .Where(p => p.ProductCategories.Any(a => a.Category.Url == name.ToLower()));
                }
                return products.Skip((page - 1)*pageSize).Take(pageSize).ToList();
            }
        }
        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower()))).AsQueryable();
               
                return products.ToList();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                var product = context.Products
                    .Include(p => p.ProductCategories)
                    .FirstOrDefault(p=>p.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.Price = entity.Price;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;
                    product.IsApproved = entity.IsApproved;
                    product.IsHome = entity.IsHome;

                    product.ProductCategories = categoryIds.Select(c=>new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = c
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
