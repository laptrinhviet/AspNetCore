using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Systems.Functions.Dtos
{
    public class LanguageViewModel
    {
        public string Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public string Resources { get; set; }

        public Status Status { get; set; }
    }
}
