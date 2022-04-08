using Liquid.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Liquid.Core.Entities
{
    public class User : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public Guid UserGuId { get; set; }

        [MaxLength(75), Required]
        public string FirstName { get; set; }

        [MaxLength(75), Required]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(75), Required]
        public string Username { get; set; }

        [JsonIgnore]
        public byte[] Hash { get; set; }

        [JsonIgnore]
        public byte[] Salt { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public bool Active { get; set; }        
    }
}
