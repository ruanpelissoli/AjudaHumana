using AjudaHumana.Core.Data;
using AjudaHumana.Core.Messages;
using AjudaHumana.ONG.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Data
{
    public class ONGContext : DbContext, IUnitOfWork
    {
        public ONGContext(DbContextOptions<ONGContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ONGContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }

        public DbSet<NonGovernamentalOrganization> ONGs { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
