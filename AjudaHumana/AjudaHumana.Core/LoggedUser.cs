using AjudaHumana.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace AjudaHumana.Core
{
    public class LoggedUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public string UserName { get; }
        public Guid? Id { get; }

        public LoggedUser(IHttpContextAccessor accessor, UserManager<ApplicationUser> userManager)
        {
            _accessor = accessor;
            _userManager = userManager;

            UserName = _accessor.HttpContext?.User?.Identity?.Name;

            if (!string.IsNullOrEmpty(UserName))
            {
                var user = _userManager.FindByNameAsync(UserName)?.Result;

                Id = Guid.Parse(user.Id);
            }
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext?.User?.IsInRole(role) ?? false;
        }
    }
}
