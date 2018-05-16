using System.Collections.Generic;
using AspNetCore.Services.Content.Feedbacks.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Feedbacks
{
    public interface IFeedbackService
    {
        void Add(FeedbackViewModel feedbackVm);

        void Update(FeedbackViewModel feedbackVm);

        void Delete(int id);

        List<FeedbackViewModel> GetAll();

        PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize);

        FeedbackViewModel GetById(int id);

        void SaveChanges();
    }
}