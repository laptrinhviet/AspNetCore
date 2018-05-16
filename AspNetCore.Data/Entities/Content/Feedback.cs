using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Entities
{
    [Table("Feedbacks")]
    public class Feedback : DomainEntity<Guid>, ISwitchable
    {
        public Feedback()
        {
        }

        public Feedback(Guid id, string name, string phone, string email, string address, string message, Status status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Message = message;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(64)]
        [Required]
        public string Phone { set; get; }

        [StringLength(128)]
        [Required]
        public string Email { set; get; }

        [StringLength(255)]
        [Required]
        public string Address { set; get; }

        [StringLength(255)]
        [Required]
        public string Message { set; get; }
        public DateTime CreatedDate { set; get; }

        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
        public Status Status { set; get; }
    }
}
