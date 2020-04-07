using AjudaHumana.Core.Data;

namespace AjudaHumana.Identity.Domain.Contracts
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser user);
    }
}
