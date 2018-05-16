using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Services.ECommerce.Products.Dtos
{
    public class ProductImageViewModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        [StringLength(255)]
        public string Caption { get; set; }

        public int SortOrder { get; set; }

        public ProductViewModel Product { get; set; }
    }
}