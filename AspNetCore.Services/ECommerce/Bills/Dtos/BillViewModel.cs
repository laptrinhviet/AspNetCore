using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Services.Systems.Users.Dtos;
using AspNetCore.Data.Enums;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.ECommerce.Bills.Dtos
{
    public class BillViewModel
    {
        public Guid Id { set; get; }

        public Guid? CustomerId { set; get; }

        public string UniqueCode { set; get; }

        [StringLength(255)]
        [Required]
        public string CustomerName { set; get; }

        [StringLength(64)]
        [Required]
        public string CustomerMobile { set; get; }

        [StringLength(255)]
        [Required]
        public string CustomerAddress { set; get; }

        [StringLength(255)]
        public string CustomerMessage { set; get; }
        public string CustomerFacebook { set; get; }
        public decimal? ShippingFee { set; get; }
        public PaymentMethod PaymentMethod { set; get; }
        public BillStatus BillStatus { set; get; }    
        public Status Status { set; get; } 
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        //public DateTime? DeletedDate { set; get; }

        public AppUserViewModel User { set; get; }

        public List<BillDetailViewModel> BillDetails { set; get; }
    }
}