using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using AspNetCore.Infrastructure.Enums;
using System.ComponentModel;

namespace AspNetCore.Data.Entities
{
    [Table("Technics")]
    public class Technic : DomainEntity<Guid>, IDateTracking
    {
        public Technic()
        {
          // Technic: Woven | Knitted | Nonwoven | 
          // Kỹ thuật: Dệt (dệt thoi) | Đan (dệt kim) | Không dệt (vải không dệt) 
        }

        //public Technic(Guid id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
        //public virtual ICollection<Product> Products { set; get; }
    }
}
