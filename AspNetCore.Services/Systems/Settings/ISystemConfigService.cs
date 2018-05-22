using AspNetCore.Data.Entities;
using AspNetCore.Services.Systems.Settings.Dtos;
using AspNetCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Services.Systems.Settings
{
    public interface ISystemConfigService : IWebServiceBase<Setting, Guid, SystemConfigViewModel>
    {
        PagedResult<SystemConfigViewModel> GetAllPaging(string keyword, int page, int pageSize);
        //
        //void Add(SystemConfigViewModel systemConfigVm);
        //void Update(SystemConfigViewModel systemConfigVm);
        //void Delete(Guid id);
        //SystemConfigViewModel GetById(Guid id);
        //List<SystemConfigViewModel> GetAll();
    }
}
