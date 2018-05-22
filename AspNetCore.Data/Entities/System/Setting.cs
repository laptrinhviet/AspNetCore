using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Data.Enums;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Entities
{
    [Table("Settings")]
    public class Setting : DomainEntity<Guid>, ISwitchable, IHasUniqueCode
    {
        public Setting()
        {

        }

        public Setting(string uniqueCode, string name, string textValue, Status status)
        {
            UniqueCode = uniqueCode;
            Name = name;
            TextValue = textValue;            
            Status = status;
        }
      
        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        [StringLength(128)]
        [Required]
        public string UniqueCode { get; set; }

        public string TextValue { get; set; }

        public int? IntegerValue { get; set; }

        public bool? BooleanValue { get; set; }

        public DateTime? DateValue { get; set; }

        public decimal? DecimalValue { get; set; }

        public string Description { set; get; }        

        public Status Status { get; set; }
    }
}
