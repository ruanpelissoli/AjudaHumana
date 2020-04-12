using AjudaHumana.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Domain.Contracts
{
    public interface IONGRepository : IRepository<NonGovernamentalOrganization>
    {
        Task<NonGovernamentalOrganization> GetById(Guid id);
        Task<IEnumerable<NonGovernamentalOrganization>> GetAll(Expression<Func<NonGovernamentalOrganization, bool>> filter = null);        
        void Create(NonGovernamentalOrganization ong);
        void Update(NonGovernamentalOrganization ong);

        Task<Responsible> GetResponsibleById(Guid id);
        Task<Responsible> GetResponsibleByONGId(Guid ongId);
        void CreateResponsible(Responsible responsible);
        void UpdateResponsible(Responsible responsible);

        Task<Address> GetAddressById(Guid id);
        Task<Address> GetAddressByONGId(Guid ongId);
        void CreateAddress(Address address);
        void UpdateAddress(Address address);

        Task<IEnumerable<Request>> GetRequests();
        Task<IEnumerable<Request>> GetNearestRequests();
        Task<Request> GetRequest(Guid requestId);
        void CreateRequest(Request request);
        void UpdateRequest(Request request);
    }
}
