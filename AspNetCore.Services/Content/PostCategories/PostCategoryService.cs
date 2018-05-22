using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Services.Content.PostCategories.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Helpers;
using System;
using AspNetCore.Services.Content.Posts.Dtos;

namespace AspNetCore.Services.Content.PostCategories
{
    public class PostCategoryService : WebServiceBase<PostCategory, Guid, PostCategoryViewModel>,
        IPostCategoryService
    {
        private readonly IRepository<Post, Guid> _postRepository;
        private readonly IRepository<PostCategory, Guid> _postCategoryRepository;
      
        public PostCategoryService(IRepository<PostCategory, Guid> postCategoryRepository,
            IRepository<Post, Guid> postRepository,
            IUnitOfWork unitOfWork) : base(postCategoryRepository, unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _postRepository = postRepository; 
        }

        public override void Add(PostCategoryViewModel postCategoryVm)
        {
            if (string.IsNullOrEmpty(postCategoryVm.PageAlias))
                postCategoryVm.PageAlias = TextHelper.ToUnsignString(postCategoryVm.Name);

            var postCategory = Mapper.Map<PostCategoryViewModel, PostCategory>(postCategoryVm);
            _postCategoryRepository.Insert(postCategory);
        }
        public override void Update(PostCategoryViewModel postCategoryVm)
        {
            if (string.IsNullOrEmpty(postCategoryVm.PageAlias))
                postCategoryVm.PageAlias = TextHelper.ToUnsignString(postCategoryVm.Name);

            var postCategory = Mapper.Map<PostCategoryViewModel, PostCategory>(postCategoryVm);

            _postCategoryRepository.Update(postCategory);
        }

        //public override void Delete(Guid id)
        //{
        //    _postCategoryRepository.Delete(id);
        //}

        //public override PostCategoryViewModel GetById(Guid id)
        //{
        //    return Mapper.Map<PostCategory, PostCategoryViewModel>(_postCategoryRepository.GetById(id));
        //}

        //public override List<PostCategoryViewModel> GetAll()
        //{
        //    return _postCategoryRepository.GetAll().OrderBy(x => x.ParentId)
        //        .ProjectTo<PostCategoryViewModel>()
        //        .ToList();
        //}

        //public PagedResult<PostCategoryViewModel> GetAllPaging(string keyword, int pageSize, int page = 1)
        //{
        //    var query = _postCategoryRepository.GetAll();
        //    if (!string.IsNullOrEmpty(keyword))
        //        query = query.Where(x => x.Name.Contains(keyword));

        //    int totalRow = query.Count();
        //    var data = query.OrderByDescending(x => x.CreatedDate)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize);

        //    var paginationSet = new PagedResult<PostCategoryViewModel>()
        //    {
        //        Results = data.ProjectTo<PostCategoryViewModel>().ToList(),
        //        CurrentPage = page,
        //        RowCount = totalRow,
        //        PageSize = pageSize,
        //    };

        //    return paginationSet;
        //}

        public List<PostCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _postCategoryRepository.GetAll().Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<PostCategoryViewModel>().ToList();
            return _postCategoryRepository.GetAll().OrderBy(x => x.ParentId)
                .ProjectTo<PostCategoryViewModel>()
                .ToList();
        }
        public List<PostCategoryViewModel> GetAllByParentId(Guid? parentId)
        {
            return _postCategoryRepository.GetAll().Where(x => x.Status == Status.Actived && x.ParentId == parentId)
                .ProjectTo<PostCategoryViewModel>()
                .ToList();
        }
        public List<PostCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _postCategoryRepository.GetAll().Where(x => x.HomeFlag == true)
                .OrderBy(x => x.HomeOrder).Take(top).ProjectTo<PostCategoryViewModel>();
            var categories = query.ToList();
            foreach (var category in categories)
            {
                category.Posts = _postRepository
                    .GetAll().Where(x => x.CategoryId == category.Id)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ProjectTo<PostViewModel>().ToList();
            }
            return categories;
        }
        public void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items)
        {
            //Update parent id for source
            var category = _postCategoryRepository.GetById(sourceId);
            category.ParentId = targetId;
            _postCategoryRepository.Update(category);

            //Get all sibling
            var sibling = _postCategoryRepository.GetAll().Where(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _postCategoryRepository.Update(child);
            }
        }
        public void ReOrder(Guid sourceId, Guid targetId)
        {
            var source = _postCategoryRepository.GetById(sourceId);
            var target = _postCategoryRepository.GetById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _postCategoryRepository.Update(source);
            _postCategoryRepository.Update(target);
        }

        

        
    }
}