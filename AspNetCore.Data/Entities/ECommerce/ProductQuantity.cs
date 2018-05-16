using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("ProductQuantities")]
    public class ProductQuantity : DomainEntity<Guid>
    {
        public ProductQuantity()
        {

        }
        public ProductQuantity(Guid sizeId, Guid colorId, Guid productId)
        {
            SizeId = sizeId;
            ColorId = colorId;
            ProductId = productId;
        }

        [Column(Order = 1)]
        public Guid ProductId { get; set; }

        [Column(Order = 2)]
        public Guid SizeId { get; set; }

        [Column(Order = 3)]
        public Guid ColorId { get; set; }

        public int Quantity { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }

        //[ForeignKey("SizeId")]
        //public virtual Size Size { get; set; }

        //[ForeignKey("ColorId")]
        //public virtual Color Color { get; set; }
    }
}
