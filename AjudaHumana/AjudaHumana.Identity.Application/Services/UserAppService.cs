using AjudaHumana.Core.Utils;
using AjudaHumana.Identity.Domain;
using AjudaHumana.Identity.Domain.Constants;
using AjudaHumana.Identity.Domain.Contracts;
using AjudaHumana.Identity.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjudaHumana.Identity.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAppService(UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<CreatedUserViewModel> CreateONGUser(string email)
        {
            var user = new ApplicationUser(email);
            var tempPassword = GenerateRandomPassword.Generate(8);
            var result = await _userManager.CreateAsync(user, tempPassword);

           if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(user, Roles.ONG);

            return new CreatedUserViewModel
            {
                User = user,
                TempPassword = tempPassword
            };
        }

        public async Task<string> GenerateConfirmationEmailCode(ApplicationUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }

        public async Task PasswordResetted(ApplicationUser user)
        {
            user.PasswordResetted();
            _userRepository.Update(user);
            await _userRepository.UnitOfWork.Commit();
        }
    }
}
