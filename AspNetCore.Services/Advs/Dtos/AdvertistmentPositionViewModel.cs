using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;
using System.ComponentModel;

namespace AspNetCore.Services.Advs.Dtos
{
    public class AdvertistmentPositionViewModel
    {
        public Guid Id { set; get; }
        public Guid PageId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public AdvertistmentPageViewModel AdvertistmentPage { set; get; }

        public List<AdvertistmentViewModel> Advertistments { set; get; }

    }
}