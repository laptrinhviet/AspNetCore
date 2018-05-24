using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    public class Feature : DomainEntity<Guid>
    {
        public Feature()
        {
           // Feature: Blackout | Flame Retardant | Insulated | Decoration | Eco-Friendly | Anti-Static | Anti-Pilling | 
           // Tính năng, công năng: cản sáng | không cháy | cách điện | trang trí | thân thiện môi trường | chống tĩnh điện | chống nhăn
        }

        //public Feature(Guid id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]       
        public string Description { get; set; }
    }
}
