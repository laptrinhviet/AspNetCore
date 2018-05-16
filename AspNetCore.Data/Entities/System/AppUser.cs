using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Data.Interfaces;
using AspNetCore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public AppUser() {  }
        public AppUser(string fullName, string userName, 
            string email, string phoneNumber, string address, string gender, string avatar, Status status)
        {         
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Avatar = avatar;
            Status = status;
        }

        public AppUser(Guid id, string fullName, string userName,
            string email, string phoneNumber, string address, string gender, string avatar, Status status)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Avatar = avatar;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string FullName { get; set; }

        public DateTime? BirthDay { set; get; }

        public string Address { get; set; }

        public string Gender { get; set; }        

        public string Avatar { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { set; get; }

    }
}
