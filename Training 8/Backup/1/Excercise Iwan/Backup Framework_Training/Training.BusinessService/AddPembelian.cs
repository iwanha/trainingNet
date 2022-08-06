using Confins.BusinessService.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.API;

namespace Training.BusinessService
{
    public class AddPembelian : BaseService, IAddPembelian
    {
        #region Constructor and Private Variable
        public AddPembelian(IUnityContainer container)
            : base(container)
        {
        }
        #endregion

    }
}
