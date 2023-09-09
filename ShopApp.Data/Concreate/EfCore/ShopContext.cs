﻿using Microsoft.EntityFrameworkCore;
using ShopApp.Entity;

namespace ShopApp.Data.Concreate.EfCore
{
    public class ShopContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shopDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(t => new {t.ProductId, t.CategoryId });
        }
    }
}
