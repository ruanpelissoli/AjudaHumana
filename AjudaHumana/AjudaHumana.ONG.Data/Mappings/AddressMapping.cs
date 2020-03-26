using AjudaHumana.ONG.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaHumana.ONG.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.State)
                  .IsRequired()
                  .HasColumnType("varchar(2)");

            builder.Property(c => c.City)
                   .IsRequired()
                   .HasColumnType("varchar(64)");

            builder.Property(c => c.ZipCode)
                   .IsRequired()
                   .HasColumnType("varchar(9)");

            builder.Property(c => c.Street)
                   .IsRequired()
                   .HasColumnType("varchar(256)");

            builder.Property(c => c.Number)
                   .IsRequired();

            builder.Property(c => c.Complement)
                   .HasColumnType("varchar(128)");

            builder.Property(c => c.Neighborhood)
                   .IsRequired()
                   .HasColumnType("varchar(128)");

            builder.Property(c => c.Latitude)
                   .IsRequired()
                   .HasColumnType("decimal(12,9)");

            builder.Property(c => c.Longitude)
                   .IsRequired()
                   .HasColumnType("decimal(12,9)");

            builder.HasOne(s => s.ONG)
                   .WithOne(r => r.Address)
                   .HasForeignKey<NonGovernamentalOrganization>(o => o.Id);

            builder.ToTable("Addresses");
        }
    }
}
