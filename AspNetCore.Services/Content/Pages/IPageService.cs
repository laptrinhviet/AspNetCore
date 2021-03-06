﻿using System;
using System.Collections.Generic;
using AspNetCore.Services.Content.Pages.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Pages
{
    public interface IPageService : IDisposable
    {
        void Add(PageViewModel pageVm);

        void Update(PageViewModel pageVm);

        void Delete(int id);

        List<PageViewModel> GetAll();

        PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);

        PageViewModel GetByAlias(string alias);

        PageViewModel GetById(int id);

        void SaveChanges();
    }
}