using System;
using System.Collections.Generic;
using AspNetCore.Data.Entities;
using AspNetCore.Data.Enums;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Slides
{
    public interface ISlideService : IWebServiceBase<Slide, Guid, SlideViewModel>
    {
        List<SlideViewModel> GetSlides(SlideGroup groupAlias);
        PagedResult<SlideViewModel> GetAllPaging(string keyword, int page, int pageSize);
        //
        //void Add(SlideViewModel slideVm);
        //void Update(SlideViewModel slideVm);    
        //void Delete(Guid id);
        //SlideViewModel GetById(Guid id);
        //List<SlideViewModel> GetAll();  
    }
}