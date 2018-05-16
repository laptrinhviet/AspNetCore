using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<Guid>, ISortable
    {
        public Slide()
        {

        }

        public Slide(Guid id, string name, string image, string url, int sortOrder, Status status, SlideGroup groupAlias)
        {
            Id = id;
            Name = name;
            Image = image;
            Url = url;
            SortOrder = sortOrder;
            Status = status;
            GroupAlias = groupAlias;
        }

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
