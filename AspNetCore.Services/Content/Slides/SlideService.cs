using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Dtos;
using AspNetCore.Data.Enums;
using AspNetCore.Infrastructure.Enums;

namespace AspNetCore.Services.Content.Slides
{
    public class SlideService : WebServiceBase<Slide, Guid, SlideViewModel>, ISlideService
    {
        private readonly IRepository<Slide, Guid> _slideRepository;

        public SlideService(IRepository<Slide, Guid> slideRepository,
            IUnitOfWork unitOfWork) : base(slideRepository, unitOfWork)
        {
            _slideRepository = slideRepository;
        }

        public override void Add(SlideViewModel slideVm)
        {
            var slide = Mapper.Map<SlideViewModel, Slide>(slideVm);
            _slideRepository.Insert(slide);
        }
        public override void Update(SlideViewModel slideVm)
        {
            var slide = Mapper.Map<SlideViewModel, Slide>(slideVm);
            _slideRepository.Update(slide);
        }

        public override void Delete(Guid id)
        {
            _slideRepository.Delete(id);
        }

        public override SlideViewModel GetById(Guid id)
        {
            return Mapper.Map<Slide, SlideViewModel>(_slideRepository.GetById(id));
        }

        public override List<SlideViewModel> GetAll()
        {
            return _slideRepository.GetAll().OrderBy(x => x.SortOrder).ProjectTo<SlideViewModel>().ToList();
        }

        public List<SlideViewModel> GetSlides(SlideGroup groupAlias)
        {
            return _slideRepository.GetAll().Where(x => x.Status == Status.Actived && x.GroupAlias == groupAlias).OrderBy(x => x.SortOrder)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public PagedResult<SlideViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _slideRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.SortOrder)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<SlideViewModel>()
            {
                Results = data.ProjectTo<SlideViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

    }
}