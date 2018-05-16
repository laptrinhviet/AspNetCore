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
    [Table("Contacts")]
    public class Contact : DomainEntity<string>, ISwitchable
    {

        //private new Guid Id;

        public Contact()
        {
        }
        
        public Contact(string id, string name, string phone, string email, string website, string address, string other, double? lng, double? lat, Status status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Website = website;
            Address = address;
            Other = other;
            Lng = lng;
            Lat = lat;
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
