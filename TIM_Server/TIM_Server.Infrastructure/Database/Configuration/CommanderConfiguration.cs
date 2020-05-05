using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class CommanderConfiguration : IEntityTypeConfiguration<Commander>
    {
        public void Configure(EntityTypeBuilder<Commander> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Company)
                .WithOne(b => b.Commander)
                .HasForeignKey<Company>(b => b.CommanderId);
        }
    }
}