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
    [Table("Styles")]
    public class Style : DomainEntity<Guid>, IDateTracking
    {
        public Style()
        {
            // Style: Roman | Traditional | Modern & Contemporary | Glam | Cottage/Country | Rustic | Coastal | Industrial | Cabin/Lodge | Jacquard | Stripe | Folk Art | Plain 
            // Phong cách: Roman | Truyền thống | Hiện đại | Quyến rũ | Đồng quê | Giản dị mộc mạc | Ven biển | Công nghiệp | Cabin và nhà nhỏ | Dệt hoa | Sọc | Dân gian | Trơn 
        }

        //public Style(Guid id, string name, string description)
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
