using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Company)
                .WithMany(b => b.Reports)
                .HasForeignKey(b => b.CompanyId);
        }
    }
}