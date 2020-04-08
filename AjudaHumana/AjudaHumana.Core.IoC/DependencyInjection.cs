using AjudaHumana.Core.Communication;
using AjudaHumana.Core.Communication.Email;
using AjudaHumana.Core.Messages.CommonMessages.Notification;
using AjudaHumana.Identity.Application.Services;
using AjudaHumana.Core.Domain;
using AjudaHumana.Identity.Domain.Contracts;
using AjudaHumana.ONG.Application.Commands;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Data;
using AjudaHumana.ONG.Data.Repository;
using AjudaHumana.ONG.Domain.Contracts;
using AjudaHumana.Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AjudaHumana.Identity.Data.Repository;

namespace AjudaHumana.Core.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Infra
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<Settings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailService>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<IUser, LoggedUser>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Identity
            services.AddScoped<IdentityContext>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();

            //ONG
            services.AddScoped<IONGRepository, ONGRepository>();
            services.AddScoped<IONGAppService, ONGAppService>();
            services.AddScoped<ONGContext>();

            services.AddScoped<IRequestHandler<CreateONGCommand, bool>, ONGCommandHandler>();
        }
    }
}
