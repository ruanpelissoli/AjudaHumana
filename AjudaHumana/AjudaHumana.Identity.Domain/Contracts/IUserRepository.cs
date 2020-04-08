using AjudaHumana.Core.Data;
using AjudaHumana.Core.Domain;

namespace AjudaHumana.Identity.Domain.Contracts
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser user);
    }
}
