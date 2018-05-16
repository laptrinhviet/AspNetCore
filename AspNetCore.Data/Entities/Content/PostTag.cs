using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("PostTags")]
    public class PostTag : DomainEntity<Guid>
    {
        public Guid PostId { set; get; }

        public string TagId { set; get; }

        //[ForeignKey("PostId")]
        //public virtual Post Post { set; get; }

        //[ForeignKey("TagId")]
        //public virtual Tag Tag { set; get; }
    }
}
