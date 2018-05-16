using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Systems.Functions.Dtos
{
    public class FunctionViewModel
    {
        public Guid Id { set; get; }

        [StringLength(255)]
        public string UniqueCode { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }

        public Guid? ParentId { set; get; }
        //public string ParentList { set; get; }
        public string CssClass { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }    
    }
}
