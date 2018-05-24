using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Services.Systems.Users.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Systems.Users
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);
        Task UpdateAsync(AppUserViewModel userVm);
        Task DeleteAsync(Guid id);
        Task<AppUserViewModel> GetById(Guid id);
        Task<List<AppUserViewModel>> GetAllAsync();
        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);
        
    }
}
