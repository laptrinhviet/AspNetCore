using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Systems.Permissions.Dtos;
using AspNetCore.Services.Systems.Roles.Dtos;
using AspNetCore.Utilities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Services.Systems.Roles
{
    public interface IRoleService 
    {
        Task<bool> AddAsync(AppRoleViewModel userVm);        
        Task UpdateAsync(AppRoleViewModel userVm);
        Task DeleteAsync(Guid id);
        Task<AppRoleViewModel> GetById(Guid id);
        Task<List<AppRoleViewModel>> GetAllAsync();
        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
     
        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(Guid functionId, string action, string[] roles);
    }
}
