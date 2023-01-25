using System.Diagnostics;
using TecEcommerce.Core.Enums;

namespace TecEcommerce.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(string name, string description, double price, ProductCategoryEnum category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            PostedAt = DateTime.Now;

            Evalutions = new List<Evaluation>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public ProductCategoryEnum Category { get; private set; }
        public DateTime PostedAt { get; private set; }
        public List<Evaluation> Evalutions { get; private set; }

        public void Update(string name, string description, double price, ProductCategoryEnum category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
