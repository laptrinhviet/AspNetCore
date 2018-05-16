using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Services.Systems.Users.Dtos;

namespace AspNetCore.Services.Systems.Announcements.Dtos
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel()
        {
            AnnouncementUsers = new List<AnnouncementUserViewModel>();
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

        public AppUserViewModel AppUser { get; set; }

        public virtual ICollection<AnnouncementUserViewModel> AnnouncementUsers { get; set; }
    }
}