using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Commander)
                .WithOne(b => b.Company)
                .HasForeignKey<Commander>(b => b.CompanyId);
        }
    }
}