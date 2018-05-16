using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AspNetCore.Infrastructure.SharedKernel;

namespace AspNetCore.Data.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntity<Guid>
    {
        public Permission() { }

        public Permission(Guid roleId, Guid functionId)
        {
            RoleId = roleId;
            FunctionId = functionId;
        }

        public Permission(Guid roleId, Guid functionId, bool canCreate,
            bool canRead, bool canUpdate, bool canDelete)
        {
            RoleId = roleId;
            FunctionId = functionId;
            CanCreate = canCreate;
            CanRead = canRead;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
        }
        public Guid RoleId { get; set; }

        public Guid FunctionId { get; set; }

        public bool CanCreate { set; get; }
        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }

        //[ForeignKey("RoleId")]
        //public virtual AppRole AppRole { get; set; }
        //[ForeignKey("FunctionId")]
        //public virtual Function Function { get; set; }
    }
}
