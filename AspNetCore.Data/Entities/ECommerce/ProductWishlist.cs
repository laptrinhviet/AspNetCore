using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Data.Entities
{
    [Table("ProductWishlists")]
    public class ProductWishlist : DomainEntity<Guid>, IDateTracking
    {
        public ProductWishlist()
        {
        }

        public ProductWishlist(Guid id, Guid userId, Guid productId)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
        }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { set; get; }

        //[ForeignKey("UserId")]
        //public virtual AppUser AppUser { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { set; get; }
    }
}