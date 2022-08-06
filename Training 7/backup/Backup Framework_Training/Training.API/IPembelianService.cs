using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IPembelianService
    {
        void EditCust();
        void AddCust(Cust cust);
        Cust GetCustById(Int64 custId);
        List<Cust> listOfCust();
        CustAddr GetCustAddrById(Int64 custAddrId);
    }
}
