using AjudaHumana.Identity.Domain;
using AjudaHumana.Identity.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AjudaHumana.Identity.Data.Seeds
{
    public static class SeedAdmin
    {
        public static void Run(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            try
            {
                var adminEmail = "ruanpelissoli@gmail.com";

                var user = userManager.FindByEmailAsync(adminEmail).Result;
                if (user != null) return;

                user = new ApplicationUser(adminEmail);
                user.PasswordResetted();
                user.EmailConfirmed = true;
                var result = userManager.CreateAsync(user, "pelissoli123").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, Roles.Admin).Wait();
            }
            catch { }           
        }
    }
}
