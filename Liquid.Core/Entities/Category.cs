using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquid.Core.Entities
{
    public class Category : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public Guid CategoryGuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
