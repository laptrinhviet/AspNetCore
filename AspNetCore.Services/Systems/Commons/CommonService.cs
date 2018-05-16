using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Services.Systems.Settings.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Constants;

namespace AspNetCore.Services.Systems.Commons
{
    public class CommonService : ICommonService
    {
        private IRepository<Footer, string> _footerRepository;
        private IRepository<Setting, string> _systemConfigRepository;
        private IUnitOfWork _unitOfWork;
        private IRepository<Slide, int> _slideRepository;

        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<Setting, string> systemConfigRepository,
            IUnitOfWork unitOfWork,
            IRepository<Slide, int> slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.FindSingle(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias).OrderBy(x => x.DisplayOrder)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return Mapper.Map<Setting, SystemConfigViewModel>(_systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}