using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Configurations;
using ShopApp.Entity;

namespace ShopApp.Data.Concreate.EfCore
{
    public class ShopContext: DbContext
    {
        public ShopContext(DbContextOptions options): base(options) 
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=shopDb");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

            //modelBuilder.Entity<ProductCategory>()
            //    .HasKey(t => new {t.ProductId, t.CategoryId });
            modelBuilder.Seed();
        }
    }
}
