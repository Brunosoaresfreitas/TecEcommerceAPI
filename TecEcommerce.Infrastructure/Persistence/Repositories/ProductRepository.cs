using Microsoft.EntityFrameworkCore;
using TecEcommerce.Core.Entities;
using TecEcommerce.Core.Repositories;

namespace TecEcommerce.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TecEcommerceDbContext _context;

        public ProductRepository(TecEcommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context
                .Products
                .Include(e => e.Evalutions)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
