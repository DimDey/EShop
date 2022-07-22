namespace EShop.Domain.Core
{
    public class ProductCategory : BaseEntity
    {
        public string Title { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual ProductCategory? Parent { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<ProductCategory>? Children { get; set; }
    }
}
