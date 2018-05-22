using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Constants;
using AspNetCore.Utilities.Dtos;
using AspNetCore.Utilities.Helpers;
using AspNetCore.Services.Content.Posts.Dtos;
using AspNetCore.Services.Dtos;
using AspNetCore.Services.Content.Posts;
using System;

namespace AspNetCore.Services.Content.Posts
{
    public class PostService : WebServiceBase<Post, Guid, PostViewModel>, IPostService
    {
        private readonly IRepository<Post,Guid> _postRepository;
        private readonly IRepository<Tag,string> _tagRepository;
        private readonly IRepository<PostTag, Guid> _postTagRepository;     

        public PostService(IRepository<Post, Guid> postRepository,
            IRepository<PostTag, Guid> postTagRepository,
            IRepository<Tag,string> tagRepository,
            IUnitOfWork unitOfWork) : base(postRepository, unitOfWork)
        {
            _postRepository = postRepository;
            _postTagRepository = postTagRepository;
            _tagRepository = tagRepository;         
        }

        public override void Add(PostViewModel postVm)
        {
            var post = Mapper.Map<PostViewModel, Post>(postVm);
            if (string.IsNullOrEmpty(postVm.PageAlias))
                post.PageAlias = TextHelper.ToUnsignString(postVm.Name);

            //if (string.IsNullOrEmpty(postVm.Code))
            //{
            //    var category = _postCategoryRepository.GetById(postVm.CategoryId);
            //    var code = category.Code + (category.CurrentIdentity + 1).ToString("0000");
            //    category.CurrentIdentity += 1;
            //    post.Code = code;
            //}

            if (!string.IsNullOrEmpty(postVm.Tags))
            {
                string[] tags = postVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.PostTag
                        };
                        _tagRepository.Insert(tag);
                    }

                    PostTag postTag = new PostTag
                    {
                        Id = Guid.NewGuid(),
                        PostId = post.Id,
                        TagId = tagId
                    };

