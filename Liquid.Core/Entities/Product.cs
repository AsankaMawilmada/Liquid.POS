using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquid.Core.Entities
{
    public class Product : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public Guid ProductGuId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public string Description { get; set; }
        public decimal PurchasedPrice { get; set; }
        public decimal RegularPrice { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
