using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("AdvertistmentPages")]
    public class AdvertistmentPage : DomainEntity<Guid>
    {
        public AdvertistmentPage()
        {
        }

        public AdvertistmentPage(Guid id, string name, string uniqueCode)
        {
            Id = id;
            Name = name;
            UniqueCode = uniqueCode;
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string UniqueCode { get; set; }
        //public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
