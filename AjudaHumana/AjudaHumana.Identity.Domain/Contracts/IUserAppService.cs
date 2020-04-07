using AjudaHumana.Identity.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjudaHumana.Identity.Domain.Contracts
{
    public interface IUserAppService
    {
        Task<CreatedUserViewModel> CreateONGUser(string email);
        Task<string> GenerateConfirmationEmailCode(ApplicationUser user);
        Task PasswordResetted(ApplicationUser user);
    }
}
