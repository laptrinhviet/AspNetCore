using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;
using System.ComponentModel;

namespace AspNetCore.Services.Advs.Dtos
{
    public class AdvertistmentPageViewModel
    {
        public Guid Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string UniqueCode { get; set; }
        
        public List<AdvertistmentPositionViewModel> AdvertistmentPositions { set; get; }
    }
}