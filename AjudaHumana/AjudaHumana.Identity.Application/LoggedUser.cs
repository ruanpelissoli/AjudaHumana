using AjudaHumana.Identity.Domain.Contracts;
using Microsoft.AspNetCore.Http;

namespace AjudaHumana.Identity.Application
{
    public class LoggedUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public string UserName { get; }

        public LoggedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;

            UserName = _accessor.HttpContext?.User?.Identity?.Name;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext?.User?.IsInRole(role) ?? false;
        }
    }
}
