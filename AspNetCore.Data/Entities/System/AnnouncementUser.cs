using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<Guid>
    {
        public AnnouncementUser()
        {
        }

        public AnnouncementUser(Guid announcementId, Guid userId, bool? hasRead)
        {
            AnnouncementId = announcementId;
            UserId = userId;
            HasRead = hasRead;        
        }

        public Guid AnnouncementId { get; set; }
        public Guid UserId { get; set; }
        public bool? HasRead { get; set; }

        //[ForeignKey("AnnouncementId")]
        //public virtual Announcement Announcement { get; set; }
    }   
}
