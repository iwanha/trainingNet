using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IRefMasterService
    {
        List<RefMaster> listOfRefMaster(string masterType);
        RefMaster GetRefMasterByMasterCode(string masterCode);
    }
}
