using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Soldier)
                .WithMany(b => b.Leaves)
                .HasForeignKey(b => b.SoldierId);
        }
    }
}