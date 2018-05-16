using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetCore.Services.Systems.Functions.Dtos;
using AspNetCore.Services.Systems.Roles.Dtos;

namespace AspNetCore.Services.Systems.Permissions.Dtos
{
    public class PermissionViewModel
    {

        public Guid Id { get; set; }


        public Guid RoleId { get; set; }

        public Guid FunctionId { get; set; }

        public bool CanCreate { set; get; }

        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }

        public bool CanDelete { set; get; }

        public AppRoleViewModel AppRole { get; set; }

        public MenuViewModel Function { get; set; }
    }
}