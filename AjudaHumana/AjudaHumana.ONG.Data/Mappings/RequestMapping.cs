using AjudaHumana.ONG.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaHumana.ONG.Data.Mappings
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ONGId)
                  .IsRequired();

            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasColumnType("varchar(256)");

            builder.Property(c => c.Finished);

            builder.HasOne(s => s.ONG)
                   .WithMany(r => r.Requests)
                   .HasForeignKey(f => f.ONGId);

            builder.HasMany(s => s.Goals)
                .WithOne(w => w.Request)
                .HasForeignKey(f => f.RequestId);

            builder.ToTable("Requests");
        }
    }
}
