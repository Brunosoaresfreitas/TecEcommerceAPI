using TecEcommerce.Core.Enums;

namespace TecEcommerce.Core.Entities
{
    public class Evaluation : BaseEntity
    {
        public Evaluation(ProductEvaluationEnum evalution, string comment, Guid productId)
        {
            Evalution = evalution;
            Comment = comment;
            ProductId = productId;

            PostedAt = DateTime.Now;
        }

        public ProductEvaluationEnum Evalution { get; private set; }
        public string Comment { get; private set; }
        public DateTime PostedAt { get; private set; }
        public Guid ProductId { get; private set; }
    }
}
