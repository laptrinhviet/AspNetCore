using System.Collections.Generic;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Services.Systems.Settings.Dtos;

namespace AspNetCore.Services.Systems.Commons
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();

        List<SlideViewModel> GetSlides(string groupAlias);

        SystemConfigViewModel GetSystemConfig(string code);
    }
}