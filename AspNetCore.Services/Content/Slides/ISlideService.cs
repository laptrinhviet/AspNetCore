using System.Collections.Generic;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Slides
{
    public interface ISlideService
    {
        void Add(SlideViewModel slideVm);

        void Update(SlideViewModel slideVm);

        void Delete(int id);

        List<SlideViewModel> GetAll();

        PagedResult<SlideViewModel> GetAllPaging(string keyword, int page, int pageSize, string sortBy);

        SlideViewModel GetById(int id);

        void SaveChanges();
    }
}