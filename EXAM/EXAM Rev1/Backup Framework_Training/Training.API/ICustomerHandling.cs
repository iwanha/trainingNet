using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface ICustomerHandling
    {
        List<RefMaster> GetListRefMasterByMasterType(string masterTypeCode);
        void AddEditData(CustomerHandling ch, string mode);
        CustomerHandling GetCustomerHandlingByCustomerHandlingId(Int64 customerHandlingId);
    }
}
