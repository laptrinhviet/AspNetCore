using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("WholePrices")]
    public class WholePrice : DomainEntity<Guid>
    {
        public WholePrice()
        {

        }

        //public WholePrice(Guid id, Guid productId, int fromQuantity, int toQuantity, decimal price)
        //{
        //    Id = id;
        //    ProductId = productId;
        //    FromQuantity = fromQuantity;
        //    ToQuantity = toQuantity;
        //    Price = price;
        //}

        public Guid ProductId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        public decimal Price { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }
    }
}
