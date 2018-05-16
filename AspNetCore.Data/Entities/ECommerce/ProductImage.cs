using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("ProductImages")]
    public class ProductImage : DomainEntity<Guid>, ISortable
    {
        public ProductImage()
        {

        }

        public ProductImage(Guid id, Guid productId, string path, string caption)
        {
            Id = id;
            ProductId = productId;
            Path = path;
            Caption = caption;
        }

        public Guid ProductId { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        [StringLength(255)]
        public string Caption { get; set; }

        public int SortOrder { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }
    }
}
