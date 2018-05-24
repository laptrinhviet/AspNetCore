using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("ProductFeatures")]
    public class ProductFeature : DomainEntity<Guid>
    {
        public ProductFeature()
        {
          
        }

        //public ProductFeature(Guid productId, Guid locationId)
        //{          
        //    ProductId = productId;
        //    LocationId = locationId;
        //}

        public Guid ProductId { set; get; }

        public Guid FeaturedId { set; get; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { set; get; }

        //[ForeignKey("FeaturedId")]
        //public virtual Feature Feature { set; get; }
    }
}
