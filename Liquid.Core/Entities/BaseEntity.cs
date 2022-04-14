using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liquid.Core.Entities
{
    public abstract class BaseEntity
    {
        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset CreatedOn { get; set; }

        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
