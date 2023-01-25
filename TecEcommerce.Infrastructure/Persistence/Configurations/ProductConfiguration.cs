using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecEcommerce.Core.Entities;

namespace TecEcommerce.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(e => e.Evalutions)
                .WithOne()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
