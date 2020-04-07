using AjudaHumana.Core.Data;
using AjudaHumana.Identity.Domain;
using AjudaHumana.Identity.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaHumana.Identity.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public void Update(ApplicationUser user)
        {
            _context.ApplicationUsers.Update(user);
        }
    }
}
