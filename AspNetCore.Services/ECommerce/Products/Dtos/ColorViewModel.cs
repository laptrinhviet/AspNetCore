using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetCore.Services.ECommerce.Products.Dtos
{
    public class ColorViewModel
    {
        public Guid Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }
        public string Code { get; set; }
    }
}