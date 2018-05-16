using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Systems.Functions.Dtos
{
    public class MenuViewModel
    {
        public Guid Id { set; get; }

        public Guid? ParentId { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }

        public string Css { get; set; }
        public int SortOrder { set; get; }

        public Status Status { set; get; }

        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
    }
}
