using Liquid.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquid.Core.Entities
{
    public class ProductTransaction : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTransactionId { get; set; }
        public string ProductOrderNumber { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasedPrice { get; set; }
        public ProductTransactionType Type { get; set; }
        public Product Product { get; set; }
        public Customer? Customer { get; set; }
    }
}
