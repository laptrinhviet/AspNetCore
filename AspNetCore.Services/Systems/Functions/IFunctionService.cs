using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Systems.Functions.Dtos;

namespace AspNetCore.Services.Systems.Functions
{
    public interface IFunctionService : IWebServiceBase<Function, Guid, FunctionViewModel>
    {      
        Task<List<FunctionViewModel>> GetAll(string filter);

        //Task<List<FunctionViewModel>> GetAllList();

        Task<List<FunctionViewModel>> GetAllWithPermission(string userName);
        IEnumerable<FunctionViewModel> GetAllWithParentId(Guid? parentId);        
        bool CheckExistedId(Guid id);
        void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);
        void ReOrder(Guid sourceId, Guid targetId);
        //
        //void Add(FunctionViewModel function);
        //void Update(FunctionViewModel function);
        //void Delete(Guid id);
        //FunctionViewModel GetById(Guid id);
        //List<FunctionViewModel> GetAll();
    }
}