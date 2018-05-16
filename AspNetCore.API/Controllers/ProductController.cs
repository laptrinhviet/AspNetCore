using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Services.ECommerce.Products;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.API.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productService.GetAll());
        }
    }
}