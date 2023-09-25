using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
using ShopApp.WebUI.EmailServices;
using ShopApp.WebUI.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=shopDb"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<ICartService, CartManager>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i => new SmtpEmailSender(
                _config["EmailSender:Host"],
                _config.GetValue<int>("EmailSender:Port"),
                _config.GetValue<bool>("EmailSender:EnableSSL"),
                _config["EmailSender:UserName"],
                _config["EmailSender:Password"]
                ));

            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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
            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();


            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            // localhost:5000/category/list/3
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "cart",
                pattern: "cart",
                defaults: new { controller = "cart", action = "index" }
                );

                endpoints.MapControllerRoute(
                name: "adminuseredit",
                pattern: "admin/user/{id?}",
                defaults: new { controller = "Admin", action = "useredit" }
                );

                endpoints.MapControllerRoute(
                name: "adminusers",
                pattern: "admin/user/list",
                defaults: new { controller = "Admin", action = "userlist" }
                );

                endpoints.MapControllerRoute(
                name: "adminroles",
                pattern: "admin/role/list",
                defaults: new { controller = "Admin", action = "rolelist" }
                );

                endpoints.MapControllerRoute(
                name: "adminrolecreate",
                pattern: "admin/role/create",
                defaults: new { controller = "Admin", action = "rolecreate" }
                );

                endpoints.MapControllerRoute(
                name: "adminroleedit",
                pattern: "admin/role/{id?}",
                defaults: new { controller = "Admin", action = "roleedit" }
                );

                endpoints.MapControllerRoute(
                name: "adminproducts",
                pattern: "admin/products",
                defaults: new { controller = "Admin", action = "productlist" }
                );


                endpoints.MapControllerRoute(
                name: "adminproductcreate",
                pattern: "admin/product/create",
                defaults: new { controller = "Admin", action = "productcreate" }
                );


                endpoints.MapControllerRoute(
                name: "adminproductedit",
                pattern: "admin/product/{id?}",
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
