using TecEcommerce.Core.Enums;

namespace TecEcommerce.Application.InputModels
{
    public class ProductInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ProductCategoryEnum Category { get; set; }
    }
}
