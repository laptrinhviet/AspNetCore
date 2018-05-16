using System.Collections.Generic;
using AspNetCore.Services.ECommerce.Bills.Dtos;
using AspNetCore.Services.ECommerce.Products.Dtos;
using AspNetCore.Data.Enums;
using AspNetCore.Utilities.Dtos;

namespace AspNetCore.Services.ECommerce.Bills
{
    public interface IBillService
    {
        void Create(BillViewModel billVm);

        void Update(BillViewModel billVm);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword,
            int pageIndex, int pageSize);

        BillViewModel GetDetail(int billId);

        BillDetailViewModel CreateDetail(BillDetailViewModel billDetailVm);

        void DeleteDetail(int productId, int billId, int colorId, int sizeId);

        void UpdateStatus(int orderId, BillStatus status);

        List<BillDetailViewModel> GetBillDetails(int billId);

        List<ColorViewModel> GetColors();

        List<SizeViewModel> GetSizes();

        void Save();

        void ConfirmBill(int id);

        void CancelBill(int id);

        void PendingBill(int id);
    }
}