                    _postTagRepository.Insert(postTag);
                    //post.PostTags.Add(postTag);

                }
            }
            _postRepository.Insert(post);
        }
        public override void Update(PostViewModel postVm)
        {
            var post = _postRepository.Update(Mapper.Map<PostViewModel, Post>(postVm));
            _postTagRepository.Delete(x => x.Id == post.Id);
            if (!string.IsNullOrEmpty(postVm.Tags))
            {
                string[] tags = postVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.PostTag
                        };
                        _tagRepository.Insert(tag);
                    }
                  
                    PostTag postTag = new PostTag
                    {
                        Id = Guid.NewGuid(),
                        PostId = post.Id,
                        TagId = tagId
                    };
                    _postTagRepository.Insert(postTag);
                }
            }
            _postRepository.Update(post);
        }
        
        //public override void Delete(Guid id)
        //{
        //    _postRepository.Delete(id);
        //}

        //public override PostViewModel GetById(Guid id)
        //{
        //    return Mapper.Map<Post, PostViewModel>(_postRepository.GetById(id));
        //}

        //public override List<PostViewModel> GetAll()
        //{
        //    return _postRepository.GetAll().OrderBy(c => c.PostTags)
        //        .ProjectTo<PostViewModel>().ToList();
        //}

        //public PagedResult<PostViewModel> GetAllPaging(string keyword, int pageSize, int page = 1)
        //{
        //    var query = _postRepository.FindAll();
        //    if (!string.IsNullOrEmpty(keyword))
        //        query = query.Where(x => x.Name.Contains(keyword));

        //    int totalRow = query.Count();
        //    var data = query.OrderByDescending(x => x.CreatedDate)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize);

        //    var paginationSet = new PagedResult<PostViewModel>()
        //    {
        //        Results = data.ProjectTo<PostViewModel>().ToList(),
        //        CurrentPage = page,
        //        RowCount = totalRow,
        //        PageSize = pageSize,
        //    };

        //    return paginationSet;
        //}

        public PagedResult<PostViewModel> GetAllPaging(Guid categoryId, string keyword, int page, int pageSize, string sortBy)
        {
            var query = _postRepository.GetAll().Where(c => c.Status == Status.Actived);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            if (categoryId != null)
                query = query.Where(x => x.CategoryId == categoryId);

            int totalRow = query.Count();
            switch (sortBy)
            {
                //case "price":
                //    query = query.OrderByDescending(x => x.Price);
                //    break;

                case "name":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "lastest":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            query = query.Skip((page - 1) * pageSize)
                .Take(pageSize);

            var data = query.ProjectTo<PostViewModel>().ToList();
            var paginationSet = new PagedResult<PostViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }
        public List<PostViewModel> GetListPostByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _postRepository.GetAll().Where(x => x.Status == Status.Actived && x.CategoryId == categoryId);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                //case "discount":
                //    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                //    break;

                //case "price":
                //    query = query.OrderBy(x => x.Price);
                //    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<PostViewModel>().ToList();
        }
        public List<PostViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _postRepository.GetAll().Where(x => x.Status == Status.Actived);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<PostViewModel>().ToList();
        }
        public List<PostViewModel> GetListPostByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in _postRepository.GetAll()
                        join pt in _postTagRepository.GetAll()
                        on p.Id equals pt.PostId
                        where pt.TagId == tagId && p.Status == Status.Actived
                        orderby p.CreatedDate descending
                        select p;

            totalRow = query.Count();

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var model = query.ProjectTo<PostViewModel>();
            return model.ToList();
        }
        public List<PostViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _postRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Name.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<PostViewModel>()
                .ToList();
        }
        public List<PostViewModel> GetListPost(string keyword)
        {
            var query = !string.IsNullOrEmpty(keyword) ?
                _postRepository.GetAll().Where(x => x.Name.Contains(keyword)).ProjectTo<PostViewModel>()
                : _postRepository.GetAll().ProjectTo<PostViewModel>();
            return query.ToList();
        }
        public List<string> GetListPostByName(string name)
        {
            return _postRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Name.Contains(name)).Select(y => y.Name).ToList();
        }
        public List<PostViewModel> GetLastest(int top)
        {
            return _postRepository.GetAll().Where(x => x.Status == Status.Actived).OrderByDescending(x => x.CreatedDate)
                .Take(top).ProjectTo<PostViewModel>().ToList();
        }
        public List<PostViewModel> GetHotPost(int top)
        {
            return _postRepository.GetAll().Where(x => x.Status == Status.Actived && x.HotFlag == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(top)
                .ProjectTo<PostViewModel>()
                .ToList();
        }
        public List<PostViewModel> GetRelatedPosts(Guid id, int top)
        {
            return _postRepository.GetAll().Where(x => x.Status == Status.Actived
                && x.Id != id)
            .OrderByDescending(x => x.CreatedDate)
            .Take(top)
            .ProjectTo<PostViewModel>()
            .ToList();
        }
        public void IncreaseView(Guid id)
        {
            var product = _postRepository.GetById(id);
            if (product.ViewCount.HasValue)
                product.ViewCount += 1;
            else
                product.ViewCount = 1;
        }
        //public List<TagViewModel> GetListTagByPostId(Guid id)
        //{
        //    return _postTagRepository.FindAll(x => x.PostId == id, c => c.Tag)        
        //        .Select(y => y.Tag)
        //        .ProjectTo<TagViewModel>()
        //        .ToList();
        //}
        public List<TagViewModel> GetListPostTag(string searchText)
        {
            return _tagRepository.GetAll(x => x.Type == CommonConstants.PostTag
            && searchText.Contains(x.Name)).ProjectTo<TagViewModel>().ToList();
        }
        public TagViewModel GetTag(string tagId)
        {
            return Mapper.Map<Tag, TagViewModel>(_tagRepository.Single(x => x.Id == tagId));
        }
       
      
    }
}