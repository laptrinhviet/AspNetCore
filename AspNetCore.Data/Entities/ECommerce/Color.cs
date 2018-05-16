using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("Colors")]
    public class Color : DomainEntity<Guid>
    {
        public Color()
        {

        }

        public Color(Guid id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }
        public string Code { get; set; }
    }
}
