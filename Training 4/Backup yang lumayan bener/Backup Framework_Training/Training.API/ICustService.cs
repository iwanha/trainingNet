using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface ICustService
    {
        void SaveCust(Cust cust);
        void EditCust();
        void DeleteCust(Int64 CustId);

        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        CustAddr GetCustAddrByCustId(Int64 custId);

        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        Cust GetCustByCustNo(string custNo);
    }
}
