﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Services.ECommerce.ProductCategories.Dtos;
using AspNetCore.Services.ECommerce.Products.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Helpers;
using System;

namespace AspNetCore.Services.ECommerce.ProductCategories
{
    public class ProductCategoryService : WebServiceBase<ProductCategory, Guid, ProductCategoryViewModel>, 
        IProductCategoryService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;
      
        public ProductCategoryService(IRepository<ProductCategory, Guid> productCategoryRepository,
            IRepository<Product, Guid> productRepository,
            IUnitOfWork unitOfWork) : base(productCategoryRepository, unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository; 
        }

        public override void Add(ProductCategoryViewModel productCategoryVm)
        {
            if (string.IsNullOrEmpty(productCategoryVm.PageAlias))
                productCategoryVm.PageAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Insert(productCategory);
        }
        public override void Update(ProductCategoryViewModel productCategoryVm)
        {
            if (string.IsNullOrEmpty(productCategoryVm.PageAlias))
                productCategoryVm.PageAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);

            _productCategoryRepository.Update(productCategory);
        }      
        public void UpdateParentId(Guid sourceId, Guid targetId, Dictionary<Guid, int> items)
        {
            //Update parent id for source
            var category = _productCategoryRepository.GetById(sourceId);
            category.ParentId = targetId;
            _productCategoryRepository.Update(category);

            //Get all sibling
            var sibling = _productCategoryRepository.GetAll().Where(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _productCategoryRepository.Update(child);
            }
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetAll().Where(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>().ToList();
            return _productCategoryRepository.GetAll().OrderBy(x => x.ParentId)
                .ProjectTo<ProductCategoryViewModel>()
                .ToList();
        }
        public List<ProductCategoryViewModel> GetAllByParentId(Guid? parentId)
        {
            return _productCategoryRepository.GetAll().Where(x => x.Status == Status.Actived && x.ParentId == parentId)
                .ProjectTo<ProductCategoryViewModel>()
                .ToList();
        }
        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository.GetAll().Where(x => x.HomeFlag == true)
                .OrderBy(x => x.HomeOrder).Take(top).ProjectTo<ProductCategoryViewModel>();
            var categories = query.ToList();
            foreach (var category in categories)
            {
                category.Products = _productRepository
                    .GetAll().Where(x => x.CategoryId == category.Id)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .ProjectTo<ProductViewModel>().ToList();
            }
            return categories;
        }
        public void ReOrder(Guid sourceId, Guid targetId)
        {
            var source = _productCategoryRepository.GetById(sourceId);
            var target = _productCategoryRepository.GetById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _productCategoryRepository.Update(source);
            _productCategoryRepository.Update(target);
        }

        //public List<ProductCategoryViewModel> GetAll()
        //{
        //    return _productCategoryRepository.GetAll().OrderBy(x => x.ParentId)
        //        .ProjectTo<ProductCategoryViewModel>()
        //        .ToList();
        //}

        //public void Save()
        //{
        //    _unitOfWork.Commit();
        //}
    }
}