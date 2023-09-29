using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entity;

namespace ShopApp.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.ProductId);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);

            //builder.Property(m => m.DateAdded).HasDefaultValueSql("date('now')"); // sqlite
            builder.Property(m => m.DateAdded).HasDefaultValueSql("getdate()"); // mssql

            //    builder.HasData(
            //         new Product()
            //         {
            //             ProductId = 1,
            //             Name = "Samsung S5",
            //             Price = 2000,
            //             ImageUrl = "samsung.png",
            //             Description = "iyi telefon",
            //             IsApproved = false,
            //             Url = "samsung-s5"
            //         },
            //    new Product()
            //    {
            //        ProductId = 2,
            //        Name = "Samsung S6",
            //        Price = 3000,
            //        ImageUrl = "samsung2.png",
            //        Description = "iyi telefon",
            //        IsApproved = true,
            //        Url = "samsung-s6"
            //    },
            //    new Product()
            //    {
            //        ProductId = 3,
            //        Name = "Samsung S7",
            //        Price = 4000,
            //        ImageUrl = "samsung.png",
            //        Description = "iyi telefon",
            //        IsApproved = false,
            //        Url = "samsung-s7"
            //    },
            //    new Product()
            //    {
            //        ProductId = 4,
            //        Name = "Samsung S8",
            //        Price = 5000,
            //        ImageUrl = "samsung2.png",
            //        Description = "iyi telefon",
            //        IsApproved = true,
            //        Url = "samsung-s8"
            //    });
            //}
        }
    }
}
