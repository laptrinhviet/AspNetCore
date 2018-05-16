using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Services.ECommerce.ProductCategories.Dtos;
using AspNetCore.Infrastructure.Enums;
using System.ComponentModel;

namespace AspNetCore.Services.ECommerce.Products.Dtos
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        
        public Guid CategoryId { set; get; }

        [StringLength(255)]
        public string Code { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        public string Description { set; get; }

        [StringLength(255)]
        public string Image { set; get; }
        public string Content { get; set; }
        public int? ViewCount { get; set; }

        [StringLength(255)]
        [Required]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }
        public Status Status { set; get; }

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

        public ProductCategoryViewModel ProductCategory { set; get; }

        public ICollection<ProductTagViewModel> ProductTags { set; get; }
    }
}