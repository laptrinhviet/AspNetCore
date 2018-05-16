using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : DomainEntity<Guid>
    {
        public AdvertistmentPosition()
        {
        }

        public AdvertistmentPosition(Guid id, Guid pageId, string name)
        {
            Id = id;
            PageId = pageId;
            Name = name;
        }

        public Guid PageId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        //[ForeignKey("PageId")]
        //public virtual AdvertistmentPage AdvertistmentPage { get; set; }
        //public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}
