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
        Customer GetCustomerByName(string customerName);
        RefCurrency GetCurrenciesByName(string currencyName);
        PdcReceipt GetPdcReceiptByReceiveFrom(string receiveFrom);
        Branch GetBranchById(Int64 branchId);
        void AddAgrmnt(Agrmnt agrmnt);
        void EditAgrmnt();
        void AddPdcReceipt(PdcReceipt pdcReceipt);
        void EditPdcReceipt();
        void AddPdcHeader(PdcHeader pdcHeader);
        void EditPdcHeader();
    }
}
