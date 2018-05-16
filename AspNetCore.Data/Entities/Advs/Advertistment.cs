using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Entities
{
    [Table("Advertistments")]
    public class Advertistment : DomainEntity<Guid>, ISwitchable, ISortable, IDateTracking
    {
        public Advertistment()
        {

        }

        public Advertistment(Guid positionId, string name, string description, string image, string url, int sortOrder, Status status)
        {
            PositionId = positionId;
            Name = name;
            Description = description;
            Image = image;
            Url = url;
            SortOrder = sortOrder;
            Status = status;           
        }

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

        public DateTime? DeletedDate { set; get; }

        //[ForeignKey("PositionId")]
        //public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }
    }
}
