using System.Collections.Generic;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Services.Systems.Settings.Dtos;
using AspNetCore.Data.Enums;
using AspNetCore.Services.Content.Footers.Dtos;

namespace AspNetCore.Services.Systems.Commons
{
    public interface ICommonService 
    {
        FooterViewModel GetFooter();

        //List<SlideViewModel> GetSlides(SlideGroup groupAlias);

        //SystemConfigViewModel GetSystemConfig(string code);
    }
}