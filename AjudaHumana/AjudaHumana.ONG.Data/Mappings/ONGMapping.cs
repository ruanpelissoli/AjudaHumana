using AjudaHumana.ONG.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaHumana.ONG.Data.Mappings
{
    public class ONGMapping : IEntityTypeConfiguration<NonGovernamentalOrganization>
    {
        public void Configure(EntityTypeBuilder<NonGovernamentalOrganization> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasColumnType("varchar(256)");

            builder.Property(c => c.CNPJ)
                   .IsRequired()
                   .HasColumnType("varchar(14)");

            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasColumnType("varchar(1024)");

            builder.Property(c => c.ResponsibleId)
                   .IsRequired();

            builder.Property(c => c.AddressId)
                   .IsRequired();

            builder.HasOne(s => s.Responsible)
                   .WithOne(r => r.ONG)
                   .HasForeignKey<Responsible>(o => o.Id);

            builder.HasOne(s => s.Address)
                   .WithOne(r => r.ONG)
                   .HasForeignKey<Address>(o => o.Id);

            builder.ToTable("ONGs");
        }
    }
}
