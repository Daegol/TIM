using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database.Configuration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Soldier)
                .WithMany(b => b.Requests)
                .HasForeignKey(b => b.SoldierId);
        }
    }
}