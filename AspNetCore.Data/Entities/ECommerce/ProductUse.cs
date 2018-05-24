using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("ProductUses")]
    public class ProductUse : DomainEntity<Guid>
    {
        public ProductUse()
        {
        }

        //public ProductUse(Guid productId, Guid useId)
        //{          
        //    ProductId = productId;
        //    UseId = useId;
        //}

        public Guid ProductId { set; get; }

        public Guid UseId { set; get; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { set; get; }

        //[ForeignKey("UseId")]
        //public virtual Use Use { set; get; }
    }
}
