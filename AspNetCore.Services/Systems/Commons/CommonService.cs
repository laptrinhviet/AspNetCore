using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Services.Systems.Settings.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Constants;
using System;
using AspNetCore.Services.Content.Footers.Dtos;

namespace AspNetCore.Services.Systems.Commons
{
    public class CommonService : ICommonService
    {
        private readonly IRepository<Footer, string> _footerRepository;
        private readonly IRepository<Setting, Guid> _systemConfigRepository;       
        private readonly IRepository<Slide, Guid> _slideRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<Setting, Guid> systemConfigRepository,          
            IRepository<Slide, Guid> slideRepository,
             IUnitOfWork unitOfWork) 
        {
            _footerRepository = footerRepository;         
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.Single(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        //public List<SlideViewModel> GetSlides(SlideGroup groupAlias)
        //{
        //    return _slideRepository.GetAll().Where(x => x.Status == Status.Actived && x.GroupAlias == groupAlias).OrderBy(x => x.SortOrder)
        //        .ProjectTo<SlideViewModel>().ToList();
        //}

        //public SystemConfigViewModel GetSystemConfig(string code)
        //{
        //    return Mapper.Map<Setting, SystemConfigViewModel>(_systemConfigRepository.Single(x => x.UniqueCode == code));
        //}
    }
}