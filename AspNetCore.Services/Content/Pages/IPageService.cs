using System;
using System.Collections.Generic;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Content.Pages.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Pages
{
    public interface IPageService : IWebServiceBase<Page, Guid, PageViewModel>
    {
        PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);
        PageViewModel GetByAlias(string alias);
        //
        //void Add(PageViewModel pageVm);
        //void Update(PageViewModel pageVm);    
        //void Delete(int id);
        //PageViewModel GetById(int id);
        //List<PageViewModel> GetAll();      
    }
}