using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Services.Systems.Functions.Dtos;

namespace AspNetCore.Services.Systems.Functions
{
    public interface IFunctionService
    {
        void Add(MenuViewModel function);

        Task<List<MenuViewModel>> GetAll(string filter);

        Task<List<MenuViewModel>> GetAllWithPermission(string userName);

        IEnumerable<MenuViewModel> GetAllWithParentId(string parentId);

        MenuViewModel GetById(string id);

        void Update(MenuViewModel function);

        void Delete(string id);

        void Save();

        bool CheckExistedId(string id);

        void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        void ReOrder(string sourceId, string targetId);
    }
}