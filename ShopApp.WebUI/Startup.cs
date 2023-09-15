using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concreate.EfCore;
using ShopApp.Data.Concrete.EfCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            

            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

            // localhost:5000/category/list/3
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                name: "adminproducts",
                pattern: "admin/products",
                defaults: new { controller = "Admin", action = "productlist" }
                );


                endpoints.MapControllerRoute(
                name: "adminproductcreate",
                pattern: "admin/products/create",
                defaults: new { controller = "Admin", action = "productscreate" }
                );


                endpoints.MapControllerRoute(
                name: "adminproductedit",
                pattern: "admin/products/{id?}",
                defaults: new { controller = "Admin", action = "productedit" }
                );


                endpoints.MapControllerRoute(
                name: "admincategories",
                pattern: "admin/categories",
                defaults: new { controller = "Admin", action = "categorylist" }
                );


                endpoints.MapControllerRoute(
                name: "admincategorycreate",
                pattern: "admin/categories/create",
                defaults: new { controller = "Admin", action = "categorycreate" }
                );

                endpoints.MapControllerRoute(
                name: "admincategoryedit",
                pattern: "admin/categories/{id?}",
                defaults: new { controller = "Admin", action = "categoryedit" }
                ); 


                endpoints.MapControllerRoute(
                name: "search",
                pattern: "search",
                defaults: new { controller = "Shop", action = "search" }
                );

                //// localhost/about
                //endpoints.MapControllerRoute(
                //    name: "about",
                //    pattern: "about",
                //    defaults: new { controller = "Shop", action = "about" }
                //    );

                endpoints.MapControllerRoute(
                name: "productdetails",
                pattern: "{productname}",
                defaults: new { controller = "Shop", action = "details" }
                );


                endpoints.MapControllerRoute(
                name: "products",
                pattern: "products/{category?}",
                defaults: new { controller = "Shop", action = "list" }
                );


                endpoints.MapControllerRoute(
                name: "default",
                pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
