using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Dtos;
using AspNetCore.Services.Content.Feedbacks.Dtos;
using AspNetCore.Services.Content.Feedbacks;

namespace AspNetCore.Services.Content.Feedbacks
{
    public class FeedbackService : WebServiceBase<Feedback, Guid, FeedbackViewModel>, IFeedbackService
    {
        private readonly IRepository<Feedback, Guid> _feedbackRepository;

        public FeedbackService(IRepository<Feedback, Guid> feedbackRepository,
            IUnitOfWork unitOfWork) : base(feedbackRepository, unitOfWork)
        {
            _feedbackRepository = feedbackRepository;
        }

        public override void Add(FeedbackViewModel feedbackVm)
        {
            var feedback = Mapper.Map<FeedbackViewModel, Feedback>(feedbackVm);
            _feedbackRepository.Insert(feedback);
        }
        public override void Update(FeedbackViewModel feedbackVm)
        {
            var feedback = Mapper.Map<FeedbackViewModel, Feedback>(feedbackVm);
            _feedbackRepository.Update(feedback);
        }

        public override void Delete(Guid id)
        {
            _feedbackRepository.Delete(id);
        }

        public override FeedbackViewModel GetById(Guid id)
        {
            return Mapper.Map<Feedback, FeedbackViewModel>(_feedbackRepository.GetById(id));
        }

        public override List<FeedbackViewModel> GetAll()
        {
            return _feedbackRepository.GetAll().OrderBy(x => x.CreatedDate).ProjectTo<FeedbackViewModel>().ToList();
        }

        public PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _feedbackRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<FeedbackViewModel>()
            {
                Results = data.ProjectTo<FeedbackViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

    }
}