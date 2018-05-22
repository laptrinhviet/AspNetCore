using System.Collections.Generic;
using AspNetCore.Services.Content.PostCategories.Dtos;
using AspNetCore.Data.Entities;
using System;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.PostCategories
{
    public interface IPostCategoryService : IWebServiceBase<PostCategory, Guid, PostCategoryViewModel>
    {               
        List<PostCategoryViewModel> GetAll(string keyword);
        List<PostCategoryViewModel> GetAllByParentId(Guid? parentId);            
        List<PostCategoryViewModel> GetHomeCategories(int top);
        void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);
        void ReOrder(Guid sourceId, Guid targetId);
        //
        //void Add(PostCategoryViewModel postCategoryVm);
        //void Update(PostCategoryViewModel postCategoryVm);
        //void Delete(Guid id);
        //PostCategoryViewModel GetById(Guid id);
        //List<PostCategoryViewModel> GetAll();
        //PagedResult<PostCategoryViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
    }
}