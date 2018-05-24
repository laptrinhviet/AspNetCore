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
    [Table("Patterns")]
    public class Pattern : DomainEntity<Guid>, IDateTracking
    {
        public Pattern()
        {
          // Pattern: Printed | Pleated | Embroidered | Flocked | Yarn Dyed | Beaded | Burnout | Dyed | Vertical
          // Hoa văn họa tiết: In | Xếp ly | Thêu | Bông len | Sợi nhuộm | Đính hạt | ... | Nhuộm | ...
        }

        //public Pattern(Guid id, string name, string description)
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
