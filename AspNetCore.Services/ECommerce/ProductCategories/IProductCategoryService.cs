using System.Collections.Generic;
using AspNetCore.Services.ECommerce.ProductCategories.Dtos;
using AspNetCore.Data.Entities;
using System;

namespace AspNetCore.Services.ECommerce.ProductCategories
{
    public interface IProductCategoryService : IWebServiceBase<ProductCategory, Guid, ProductCategoryViewModel>
    {              
        List<ProductCategoryViewModel> GetAll(string keyword);
        List<ProductCategoryViewModel> GetAllByParentId(Guid? parentId);            
        List<ProductCategoryViewModel> GetHomeCategories(int top);
        void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);
        void ReOrder(Guid sourceId, Guid targetId);
        //
        //void Add(ProductCategoryViewModel productCategoryVm);
        //void Update(ProductCategoryViewModel productCategoryVm);
        //void Delete(Guid id);
        //ProductCategoryViewModel GetById(Guid id);
        //List<ProductCategoryViewModel> GetAll();
        //PagedResult<ProductCategoryViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
    }
}