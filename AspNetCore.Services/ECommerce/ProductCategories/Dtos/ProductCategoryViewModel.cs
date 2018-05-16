using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Services.ECommerce.Products.Dtos;

namespace AspNetCore.Services.ECommerce.ProductCategories.Dtos
{
    public class ProductCategoryViewModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { set; get; }

        public int CurrentIdentity { get; set; }

        [StringLength(255)]
        [Required]
        public string Code { set; get; }

        [StringLength(255)]
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

        //public DateTime? DeletedDate { set; get; }

        public List<ProductViewModel> Products { set; get; }
    }
}