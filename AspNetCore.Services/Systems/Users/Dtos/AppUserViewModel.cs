using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Systems.Users.Dtos
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            Roles = new List<string>();
        }
        public Guid Id { set; get; }

        [StringLength(255)]
        [Required]
        public string FullName { set; get; }
        public string BirthDay { set; get; }
        public string Email { set; get; }
       

        [StringLength(255)]
        [Required]
        public string UserName { set; get; }

        [StringLength(20)]
        [Required]
        public string Password { set; get; }

        public string Address { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { set; get; }
        public string Avatar { get; set; }
        public Status Status { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { set; get; }
        //public DateTime? DeletedDate { set; get; }
        public ICollection<string> Roles { get; set; }
    }
}