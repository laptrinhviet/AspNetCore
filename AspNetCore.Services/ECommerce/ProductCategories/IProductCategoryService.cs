using System.Collections.Generic;
using AspNetCore.Services.ECommerce.ProductCategories.Dtos;
using AspNetCore.Data.Entities;
using System;

namespace AspNetCore.Services.ECommerce.ProductCategories
{
    public interface IProductCategoryService : IWebServiceBase<ProductCategory, Guid, ProductCategoryViewModel>
    {        
        void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items);
        void ReOrder(Guid sourceId, Guid targetId);
        List<ProductCategoryViewModel> GetAll(string keyword);
        List<ProductCategoryViewModel> GetAllByParentId(Guid? parentId);            
        List<ProductCategoryViewModel> GetHomeCategories(int top);
        //void Save();

    }
}