using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;
using System.ComponentModel;

namespace AspNetCore.Services.Advs.Dtos
{
    public class AdvertistmentViewModel
    {
        public Guid Id { set; get; }

        public Guid PositionId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        [Required]
        public string Url { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }

        //public DateTime? DeletedDate { set; get; }

        public AdvertistmentPositionViewModel AdvertistmentPosition { set; get; }
     
    }
}