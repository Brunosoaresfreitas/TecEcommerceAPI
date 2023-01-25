using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecEcommerce.Core.Entities;

namespace TecEcommerce.Infrastructure.Persistence.Configurations
{
    public class EvalutionConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder
                .HasKey(e => e.Id);
        }
    }
}
