using AjudaHumana.Identity.Domain;
using AjudaHumana.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AjudaHumana.Core.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Identity
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<IdentityContext>();
        }
    }
}
