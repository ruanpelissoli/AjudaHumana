using AjudaHumana.Identity.Domain.ViewModels;
using System.Collections.Generic;

namespace AjudaHumana.Identity.Domain.Contracts
{
    public interface IMenuAppService
    {
        List<MenuViewModel> GetByCurrentRole();
    }
}
