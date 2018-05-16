using System;

namespace AspNetCore.Services.ECommerce.Products.Dtos
{
    public class SizeViewModel
    {
        public Guid Id { get; set; }

        public int Width { set; get; }
        public int Height { set; get; }
    }
}