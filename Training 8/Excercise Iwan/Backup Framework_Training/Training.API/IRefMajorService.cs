using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IRefMajorService
    {
        List<RefMajor> listOfRefMajor();
        RefMajor GetRefMajorByMajorCode(string majorCode);
    }
}
