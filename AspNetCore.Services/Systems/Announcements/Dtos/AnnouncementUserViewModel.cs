using AspNetCore.Services.Systems.Users.Dtos;
using System;

namespace AspNetCore.Services.Systems.Announcements.Dtos
{
    public class AnnouncementUserViewModel
    {
        public Guid AnnouncementId { get; set; }
        public Guid UserId { get; set; }
        public bool? HasRead { get; set; }

        public virtual AppUserViewModel AppUser { get; set; }

        public virtual AnnouncementViewModel Announcement { get; set; }
    }
}