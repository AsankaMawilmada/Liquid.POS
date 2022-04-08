using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquid.Core.Entities
{
    public class Supplier : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Required]
        public Guid SupplierGuId { get; set; }

        [Required, MaxLength(75)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Phone { get; set; }

        [Required, MaxLength(50)]
        public string AddressLine1 { get; set; }

        [MaxLength(50)]
        public string? AddressLine2 { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string? State { get; set; }

        [Required, MaxLength(15)]
        public string PostalCode { get; set; }
    }
}
