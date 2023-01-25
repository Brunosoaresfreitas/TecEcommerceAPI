namespace TecEcommerce.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
