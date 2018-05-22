using System;
using System.Collections.Generic;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Content.Feedbacks.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Feedbacks
{
    public interface IFeedbackService : IWebServiceBase<Feedback, Guid, FeedbackViewModel>
    {
        PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize);
        //
        //void Add(FeedbackViewModel feedbackVm);
        //void Update(FeedbackViewModel feedbackVm);    
        //void Delete(int id);
        //FeedbackViewModel GetById(int id);
        //List<FeedbackViewModel> GetAll();  
    }
}