﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspNetCore.Services.Dtos;
using AspNetCore.Services.ECommerce.Products.Dtos;
using AspNetCore.Data.Entities;

using AspNetCore.Infrastructure.Enums;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Utilities.Constants;
using AspNetCore.Utilities.Dtos;
using AspNetCore.Utilities.Helpers;
using System;

namespace AspNetCore.Services.ECommerce.Products
{
    public class ProductService : WebServiceBase<Product, Guid, ProductViewModel>, IProductService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, Guid> _productTagRepository;
        private readonly IRepository<ProductImage, Guid> _productImageRepository;
        private readonly IRepository<ProductQuantity, Guid> _productQuantityRepository;
        private readonly IRepository<WholePrice, Guid> _wholePriceRepository;
        private readonly IRepository<ProductCategory, Guid> _productCategoryRepository;
        private readonly IRepository<ProductWishlist, Guid> _productWishlistRepository;

        public ProductService(IRepository<Product, Guid> productRepository,
            IRepository<ProductTag, Guid> productTagRepository,
            IRepository<ProductWishlist, Guid> productWishlistRepository,
            IRepository<Tag, string> tagRepository,
            IRepository<ProductCategory, Guid> productCategoryRepository,
            IRepository<ProductImage, Guid> productImageRepository,
            IRepository<ProductQuantity, Guid> productQuantityRepository,
            IRepository<WholePrice, Guid> wholePriceRepository,
            IUnitOfWork unitOfWork) : base(productRepository, unitOfWork)
        {

            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _productImageRepository = productImageRepository;
            _productQuantityRepository = productQuantityRepository;
            _wholePriceRepository = wholePriceRepository;
            _productCategoryRepository = productCategoryRepository;
            _tagRepository = tagRepository;
            _productWishlistRepository = productWishlistRepository;
        }

