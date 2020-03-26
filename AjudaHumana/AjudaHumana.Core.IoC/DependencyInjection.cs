using AjudaHumana.Core.Communication;
using AjudaHumana.Core.Messages.CommonMessages.Notification;
using AjudaHumana.Identity.Domain;
using AjudaHumana.ONG.Application.Commands;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Data;
using AjudaHumana.ONG.Data.Repository;
using AjudaHumana.ONG.Domain.Contracts;
using AjudaHumana.Web.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AjudaHumana.Core.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Identity
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<IdentityContext>();

            //ONG
            services.AddScoped<IONGRepository, ONGRepository>();
            services.AddScoped<IONGAppService, ONGAppService>();
            services.AddScoped<ONGContext>();

            services.AddScoped<IRequestHandler<CreateONGCommand, bool>, ONGCommandHandler>();
        }
    }
}
