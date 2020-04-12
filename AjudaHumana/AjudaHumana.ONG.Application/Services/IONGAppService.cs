using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Application.Services
{
    public interface IONGAppService : IDisposable
    {
        Task Create(ONGViewModel ongViewModel);
        Task Update(ONGViewModel ongViewModel);
        Task<ONGViewModel> Find(Guid id);
        Task<ONGViewModel> GetCurrentLoggedONG();
        Task<IEnumerable<ONGViewModel>> GetAll(Expression<Func<NonGovernamentalOrganization, bool>> filter = null);
        Task UpdateUserId(ONGViewModel ongViewModel, Guid userId);
        Task<IEnumerable<RequestViewModel>> GetRequests();
        Task<IEnumerable<RequestViewModel>> GetNearestRequests();
        Task<RequestViewModel> GetRequest(Guid requestId);
        Task CreateRequest(RequestViewModel requestViewModel);
        Task UpdateRequest(RequestViewModel requestViewModel);
    }
}
