using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Services.ECommerce.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.API.Controllers
{
    public class ProductCategoryController : ApiController
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }

        //[HttpGet]
        //[Route("getpaging")]
        //public IActionResult GetPaging()
        //{
        //    return new OkObjectResult(_productCategoryService.GetAll());
        //}

    }
}