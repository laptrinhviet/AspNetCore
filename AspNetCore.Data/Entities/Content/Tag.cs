using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    public class Tag : DomainEntity<string>
    {
        public Tag()
        {

        }

        //public Tag(string id, string name, string type)
        //{
        //    Id = id;
        //    Name = name;
        //    Type = type;
        //}

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Type { get; set; }
    }
}
