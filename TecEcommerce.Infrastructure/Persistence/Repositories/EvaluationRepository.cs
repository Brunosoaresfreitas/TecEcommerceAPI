using Microsoft.EntityFrameworkCore;
using TecEcommerce.Core.Entities;
using TecEcommerce.Core.Repositories;

namespace TecEcommerce.Infrastructure.Persistence.Repositories
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly TecEcommerceDbContext _context;
        public EvaluationRepository(TecEcommerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateEvaluationAsync(Evaluation evaluation)
        {
            await _context.Evaluations.AddAsync(evaluation);
        }

        public async Task<List<Evaluation>> GetAllEvaluationByProductAsync(Guid productId)
        {
            return await _context
                .Evaluations
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }

        public async Task<Evaluation> GetEvaluationByIdAsync(Guid id)
        {
            return await _context
                .Evaluations
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
