using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AjudaHumana.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AjudaHumana.Identity.Domain;
using AjudaHumana.Core.IoC;
using AjudaHumana.ONG.Data;
using AjudaHumana.ONG.Application.AutoMapper;
using Microsoft.AspNetCore.Identity;
using AjudaHumana.Identity.Data.Seeds;
using System.Threading.Tasks;

namespace AjudaHumana.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(
                    _configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ONGContext>(options =>
                options.UseSqlServer(
                    _configuration.GetConnectionString("DefaultConnection")));

           services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                // Password
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
            }).AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            services.AddMediatR(typeof(Startup));

            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            SeedRoles.Run(serviceScope.ServiceProvider);
            SeedAdmin.Run(serviceScope.ServiceProvider);

            app.UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
             );

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


        }
    }
}
