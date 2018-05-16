using AspNetCore.Data.Enums;
using AspNetCore.Infrastructure.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Services.Content.Slides.Dtos
{
    public class SlideViewModel
    {
        public Guid Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }
      
        [StringLength(255)]
        public string Description { set; get; }

        [StringLength(255)]
        [Required]
        public string Image { set; get; }
        public string Content { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }

        [Required]
        public SlideGroup GroupAlias { get; set; }
    }
}