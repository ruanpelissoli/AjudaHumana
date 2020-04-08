using AjudaHumana.ONG.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaHumana.ONG.Data.Mappings
{
    public class GoalMapping : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ItemName)
                  .IsRequired()
                  .HasColumnType("varchar(128)");

            builder.Property(c => c.RequestId)
                  .IsRequired();

            builder.Property(c => c.CurrentGoal)
                   .IsRequired();

            builder.Property(c => c.FinishedGoal)
                   .IsRequired();

            builder.Property(c => c.Finished);

            builder.HasOne(s => s.Request)
                   .WithMany(r => r.Goals)
                   .HasForeignKey(f => f.RequestId);

            builder.ToTable("Goals");
        }
    }
}
