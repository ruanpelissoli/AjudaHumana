using AjudaHumana.ONG.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaHumana.ONG.Data.Mappings
{
    public class ResponsibleMapping : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                  .IsRequired()
                  .HasColumnType("varchar(256)");

            builder.Property(c => c.CPF)
                   .IsRequired()
                   .HasColumnType("varchar(11)");

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasColumnType("varchar(128)");

            builder.Property(c => c.PhoneNumber)
                   .IsRequired()
                   .HasColumnType("varchar(16)");

            builder.HasOne(s => s.ONG)
                   .WithOne(r => r.Responsible)
                   .HasForeignKey<NonGovernamentalOrganization>(o => o.Id);

            builder.ToTable("Responsibles");
        }
    }
}
