using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Systems.Settings.Dtos
{
    public class SystemConfigViewModel
    {
        public Guid Id { set; get; }

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
