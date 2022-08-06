using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface ICustomerService
    {
        //ambil dari di bussiness service
        List<RefMaster> GetListRefMasterByMasterType(string masterTypeCode);
        void AddEditData(Cust cu, string mode); //  jangan insert public
    }
}
