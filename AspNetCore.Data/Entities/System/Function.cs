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
    [Table("Functions")]
    public class Function : DomainEntity<Guid>, ISwitchable, ISortable, IHasUniqueCode
    {
        public Function()
        {

        }
        public Function(string name,string url,Guid? parentId,string cssClass,int sortOrder)
        {
            this.Name = name;
            this.Url = url;
            this.ParentId = parentId;
            this.CssClass = cssClass;
            this.SortOrder = sortOrder;
            this.Status = Status.Actived;
        }

        [StringLength(255)]
        public string UniqueCode { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Url { set; get; }
      
        public Guid? ParentId { set; get; }
        //public string ParentList { set; get; }
        public string CssClass { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        
    }
}
