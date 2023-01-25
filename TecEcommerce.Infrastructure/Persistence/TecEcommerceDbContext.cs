using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TecEcommerce.Core.Entities;

namespace TecEcommerce.Infrastructure.Persistence
{
    public class TecEcommerceDbContext : DbContext
    {
        public TecEcommerceDbContext(DbContextOptions<TecEcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
