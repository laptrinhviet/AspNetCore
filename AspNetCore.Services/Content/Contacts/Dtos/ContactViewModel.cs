using System;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Content.Contacts.Dtos
{
    public class ContactViewModel
    {
        public string Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(64)]
        [Required]
        public string Phone { set; get; }

        [StringLength(128)]
        [Required]
        public string Email { set; get; }

        [StringLength(128)]
        [Required]
        public string Website { set; get; }

        [StringLength(255)]
        [Required]
        public string Address { set; get; }
        public string Other { set; get; }
        public double? Lat { set; get; }
        public double? Lng { set; get; }
        public Status Status { set; get; }      
    }
}