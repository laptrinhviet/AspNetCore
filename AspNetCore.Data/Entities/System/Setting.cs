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

        public Setting(string name, string textValue, string uniqueCode, Status status)
        {
            Name = name;
            TextValue = textValue;
            UniqueCode = uniqueCode;
            Status = status;
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string TextValue { get; set; }

        public int? IntegerValue { get; set; }

        public bool? BooleanValue { get; set; }

        public DateTime? DateValue { get; set; }

        public decimal? DecimalValue { get; set; }

        public string Description { set; get; }

        [StringLength(255)]
        public string UniqueCode { get; set; }

        public Status Status { get; set; }
    }
}
