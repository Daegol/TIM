using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class SoldierConfiguration : IEntityTypeConfiguration<Soldier>
    {
        public void Configure(EntityTypeBuilder<Soldier> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Company)
                .WithMany(b => b.Soldiers)
                .HasForeignKey(b => b.CompanyId);
        }
    }
}