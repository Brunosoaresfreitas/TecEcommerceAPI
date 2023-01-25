using TecEcommerce.Core.Enums;
using TecEcommerce.Core.Repositories;

namespace TecEcommerce.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string name, string description, double price, ProductCategoryEnum category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public ProductCategoryEnum Category { get; private set; }
    }
}
