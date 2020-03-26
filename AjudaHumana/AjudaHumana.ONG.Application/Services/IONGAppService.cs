using AjudaHumana.ONG.Domain;
using System;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Application.Services
{
    public interface IONGAppService : IDisposable
    {
        Task Create(NonGovernamentalOrganization ong);
        Task Update(NonGovernamentalOrganization ong);
    }
}
