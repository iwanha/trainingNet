using AdIns.DataAccess;
using Confins.BusinessService.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.API;
using Training.DataAccess.Entities;
using Training.DataModel.TrainingModel;

namespace Training.BusinessService
{
    public class CustomerHandlingService : BaseService, ICustomerHandling
    {
        #region CONSTRUCTOR
        public CustomerHandlingService(IUnityContainer container) : base(container) { }
        #endregion

        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]

        public List<RefMaster> GetListRefMasterByMasterType(string masterTypeCode)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");

            List<RefMaster> listRefMaster = (from rm in context.RefMasters
                                             where rm.MasterType == masterTypeCode
                                             select rm).ToList();
            return listRefMaster;
        }
        public void AddEditData(CustomerHandling ch, string mode)
        {
            IRepository repository = (IRepository)container.Resolve<IRepository>("TrainingEntities");

            if (mode == "Add")
            {
                repository.Add(ch);

            }
            repository.SaveChanges();
        }
        // get data untuk mendapatkan 1 data
        public CustomerHandling GetCustomerHandlingByCustomerHandlingId(Int64 customerHandlingId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");

            CustomerHandling costumerHandling = (from ch in context.CustomerHandlings
                                                 where ch.CustomerHandlingId == customerHandlingId
                                                 select ch).FirstOrDefault();
            return costumerHandling;
        }

    }
}
