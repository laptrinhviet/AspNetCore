using System;
using System.Collections.Generic;
using AspNetCore.Services.ECommerce.Bills.Dtos;
using AspNetCore.Services.ECommerce.Products.Dtos;
using AspNetCore.Data.Enums;
using AspNetCore.Utilities.Dtos;
using AspNetCore.Data.Entities;

namespace AspNetCore.Services.ECommerce.Bills
{
    public interface IBillService : IWebServiceBase<Bill, Guid, BillViewModel>
    {
        //void Add(BillViewModel billVm);
        //void Update(BillViewModel billVm);

        //BillViewModel GetById(Guid id);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageSize, int page);
        void UpdateStatus(Guid orderId, BillStatus status);
        void ConfirmBill(Guid id);
        void CancelBill(Guid id);
        void PendingBill(Guid id);
        //
        void AddDetail(BillDetailViewModel billDetailVm);
        void DeleteDetail(Guid productId, Guid billId);
        BillViewModel GetDetailById(Guid billId);
        List<BillDetailViewModel> GetDetailsByBillId(Guid billId);
        //List<ColorViewModel> GetColors();
        //List<SizeViewModel> GetSizes();

        //
        //void Add(BillViewModel billVm);
        //void Update(BillViewModel billVm);
        //void Delete(Guid billId); not available----------------------------------------------------
        //BillViewModel GetById(Guid billId);
        //List<BillViewModel> GetAll(); not available----------------------------------------------------
        //PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageSize, int page);
        //void UpdateStatus(Guid billId, BillStatus status);
        //void ComfirmBill(Guid billId);
        //void CancelBill(Guid billId);
        //void PendingBill(Guid billId);
        //
        //void AddDetail(BillDetailViewModel billDetailVm);
        //void UpdateDetail(BillDetalViewModel billDetailVm);----------------------------------------------------
        //void DeleteDetail(Guid billId, Guid productId);       
        //BillDetailViewModel GetDetailById(Guid billId);
        //List<BillDetailViewModel> GetAll();----------------------------------------------------
        //PagedResult<BillDetailViewModel> GetAllPaging(string keyword, int pageSize, int page);----------------------------------------------------
        //List<BillDetailViewModel> GetDetailsByBillId(Guid billId);
        //List<SizeViewModel> GetSizes();
        //List<ColorViewModel> GetColors();
    }
}