using System;
using System.Collections.Generic;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Dtos;
using AspNetCore.Services.ECommerce.Products.Dtos;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.ECommerce.Products
{
    public interface IProductService : IWebServiceBase<Product, Guid, ProductViewModel>
    {
        //void Add(ProductViewModel productVm);
        //void Update(ProductViewModel productVm);
        //void Delete(Guid id);
        //ProductViewModel GetById(Guid id);
        //List<ProductViewModel> GetAll();
        //PagedResult<ProductViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
        PagedResult<ProductViewModel> GetAllPaging(Guid categoryId, string keyword, int page, int pageSize, string sortBy);
        List<ProductViewModel> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow);
        List<ProductViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);
        List<ProductViewModel> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow);
        PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize);
        List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        List<ProductViewModel> GetListProduct(string keyword);
        List<string> GetListProductByName(string name);
        List<ProductViewModel> GetLastest(int top);
        List<ProductViewModel> GetHotProduct(int top);
        List<ProductViewModel> GetReatedProducts(Guid id, int top);
        List<ProductViewModel> GetUpsellProducts(int top);
        void IncreaseView(Guid id);
        List<TagViewModel> GetListTagByProductId(Guid id);
        List<TagViewModel> GetListProductTag(string searchText);
        TagViewModel GetTag(string tagId);
        List<ProductImageViewModel> GetImages(Guid productId);
        bool SellProduct(Guid productId, int quantity);
        void AddQuantity(Guid productId, List<ProductQuantityViewModel> quantities);
        List<ProductQuantityViewModel> GetQuantities(Guid productId);
        void AddWholePrice(Guid productId, List<WholePriceViewModel> wholePrices);
        List<WholePriceViewModel> GetWholePrices(Guid productId);
        void ImportExcel(string filePath, Guid categoryId);
        void AddImages(Guid productId, string[] images);                              
    }
}