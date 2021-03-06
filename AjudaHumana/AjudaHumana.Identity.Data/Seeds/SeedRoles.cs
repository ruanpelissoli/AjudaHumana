﻿using AjudaHumana.Core.Domain;
using AjudaHumana.Identity.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AjudaHumana.Identity.Data.Seeds
{
    public static class SeedRoles
    {
        public static void Run(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            try
            {
                if (!roleManager.RoleExistsAsync(Roles.Admin).Result)
                    roleManager.CreateAsync(new IdentityRole(Roles.Admin)).Wait();

                if (!roleManager.RoleExistsAsync(Roles.ONG).Result)
                    roleManager.CreateAsync(new IdentityRole(Roles.ONG)).Wait();
            }
            catch { }
        }
    }
}
