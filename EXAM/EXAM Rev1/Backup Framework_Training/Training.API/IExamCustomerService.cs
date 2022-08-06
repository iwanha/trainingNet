using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IExamCustomerService
    {
        List<Agrmnt> listOfAgrmnt();
        List<Customer> listOfCust();
        List<RefCurrency> listOfCurrency();
        List<PdcReceipt> listOfPdcReceipt();
        List<PdcHeader> listOfPdcHeader();
        List<RefBank> listOfRefBank();
        Agrmnt GetAgrmntsById(Int64 agrmntId);
        Customer GetCustomerById(Int64 customerId);
        RefCurrency GetCurrenciesById(Int64 currencyId);
        PdcReceipt GetPdcReceiptByReceiptId(Int64 receiptId);
        PdcDetail GetPdcDetailByDetailId(Int64 detailId);
        PdcHistory GetPdcHistoryByHistoryId(Int64 historyId);
        Branch GetBranchById(Int64 branchId);
        void AddAgrmnt(Agrmnt agrmnt);
        void EditAgrmnt();
        void AddPdcReceipt(PdcReceipt pdcReceipt);
        void EditPdcReceipt();
        void AddPdcHeader(PdcHeader pdcHeader);
        void EditPdcHeader();
        void AddPdcDetail(PdcDetail pdcDetail);
        void AddPdcHistory(PdcHistory pdcHistory);
        void EditPdcHistory();
    }
}
