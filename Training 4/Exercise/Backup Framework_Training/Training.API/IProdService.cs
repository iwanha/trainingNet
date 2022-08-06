using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IProdService
    {
        void AddProd(Prod prod);
        List<Prod> GetListOfProd();
        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        Prod GetProdByProdCode(string ProductCode);
    }
}
