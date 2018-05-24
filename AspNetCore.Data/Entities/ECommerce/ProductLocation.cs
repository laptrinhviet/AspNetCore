using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("ProductLocations")]
    public class ProductLocation : DomainEntity<Guid>
    {
        public ProductLocation()
        {
          
        }

        //public ProductLocation(Guid productId, Guid locationId)
        //{          
        //    ProductId = productId;
        //    LocationId = locationId;
        //}

        public Guid ProductId { set; get; }

        public Guid LocationId { set; get; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { set; get; }

        //[ForeignKey("LocationId")]
        //public virtual Location Location { set; get; }
    }
}
