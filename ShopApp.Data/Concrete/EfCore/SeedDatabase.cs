using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Concreate.EfCore;
using ShopApp.Entity;
using System.Linq;

namespace ShopApp.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            //var context = new ShopContext();

            //if (context.Database.GetPendingMigrations().Count() == 0)
            //{
            //    if (context.Categories.Count() == 0)
            //    {
            //        context.Categories.AddRange(Categories);
            //    }

            //    if (context.Products.Count() == 0)
            //    {
            //        context.Products.AddRange(Products);
            //        context.AddRange(ProductCategories);
            //    }
            //}
            //context.SaveChanges();
        }
        private static Category[] Categories = {
            new Category(){Name="Telefon", Url="telefon"},
            new Category(){Name="Bilgisayar", Url = "bilgisayar"},
            new Category(){Name="Elektronik", Url = "elektronik"},
            new Category(){Name="Beyaz Eşya", Url = "beyaz-esya"},
        };

        private static Product[] Products = {
            new Product(){Name="Samsung S5",Price=2000,ImageUrl="samsung.png",Description="iyi telefon",IsApproved=false,
            Url="samsung-s5"},
            new Product(){Name="Samsung S6",Price=3000,ImageUrl="samsung2.png",Description="iyi telefon",IsApproved=true,
            Url="samsung-s6"},
            new Product(){Name="Samsung S7",Price=4000,ImageUrl="samsung.png",Description="iyi telefon",IsApproved=false,
            Url="samsung-s7"},
            new Product(){Name="Samsung S8",Price=5000,ImageUrl="samsung2.png",Description="iyi telefon",IsApproved=true,
            Url="samsung-s8"},
        };

        private static ProductCategory[] ProductCategories = {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[0],Category=Categories[2]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[2]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[3],Category=Categories[0]},
            new ProductCategory(){Product=Products[3],Category=Categories[2]},
        };
    }
}
