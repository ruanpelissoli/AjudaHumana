using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AjudaHumana.Web.Areas.Identity.IdentityHostingStartup))]
namespace AjudaHumana.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}