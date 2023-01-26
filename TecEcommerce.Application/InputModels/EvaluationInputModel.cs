using TecEcommerce.Core.Enums;

namespace TecEcommerce.Application.InputModels
{
    public class EvaluationInputModel
    {
        public ProductEvaluationEnum Evalution { get; set; }
        public string Comment { get; set; }
    }
}
