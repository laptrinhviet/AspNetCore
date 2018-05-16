using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCore.Data.Enums;
using AspNetCore.Data.Interfaces;
using AspNetCore.Infrastructure.SharedKernel;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Data.Entities
{
    [Table("Menus")]
    public class Menu : DomainEntity<Guid>, ISwitchable, ISortable, IDateTracking
    {
        public Menu()
        {
        }

        public Menu(Guid? parentId, string name, string url, string css, int sortOrder, Status status)
        {
            ParentId = parentId;
            Name = name;
            Url = url;
            Css = css;
            SortOrder = sortOrder;
            Status = status;            
        }

        public Guid? ParentId { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }

        public string Css { get; set; }
        public int SortOrder { set; get; }

        public Status Status { set; get; }

        public DateTime CreatedDate { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
    }
}
