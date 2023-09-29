﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ShopApp.Business.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(ICartService cartService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            var roles = configuration.GetSection("Data:Roles").GetChildren().Select(r=>r.Value).ToArray();

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var users = configuration.GetSection("Data:Users");

            foreach (var section in users.GetChildren())
            {
                var username = section.GetValue<string>("username");
                var password = section.GetValue<string>("password");
                var email = section.GetValue<string>("email");
                var role = section.GetValue<string>("role");
                var firstname = section.GetValue<string>("firstname");
                var lastname = section.GetValue<string>("lastname");


                if (await userManager.FindByNameAsync(username) == null)
                {
                    var user = new User()
                    {
                        UserName = username,
                        Email = email,
                        FirstName = firstname,
                        LastName = lastname,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                        cartService.InitializeCard(user.Id);
                    }
                }
            }

            //var userName = configuration["Data:AdminUser:username"];
            //var password = configuration["Data:AdminUser:password"];
            //var email = configuration["Data:AdminUser:email"];
            //var role = configuration["Data:AdminUser:role"];

            //if (await userManager.FindByNameAsync(userName) == null)
            //{
            //    await roleManager.CreateAsync(new IdentityRole(role));

            //    var user = new User() { 
            //        UserName = userName, 
            //        Email = email,
            //        FirstName = "admin",
            //        LastName = "admin",
            //        EmailConfirmed = true
            //    };

            //    var result = await userManager.CreateAsync(user,password);
            //    if (result.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(user,role);
            //    }
            //}
        }
    }
}
