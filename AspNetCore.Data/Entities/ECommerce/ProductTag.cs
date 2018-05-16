using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("ProductTags")]
    public class ProductTag : DomainEntity<Guid>
    {
        public ProductTag()
        {
        }

        //public ProductTag(Guid productId, string tagId)
        //{          
        //    ProductId = productId;
        //    TagId = tagId;
        //}

        public Guid ProductId { set; get; }

        public string TagId { set; get; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { set; get; }

        //[ForeignKey("TagId")]
        //public virtual Tag Tag { set; get; }
    }
}
