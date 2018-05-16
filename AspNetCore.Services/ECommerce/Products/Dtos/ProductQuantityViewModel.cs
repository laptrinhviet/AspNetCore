using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetCore.Services.ECommerce.Products.Dtos
{
    public class ProductQuantityViewModel
    {
        public Guid ProductId { get; set; }

        public Guid SizeId { get; set; }

        public Guid ColorId { get; set; }

        public int Quantity { get; set; }

        public  ProductViewModel Product { get; set; }

        public virtual SizeViewModel Size { get; set; }

        public virtual ColorViewModel Color { get; set; }
    }
}