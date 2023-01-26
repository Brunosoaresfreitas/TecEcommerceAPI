using TecEcommerce.Core.Entities;

namespace TecEcommerce.Core.Repositories
{
    public interface IEvaluationRepository
    {
        Task<List<Evaluation>> GetAllEvaluationByProductAsync(Guid productId);
        Task<Evaluation> GetEvaluationByIdAsync(Guid id);
        Task CreateEvaluationAsync(Evaluation evaluation);
        Task SaveChangesAsync();
    }
}
