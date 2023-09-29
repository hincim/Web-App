using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;

namespace ShopApp.Data.Configurations
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                   new Product()
                   {
                       ProductId = 1,
                       Name = "Samsung S5",
                       Price = 2000,
                       ImageUrl = "samsung.png",
                       Description = "iyi telefon",
                       IsApproved = false,
                       Url = "samsung-s5"
                   },
            new Product()
            {
                ProductId = 2,
                Name = "Samsung S6",
                Price = 3000,
                ImageUrl = "samsung2.png",
                Description = "iyi telefon",
                IsApproved = true,
                Url = "samsung-s6"
            },
            new Product()
            {
                ProductId = 3,
                Name = "Samsung S7",
                Price = 4000,
                ImageUrl = "samsung.png",
                Description = "iyi telefon",
                IsApproved = false,
                Url = "samsung-s7"
            },
            new Product()
            {
                ProductId = 4,
                Name = "Samsung S8",
                Price = 5000,
                ImageUrl = "samsung2.png",
                Description = "iyi telefon",
                IsApproved = true,
                Url = "samsung-s8"
            });

            modelBuilder.Entity<Category>().HasData(
            new Category() { CategoryId = 1, Name = "Telefon", Url = "telefon" },
            new Category() { CategoryId = 2, Name = "Bilgisayar", Url = "bilgisayar" },
            new Category() { CategoryId = 3, Name = "Elektronik", Url = "elektronik" },
            new Category() { CategoryId = 4, Name = "Beyaz Eşya", Url = "beyaz-esya" });

            modelBuilder.Entity<ProductCategory>().HasData(
              new ProductCategory() { ProductId = 1, CategoryId = 1 },
              new ProductCategory() { ProductId = 1, CategoryId = 2 },
              new ProductCategory() { ProductId = 1, CategoryId = 3 },
              new ProductCategory() { ProductId = 2, CategoryId = 1 },
              new ProductCategory() { ProductId = 2, CategoryId = 2 },
              new ProductCategory() { ProductId = 2, CategoryId = 3 },
              new ProductCategory() { ProductId = 3, CategoryId = 4 },
              new ProductCategory() { ProductId = 4, CategoryId = 3 }
         );
        }
    }
}
