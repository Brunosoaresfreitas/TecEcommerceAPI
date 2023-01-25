using TecEcommerce.Core.Entities;

namespace TecEcommerce.Core.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task CreateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task SaveChangesAsync();
    }
}
