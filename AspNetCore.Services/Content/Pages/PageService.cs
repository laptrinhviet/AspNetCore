using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Services.Content.Pages;
using AspNetCore.Services.Content.Pages.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Dtos;
using AspNetCore.Utilities.Helpers;

namespace AspNetCore.Services.Implementation
{
    public class PageService : WebServiceBase<Page, Guid, PageViewModel>, IPageService
    {
        private readonly IRepository<Page, Guid> _pageRepository;       

        public PageService(IRepository<Page, Guid> pageRepository,
            IUnitOfWork unitOfWork) : base(pageRepository, unitOfWork)
        {
            _pageRepository = pageRepository;           
        }

        public override void Add(PageViewModel pageVm)
        {
            if (!string.IsNullOrEmpty(pageVm.PageAlias))
            {
                pageVm.PageAlias = TextHelper.ToUnsignString(pageVm.Name);
            }
            var page = Mapper.Map<PageViewModel, Page>(pageVm);
            _pageRepository.Insert(page);
        }

        public override void Update(PageViewModel pageVm)
        {
            if(!string.IsNullOrEmpty(pageVm.PageAlias))
            {
                pageVm.PageAlias = TextHelper.ToUnsignString(pageVm.Name);
            }
            var page = Mapper.Map<PageViewModel, Page>(pageVm);
            _pageRepository.Update(page);
        }

        public override void Delete(Guid id)
        {
            _pageRepository.Delete(id);
        }

        public override PageViewModel GetById(Guid id)
        {
            return Mapper.Map<Page, PageViewModel>(_pageRepository.GetById(id));
        }
     
        public override List<PageViewModel> GetAll()
        {
            return _pageRepository.GetAll().OrderBy(x=>x.CreatedDate).ProjectTo<PageViewModel>().ToList();
        }

        public PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize=1)
        {
            var query = _pageRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<PageViewModel>()
            {
                Results = data.ProjectTo<PageViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public PageViewModel GetByAlias(string alias)
        {
            return Mapper.Map<Page, PageViewModel>(_pageRepository.Single(x => x.PageAlias == alias));
        }
    }
}