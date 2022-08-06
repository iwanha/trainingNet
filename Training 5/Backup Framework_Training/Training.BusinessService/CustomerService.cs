using Confins.BusinessService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Training.DataModel.TrainingModel;
using Training.DataAccess.Entities;
using AdIns.DataAccess;
using Training.API;

namespace Training.BusinessService
{
    public class CustomerService : BaseService, ICustomerService //diinheritkan BaseService
    {
        #region CONSTRUCTOR
        public CustomerService(IUnityContainer container) :base(container) { }
        #endregion
        
        // hanya untuk mengambil data dari database tidak untuk insert, delete
        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        
        //  kalo public biasanya variabel pertama huruf besar ex : List. dan kalo private variabelnya huruf kecil
        public List<RefMaster> GetListRefMasterByMasterType(string masterTypeCode)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");

            List<RefMaster> listRefMaster = (from rm in context.RefMasters
                                             where rm.MasterType == masterTypeCode
                                             select rm).ToList();
            return listRefMaster;
        }

        // tidak boleh dipasangi Confins.Bussiness hanya getdata saja yg boleh
        public void AddEditData(Cust cu, string mode)   // fungsi untuk Add edit data
        {
            IRepository repository = (IRepository)container.Resolve<IRepository>("TrainingEntities");

            if (mode == "Add")
            {
                repository.Add(cu);
            }
            repository.SaveChanges();
        }


    }
}
