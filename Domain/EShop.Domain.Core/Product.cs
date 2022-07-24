namespace EShop.Domain.Core
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public virtual ProductCategory? Category { get; set; }
    }
}
