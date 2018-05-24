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
    [Table("Materials")]
    public class Material : DomainEntity<Guid>, IDateTracking
    {
        public Material()
        {
            // Material : Polyester/Cotton | 100% Cotton | 100% Polyester | 100% Polypropylene | 100% Silk | 100% Linen | Crystal | Plastic | 
            // Wood | Metal | PVC | Velvet Fabric | Voile Fabric | Organza Fabric | Mesh Fabric | Knitted Fabric | Suede Fabric | Satin Fabric | 
            // Taffeta Fabric | Damast Fabric | Lace Fabric | 
            // Chất liệu: Vải Cotton pha Polyester | 100% vải bông Cotton | 100% vải nhân tạo Polyester | Hạt nhựa polypropylene | 
            // 100% vải tơ lụa | 100% vải lanh | Pha lê | Nhựa dẻo | Gỗ | Kim loại | Nhựa PVC | Vải nhung | Vải voan | Vải lụa ni lông | 
            // Vải lưới | Vải đan (dệt kim) | Vải da lộn | Vải xa tanh | Vải bóng | Vải gấm Đa mát | Vải ren 
        }

        //public Material(Guid id, string name, string description)
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
