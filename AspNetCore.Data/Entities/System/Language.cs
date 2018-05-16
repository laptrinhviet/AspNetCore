using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Data.Enums;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Entities
{
    [Table("Languages")]
    public class Language : DomainEntity<string>, ISwitchable
    {
        public Language()
        {
        }

        public Language(string name, bool isDefault, string resources, Status status)
        {
            Name = name;
            IsDefault = isDefault;
            Resources = resources;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}
