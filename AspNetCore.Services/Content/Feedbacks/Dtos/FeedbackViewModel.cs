using System;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Content.Feedbacks.Dtos
{
    public class FeedbackViewModel
    {
        public Guid Id { set; get; }

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
        //public DateTime? DeletedDate { set; get; }
        public Status Status { set; get; }     
    }
}