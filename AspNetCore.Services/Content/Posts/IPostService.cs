using System;
using System.Collections.Generic;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Content.Posts.Dtos;
using AspNetCore.Services.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Posts
{
    public interface IPostService : IWebServiceBase<Post, Guid, PostViewModel>
    {    
        PagedResult<PostViewModel> GetAllPaging(Guid categoryId, string keyword, int page, int pageSize, string sortBy);
        List<PostViewModel> GetListPostByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow);
        List<PostViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);
        List<PostViewModel> GetListPostByTag(string tagId, int page, int pagesize, out int totalRow);
        //PagedResult<PostViewModel> GetMyWishlist(Guid userId, int page, int pageSize);
        List<PostViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        List<PostViewModel> GetListPost(string keyword);
        List<string> GetListPostByName(string name);
        List<PostViewModel> GetLastest(int top);
        List<PostViewModel> GetHotPost(int top);
        List<PostViewModel> GetRelatedPosts(Guid id, int top);
        void IncreaseView(Guid id);
        //List<TagViewModel> GetListTagByPostId(Guid id);
        List<TagViewModel> GetListPostTag(string searchText);
        TagViewModel GetTag(string tagId);
        //
        //void Add(PostViewModel postVm);
        //void Update(PostViewModel postVm);
        //void Delete(Guid id);
        //PostViewModel GetById(Guid id);
        //List<PostViewModel> GetAll();
        //PagedResult<PostViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
        //void ImportExcel(string filePath, Guid categoryId);
        //void AddImages(Guid postId, string[] images);
        //List<PostViewModel> GetImages(Guid postId);
        //PagedResult<PostViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
    }
}