using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Services.Systems.Functions.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.Interfaces;
using System;
using Microsoft.Extensions.Logging;

namespace AspNetCore.Services.Systems.Functions
{
    public class FunctionService : WebServiceBase<Function, Guid, FunctionViewModel>, IFunctionService
    {
        private readonly IRepository<Function, Guid> _functionRepository;
        private readonly IRepository<Permission, Guid> _permissionRepository;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        

        public FunctionService(
             IRepository<Function, Guid> functionRepository,
             IRepository<Permission, Guid> permissionRepository,
             RoleManager<AppRole> roleManager,
             UserManager<AppUser> userManager,
             //IMapper mapper,
            IUnitOfWork unitOfWork) : base(functionRepository, unitOfWork)
        {
            _functionRepository = functionRepository;
            _permissionRepository = permissionRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
        }

        public override void Add(FunctionViewModel functionVm)
        {

            var function = Mapper.Map<FunctionViewModel,Function>(functionVm);
            _functionRepository.Insert(function);
        }

        public override void Update(FunctionViewModel functionVm)
        {
            var functionDb = _functionRepository.GetById(functionVm.Id);
            var function = Mapper.Map<FunctionViewModel,Function>(functionVm);
            _functionRepository.Update(function);
        }

        public bool CheckExistedId(Guid id)
        {
            return _functionRepository.GetById(id) != null;
        }
    
        public override void Delete(Guid id)
        {
            _functionRepository.Delete(id);
        }

        public override FunctionViewModel GetById(Guid id)
        {
            //var function = _functionRepository.FindSingle(x => x.Id == id);
            var function = _functionRepository.Single(x => x.Id == id);
            return Mapper.Map<Function, FunctionViewModel>(function);
        }
        public Task<List<FunctionViewModel>> GetAll(string filter)
        {
            var query = _functionRepository.GetAll().Where(x => x.Status == Status.Actived);
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            return query.OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public IEnumerable<FunctionViewModel> GetAllWithParentId(Guid? parentId)
        {
            return _functionRepository.GetAll().Where(x => x.ParentId == parentId).ProjectTo<FunctionViewModel>();
        }

        public async Task<List<FunctionViewModel>> GetAllWithPermission(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);

            var query = (from f in _functionRepository.GetAll()
                         join p in _permissionRepository.GetAll() on f.Id equals p.FunctionId
                         join r in _roleManager.Roles on p.RoleId equals r.Id
                         where roles.Contains(r.Name)
                         select f);

            var parentIds = query.Select(x => x.ParentId).Distinct();

            query = query.Union(_functionRepository.GetAll().Where(f => parentIds.Contains(f.Id)));

            return await query.OrderBy(x => x.ParentId).ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public void ReOrder(Guid sourceId, Guid targetId)
        {
            var source = _functionRepository.GetById(sourceId);
            var target = _functionRepository.GetById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _functionRepository.Update(source);
            _functionRepository.Update(target);
        }

        public void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items)
        {
            //Update parent id for source
            var category = _functionRepository.GetById(sourceId);
            category.ParentId = targetId;
            _functionRepository.Update(category);

            //Get all sibling
            var sibling = _functionRepository.GetAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _functionRepository.Update(child);
            }
        }

        //public Task<List<FunctionViewModel>> GetAll(string filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<FunctionViewModel>> GetAllWithPermission(string userName)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<FunctionViewModel> GetAllWithParentId(Guid? parentId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}