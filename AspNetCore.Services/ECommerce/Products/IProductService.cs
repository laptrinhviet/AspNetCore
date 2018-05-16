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
            
        PagedResult<ProductViewModel> GetAllPaging(Guid? categoryId, string keyword, int page, int pageSize, string sortBy);

        List<ProductViewModel> GetLastest(int top);

        List<ProductViewModel> GetHotProduct(int top);

        List<ProductViewModel> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow);

        List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        List<ProductViewModel> GetListProduct(string keyword);

        List<ProductViewModel> GetReatedProducts(Guid id, int top);

        List<string> GetListProductByName(string name);

        List<TagViewModel> GetListTagByProductId(Guid id);

        TagViewModel GetTag(string tagId);
       
        void IncreaseView(Guid id);       
        List<ProductViewModel> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow);

        List<TagViewModel> GetListProductTag(string searchText);

        void ImportExcel(string filePath, Guid categoryId);

        void AddImages(Guid productId, string[] images);

        List<ProductImageViewModel> GetImages(Guid productId);

        List<ProductViewModel> GetUpsellProducts(int top);

        PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize);

        bool SellProduct(Guid productId, int quantity);
      
        void AddQuantity(Guid productId, List<ProductQuantityViewModel> quantities);

        List<ProductQuantityViewModel> GetQuantities(Guid productId);

        void AddWholePrice(Guid productId, List<WholePriceViewModel> wholePrices);

        List<WholePriceViewModel> GetWholePrices(Guid productId);
  
    }
}