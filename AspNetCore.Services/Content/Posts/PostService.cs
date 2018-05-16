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

namespace AspNetCore.Services.Content.Posts
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post,int> _blogRepository;
        private readonly IRepository<Tag,string> _tagRepository;
        private readonly IRepository<PostTag,int> _blogTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IRepository<Post, int> blogRepository,
            IRepository<PostTag, int> blogTagRepository,
            IRepository<Tag,string> tagRepository,
            IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _blogTagRepository = blogTagRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public PostViewModel Add(PostViewModel blogVm)
        {
            var blog = Mapper.Map<PostViewModel, Post>(blogVm);

            if (!string.IsNullOrEmpty(blog.Tags))
            {
                var tags = blog.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.PostTag
                        };
                        _tagRepository.Add(tag);
                    }

                    var blogTag = new PostTag { TagId = tagId };
                    blog.PostTags.Add(blogTag);
                }
            }
            _blogRepository.Add(blog);
            return blogVm;
        }

        public void Delete(int id)
        {
            _blogRepository.Remove(id);
        }

        public List<PostViewModel> GetAll()
        {
            return _blogRepository.FindAll(c => c.PostTags)
                .ProjectTo<PostViewModel>().ToList();
        }

        public PagedResult<PostViewModel> GetAllPaging(string keyword, int pageSize, int page = 1)
        {
            var query = _blogRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<PostViewModel>()
            {
                Results = data.ProjectTo<PostViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
            };

            return paginationSet;
        }

        public PostViewModel GetById(int id)
        {
            return Mapper.Map<Post, PostViewModel>(_blogRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostViewModel blog)
        {
            _blogRepository.Update(Mapper.Map<PostViewModel, Post>(blog));
            if (!string.IsNullOrEmpty(blog.Tags))
            {
                string[] tags = blog.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }
                    _blogTagRepository.RemoveMultiple(_blogTagRepository.FindAll(x => x.Id == blog.Id).ToList());
                    PostTag blogTag = new PostTag
                    {
                        BlogId = blog.Id,
                        TagId = tagId
                    };
                    _blogTagRepository.Add(blogTag);
                }
            }
        }

        public List<PostViewModel> GetLastest(int top)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Actived).OrderByDescending(x => x.CreatedDate)
                .Take(top).ProjectTo<PostViewModel>().ToList();
        }

        public List<PostViewModel> GetHotProduct(int top)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Actived && x.HotFlag == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(top)
                .ProjectTo<PostViewModel>()
                .ToList();
        }

        public List<PostViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _blogRepository.FindAll(x => x.Status == Status.Actived);

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

        public List<string> GetListByName(string name)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Actived
            && x.Name.Contains(name)).Select(y => y.Name).ToList();
        }

        public List<PostViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _blogRepository.FindAll(x => x.Status == Status.Actived
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

        public List<PostViewModel> GetReatedPots(int id, int top)
        {
            return _blogRepository.FindAll(x => x.Status == Status.Actived
                && x.Id != id)
            .OrderByDescending(x => x.CreatedDate)
            .Take(top)
            .ProjectTo<PostViewModel>()
            .ToList();
        }

        public List<TagViewModel> GetListTagById(int id)
        {
            return _blogTagRepository.FindAll(x => x.BlogId == id, c => c.Tag)
                .Select(y => y.Tag)
                .ProjectTo<TagViewModel>()
                .ToList();
        }

        public void IncreaseView(int id)
        {
            var product = _blogRepository.FindById(id);
            if (product.ViewCount.HasValue)
                product.ViewCount += 1;
            else
                product.ViewCount = 1;
        }

        public List<PostViewModel> GetListByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in _blogRepository.FindAll()
                        join pt in _blogTagRepository.FindAll()
                        on p.Id equals pt.PostId
                        where pt.TagId == tagId && p.Status == Status.Actived
                        orderby p.CreatedDate descending
                        select p;

            totalRow = query.Count();

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var model = query.ProjectTo<PostViewModel>();
            return model.ToList();
        }

        public TagViewModel GetTag(string tagId)
        {
            return Mapper.Map<Tag, TagViewModel>(_tagRepository.FindSingle(x => x.Id == tagId));
        }

        public List<PostViewModel> GetList(string keyword)
        {
            var query = !string.IsNullOrEmpty(keyword) ?
                _blogRepository.FindAll(x => x.Name.Contains(keyword)).ProjectTo<PostViewModel>()
                : _blogRepository.FindAll().ProjectTo<PostViewModel>();
            return query.ToList();
        }

        public List<TagViewModel> GetListTag(string searchText)
        {
            return _tagRepository.FindAll(x => x.Type == CommonConstants.ProductTag
            && searchText.Contains(x.Name)).ProjectTo<TagViewModel>().ToList();
        }

        public List<PostViewModel> GetReatedPosts(int id, int top)
        {
            throw new System.NotImplementedException();
        }
    }
}