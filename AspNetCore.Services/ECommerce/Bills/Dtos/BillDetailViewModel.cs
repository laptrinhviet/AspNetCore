using AspNetCore.Services.ECommerce.Products.Dtos;
using System;

namespace AspNetCore.Services.ECommerce.Bills.Dtos
{
    public class BillDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid BillId { set; get; }

        public Guid ProductId { set; get; }

        public Guid ColorId { get; set; }

        public Guid SizeId { get; set; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public BillViewModel Bill { set; get; }

        public ProductViewModel Product { set; get; }

        public ColorViewModel Color { set; get; }

        public SizeViewModel Size { set; get; }

    }
}