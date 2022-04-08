using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquid.Core.Entities
{
    public class Product : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public Guid ProductGuId { get; set; }

        [Required, MaxLength(70)]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal PurchasedPrice { get; set; }

        [Required]
        public decimal RegularPrice { get; set; }


        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
