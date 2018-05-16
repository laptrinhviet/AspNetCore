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
    [Table("Pages")]
    public class Page : DomainEntity<Guid>, IMetaData, ISwitchable, IDateTracking
    {
        public Page()
        {

        }

        public Page(Guid id, string name, string pageAlias, string image, string content, Status status,
           string pageTitle, string metaDescription, string metaKeywords)
        {
            Id = id;
            Name = name;
            PageAlias = pageAlias;
            Image = image;
            Content = content;
            Status = status;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string PageAlias { set; get; }

        [StringLength(255)]
        public string Image { set; get; }
        public string Content { get; set; }
        public Status Status { set; get; }

        [StringLength(70)]
        [Required]
        public string PageTitle { set; get; }

        [StringLength(300)]
        [Required]
        public string MetaDescription { set; get; }

        public string MetaKeywords { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
    }
}
