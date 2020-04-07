using AjudaHumana.Identity.Application.Factories;
using AjudaHumana.Identity.Domain.Constants;
using AjudaHumana.Identity.Domain.Contracts;
using AjudaHumana.Identity.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaHumana.Identity.Application.Services
{
    public class MenuAppService : IMenuAppService
    {
        private readonly IUser _user;

        public MenuAppService(IUser user)
        {
            _user = user;
        }

        public List<MenuViewModel> GetByCurrentRole()
        {
            if (_user.IsInRole(Roles.Admin))
                return MenuFactory.Admin();

            if(_user.IsInRole(Roles.ONG))
                return MenuFactory.ONG();

            return MenuFactory.Default();
        }
    }
}
