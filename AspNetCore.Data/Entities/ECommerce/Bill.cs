using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<Guid>, ISwitchable, IDateTracking
    {
        public Bill() { }

        public Bill(Guid? customerId, string customerName, string customerMobile, string customerAddress, string customerMessage,
            string customerFacebook, decimal? shippingFee, PaymentMethod paymentMethod, BillStatus billStatus, Status status)
        {
            CustomerId = customerId;
            CustomerName = customerName;         
            CustomerMobile = customerMobile;
            CustomerAddress = customerAddress;
            CustomerMessage = customerMessage;
            CustomerFacebook = customerFacebook;
            ShippingFee = shippingFee;
            PaymentMethod = paymentMethod;
            BillStatus = billStatus;
            Status = status;         
        }

        public Bill(Guid id, Guid? customerId, string customerName, string customerMobile, string customerAddress, string customerMessage,
            string customerFacebook, decimal? shippingFee, PaymentMethod paymentMethod, BillStatus billStatus, Status status)
        {
            Id = id;
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerMobile = customerMobile;
            CustomerAddress = customerAddress;
            CustomerMessage = customerMessage;
            CustomerFacebook = customerFacebook;
            ShippingFee = shippingFee;
            PaymentMethod = paymentMethod;
            BillStatus = billStatus;
            Status = status;
        }
             
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
        [DefaultValue(Status.Actived)]
        public Status Status { set; get; } = Status.Actived;
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
        
        //[ForeignKey("CustomerId")]
        //public virtual AppUser User { set; get; }
        //public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}