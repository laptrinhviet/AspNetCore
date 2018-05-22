using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Systems.Permissions.Dtos;
using AspNetCore.Services.Systems.Roles.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Systems.Roles
{
    public interface IRoleService : IWebServiceBase<AppRole, Guid, AppRoleViewModel>
    {
        Task<bool> AddAsync(AppRoleViewModel userVm);

        Task DeleteAsync(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(Guid id);


        Task UpdateAsync(AppRoleViewModel userVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(Guid functionId, string action, string[] roles);
    }
}