        public override void Add(ProductViewModel productVm)
        {
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            if (string.IsNullOrEmpty(productVm.PageAlias))
                product.PageAlias = TextHelper.ToUnsignString(productVm.Name);

            if (string.IsNullOrEmpty(productVm.Code))
            {
                var category = _productCategoryRepository.GetById(productVm.CategoryId);
                var code = category.Code + (category.CurrentIdentity + 1).ToString("0000");
                category.CurrentIdentity += 1;
                product.Code = code;
            }

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Insert(tag);
                    }

                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    
                    _productTagRepository.Insert(productTag);
                    //product.ProductTags.Add(productTag);
                    //var query = from p in _productRepository.GetAll()
                    //            join pt in _productTagRepository.GetAll()
                    //            on p.Id equals pt.ProductId
                    //            where pt.TagId == tagId
                    //            select p;
                }
            }
                _productRepository.Insert(product);
        }

        public override void Update(ProductViewModel productVm)
        {
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            _productTagRepository.Delete(x => x.Id == product.Id);

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll().Where(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = t;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Insert(tag);
                    }
                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    _productTagRepository.Insert(productTag);
                    //product.ProductTags.Add(productTag);
                }
            }
            _productRepository.Update(product);
        }

        //public List<ProductViewModel> GetAll()
        //{
        //    return _productRepository.FindAll(c => c.ProductCategory, c => c.ProductTags)
        //        .ProjectTo<ProductViewModel>().ToList();
        //}

        public PagedResult<ProductViewModel> GetAllPaging(Guid? categoryId, string keyword, int page, int pageSize, string sortBy)
        {
            var query = _productRepository.GetAll().Where(c => c.Status == Status.Actived);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword) || x.Code.Contains(keyword));

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            int totalRow = query.Count();
            switch (sortBy)
            {
                case "price":
                    query = query.OrderByDescending(x => x.Price);
                    break;

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

            var data = query.ProjectTo<ProductViewModel>().ToList();
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }
   
    
        public List<ProductViewModel> GetLastest(int top)
        {
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived).OrderByDescending(x => x.CreatedDate)
                .Take(top).ProjectTo<ProductViewModel>().ToList();
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived && x.HotFlag == true)
                .OrderByDescending(x => x.CreatedDate)
                .Take(top)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public List<ProductViewModel> GetListProductByCategoryIdPaging(Guid categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived && x.CategoryId == categoryId);

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductViewModel>().ToList();
        }
        public List<ProductViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Name.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }
        public List<ProductViewModel> GetListProduct(string keyword)
        {
            IQueryable<ProductViewModel> query;
            if (!string.IsNullOrEmpty(keyword))
                query = _productRepository.GetAll().Where(x => x.Name.Contains(keyword)).ProjectTo<ProductViewModel>();
            else
                query = _productRepository.GetAll().ProjectTo<ProductViewModel>();
            return query.ToList();
        }
        public List<ProductViewModel> GetReatedProducts(Guid id, int top)
        {
            var product = _productRepository.GetById(id);
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived
                && x.Id != id && x.CategoryId == product.CategoryId)
            .OrderByDescending(x => x.CreatedDate)
            .Take(top)
            .ProjectTo<ProductViewModel>()
            .ToList();
        }
        public List<string> GetListProductByName(string name)
        {
            return _productRepository.GetAll().Where(x => x.Status == Status.Actived
            && x.Name.Contains(name)).Select(y => y.Name).ToList();
        }

        //public List<TagViewModel> GetListTagByProductId(Guid id)
        //{
        //    return _productTagRepository.FindAll(x => x.ProductId == id, c => c.Tag)
        //        .Select(y => y.Tag)
        //        .ProjectTo<TagViewModel>()
        //        .ToList();
        //}

        public TagViewModel GetTag(string tagId)
        {
            return Mapper.Map<Tag, TagViewModel>(_tagRepository.Single(x => x.Id == tagId));
        }

        public void IncreaseView(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product.ViewCount.HasValue)
                product.ViewCount += 1;
            else
                product.ViewCount = 1;
        }

        public List<ProductViewModel> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in _productRepository.GetAll()
                        join pt in _productTagRepository.GetAll()
                        on p.Id equals pt.ProductId
                        where pt.TagId == tagId
                        select p;
            totalRow = query.Count();

            var model = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ProjectTo<ProductViewModel>();
            return model.ToList();
        }
        public List<TagViewModel> GetListProductTag(string searchText)
        {
            return _tagRepository.GetAll(x => x.Type == CommonConstants.ProductTag
            && searchText.Contains(x.Name)).ProjectTo<TagViewModel>().ToList();
        }
        public void ImportExcel(string filePath, Guid categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                Product product;
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    product = new Product();
                    product.CategoryId = categoryId;
                    product.Name = workSheet.Cells[i, 1].Value.ToString();
                    product.Description = workSheet.Cells[i, 2].Value.ToString();
                    decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var originalPrice);
                    product.OriginalPrice = originalPrice;
                    decimal.TryParse(workSheet.Cells[i, 4].Value.ToString(), out var price);
                    product.Price = price;
                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString(), out var promotionPrice);

                    product.PromotionPrice = promotionPrice;
                    product.Content = workSheet.Cells[i, 6].Value.ToString();
                    product.MetaKeywords = workSheet.Cells[i, 7].Value.ToString();

                    product.MetaDescription = workSheet.Cells[i, 8].Value.ToString();
                    bool.TryParse(workSheet.Cells[i, 9].Value.ToString(), out var hotFlag);
                    product.HotFlag = hotFlag;
                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out var homeFlag);
                    product.HomeFlag = homeFlag;

                    product.Status = Status.Actived;

                    _productRepository.Insert(product);
                }
            }
        }
        public void AddImages(Guid productId, string[] images)
        {
            _productImageRepository.Delete(x => x.ProductId == productId);
            foreach (var image in images)
            {
                _productImageRepository.Insert(new ProductImage()
                {
                    Path = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
        }
        public List<ProductImageViewModel> GetImages(Guid productId)
        {
            //return _productImageRepository.FindAll(x => x.ProductId == productId)
            return _productImageRepository.GetAll().Where(x => x.ProductId == productId)
                .ProjectTo<ProductImageViewModel>().ToList();
        }
        public List<ProductViewModel> GetUpsellProducts(int top)
        {
            return _productRepository.GetAll().Where(x => x.PromotionPrice != null)
                .OrderByDescending(x => x.UpdatedDate)
                .Take(top)
                .ProjectTo<ProductViewModel>().ToList();
        }
        public PagedResult<ProductViewModel> GetMyWishlist(Guid userId, int page, int pageSize)
        {
            //var query = _productWishlistRepository.FindAll(c => c.UserId == userId, i => i.Product).Select(x => x.Product);
            var query = _productWishlistRepository.GetAll().Where(c => c.UserId == userId);
            int totalRow = query.Count();

            query = query.Skip((page - 1) * pageSize)
                .Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }
        //Selling product
        public bool SellProduct(Guid productId, int quantity)
        {
            //var product = _productRepository.FindById(productId);
            var product = _productRepository.GetById(productId);

            //if (product.Quantity < quantity)
            //    return false;
            //product.Quantity -= quantity;

            return true;
        }
        public void AddQuantity(Guid productId, List<ProductQuantityViewModel> quantities)
        {
            //_productQuantityRepository.RemoveMultiple(_productQuantityRepository.FindAll(x => x.ProductId == productId).ToList());
            _productQuantityRepository.Delete(x => x.ProductId == productId);
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Insert(new ProductQuantity()
                {
                    ProductId = productId,
                    ColorId = quantity.ColorId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
        }
        public List<ProductQuantityViewModel> GetQuantities(Guid productId)
        {
            //return _productQuantityRepository.FindAll(x => x.ProductId == productId).ProjectTo<ProductQuantityViewModel>().ToList();
            return _productQuantityRepository.GetAll().Where(x => x.ProductId == productId).ProjectTo<ProductQuantityViewModel>().ToList();
        }       
        public void AddWholePrice(Guid productId, List<WholePriceViewModel> wholePrices)
        {
            _wholePriceRepository.Delete(x => x.ProductId == productId);
            //_wholePriceRepository.RemoveMultiple(_wholePriceRepository.FindAll(x => x.ProductId == productId).ToList());
            foreach (var wholePrice in wholePrices)
            {
                _wholePriceRepository.Insert(new WholePrice()
                {
                    ProductId = productId,
                    FromQuantity = wholePrice.FromQuantity,
                    ToQuantity = wholePrice.ToQuantity,
                    Price = wholePrice.Price
                });
            }
        }
        public List<WholePriceViewModel> GetWholePrices(Guid productId)
        {
            return _wholePriceRepository.GetAll().Where(x => x.ProductId == productId).ProjectTo<WholePriceViewModel>().ToList();
        }

        public List<TagViewModel> GetListTagByProductId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}