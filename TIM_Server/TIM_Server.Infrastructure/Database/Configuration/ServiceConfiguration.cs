using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Company)
                .WithMany(b => b.Services)
                .HasForeignKey(b => b.CompanyId);
        }
    }
}