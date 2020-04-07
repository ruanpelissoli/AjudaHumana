using AjudaHumana.Core.Data;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Data.Repository
{
    public class ONGRepository : IONGRepository
    {
        private readonly ONGContext _context;

        public ONGRepository(ONGContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        #region ONG
        public async Task<NonGovernamentalOrganization> GetById(Guid id)
        {
            return await _context.ONGs.Include("Responsible").Include("Address").FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<NonGovernamentalOrganization>> GetAll(Expression<Func<NonGovernamentalOrganization, bool>> filter = null)
        {
            var query = _context.ONGs.Include("Responsible").Include("Address").AsNoTracking();

            if (filter == null)
                return await query.ToListAsync();

            return await query.Where(filter).ToListAsync();
        }

        public void Create(NonGovernamentalOrganization ong)
        {
            _context.ONGs.Add(ong);
        }

        public void Update(NonGovernamentalOrganization ong)
        {
            _context.ONGs.Update(ong);
        }
        #endregion

        #region Responsible
        public async Task<Responsible> GetResponsibleById(Guid id)
        {
            return await _context.Responsibles.FindAsync(id);
        }

        public async Task<Responsible> GetResponsibleByONGId(Guid ongId)
        {
            return await _context.Responsibles.FirstOrDefaultAsync(w => w.ONG.Id == ongId);
        }

        public void CreateResponsible(Responsible responsible)
        {
            _context.Responsibles.Add(responsible);
        }

        public void UpdateResponsible(Responsible responsible)
        {
            _context.Responsibles.Update(responsible);
        }
        #endregion

        #region Address
        public async Task<Address> GetAddressById(Guid id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Address> GetAddressByONGId(Guid ongId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(w => w.ONG.Id == ongId);
        }

        public void CreateAddress(Address address)
        {
            _context.Addresses.Add(address);
        }

        public void UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
        }
        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
