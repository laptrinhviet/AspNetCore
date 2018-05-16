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
    [Table("Announcements")]
    public class Announcement  : DomainEntity<Guid>, ISwitchable, IDateTracking/*, IOwner<Guid>*/
    {
        public Announcement()
        {

        }

        //public Announcement()
        //{
        //    AnnouncementUsers = new List<AnnouncementUser>();
        //}

        public Announcement(Guid userId, string title, string content, Status status)
        {
            UserId = userId;
            Title = title;
            Content = content;
            Status = status;          
        }

        public Guid UserId { set; get; }

        [StringLength(255)]
        [Required]
        public string Title { set; get; }
        public string Content { set; get; }
        public Status Status { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }

        //[ForeignKey("UserId")]
        //public virtual AppUser AppUser { get; set; }
        //public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
        
    }
}
