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
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<Guid>, IMetaData, ISwitchable, ISortable, IDateTracking
    {
        public ProductCategory()
        {
        }

        //public ProductCategory()
        //{
        //    Products = new List<Product>();
        //}
        public ProductCategory(Guid id, Guid? parentId, string code, string name, string pageAlias, string description, string image, bool? homeFlag, 
            int? homeOrder, int sortOrder, Status status, string relCanonical, string pageTitle, string metaKeywords, string metaDescription)
        {
            Id = id;
            ParentId = parentId;          
            Code = code;
            Name = name;
            PageAlias = pageAlias;
            Description = description;
            Image = image;                            
            HomeFlag = homeFlag;
            HomeOrder = homeOrder;
            SortOrder = sortOrder;
            Status = status;
            RelCanonical = relCanonical;
            PageTitle = pageTitle;            
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }
        public Guid? ParentId { set; get; }

        [DefaultValue(0)]
        public int CurrentIdentity { get; set; }

        [StringLength(255)]
        [Required]
        public string Code { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }
       
        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }
        public string Description { set; get; }

        [StringLength(255)]
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        public int? HomeOrder { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }

        [StringLength(255)]
        [Required]
        public string RelCanonical { set; get; }

        [StringLength(70)]
        [Required]
        public string PageTitle { set; get; }

        [StringLength(300)]
        [Required]
        public string MetaDescription { set; get; }
        public string MetaKeywords { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
        //public virtual ICollection<Product> Products { set; get; }
    }
}
