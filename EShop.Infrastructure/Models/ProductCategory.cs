using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Infrastructure.Entities;

namespace EShop.Infrastructure.Models
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
