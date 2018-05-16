using System.Collections.Generic;
using AspNetCore.Services.Content.Posts.Dtos;
using AspNetCore.Services.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.Content.Posts
{
    public interface IPostService
    {
        PostViewModel Add(PostViewModel post);

        void Update(PostViewModel post);

        void Delete(int id);

        List<PostViewModel> GetAll();

        PagedResult<PostViewModel> GetAllPaging(string keyword,int pageSize, int page);

        List<PostViewModel> GetLastest(int top);

        List<PostViewModel> GetHotProduct(int top);

        List<PostViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);

        List<PostViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        List<PostViewModel> GetList(string keyword);

        List<PostViewModel> GetReatedPosts(int id, int top);

        List<string> GetListByName(string name);

        PostViewModel GetById(int id);

        void Save();

        List<TagViewModel> GetListTagById(int id);

        TagViewModel GetTag(string tagId);

        void IncreaseView(int id);

        List<PostViewModel> GetListByTag(string tagId, int page, int pagesize, out int totalRow);

        List<TagViewModel> GetListTag(string searchText);
    }
}