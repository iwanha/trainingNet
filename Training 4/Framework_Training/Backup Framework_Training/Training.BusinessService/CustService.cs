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
    public partial class CustService : BaseService, ICustService
    {
        public CustService(IUnityContainer container)
            : base(container)
        {
        }

        public void SaveCust(Cust cust)
        {
            try
            {
                IRepository repo = container.Resolve<IRepository>("TrainingEntities");
                repo.Add(cust);
                repo.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EditCust()
        {
            try
            {
                IRepository repo = container.Resolve<IRepository>("TrainingEntities");
                repo.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteCust(Int64 CustId)
        {
            IRepository repo = container.Resolve<IRepository>("TrainingEntities");
            CustAddr custAddr = GetCustAddrByCustId(CustId);

            CustAddr ca = new CustAddr();
            ca.CustAddrId = custAddr.CustAddrId;
            repo.Delete(ca);

            Cust cust = new Cust();
            cust.CustId = CustId;
            repo.Delete(cust);

            repo.SaveChanges();
        }

        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        public CustAddr GetCustAddrByCustId(Int64 custId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            CustAddr custAddr = (from ca in context.CustAddrs
                                 where ca.CustId == custId
                                 select ca).FirstOrDefault();
            return custAddr;
        }

        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        public Cust GetCustByCustNo(string custNo)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Cust cust = (from c in context.Custs
                                 where c.CustNo == custNo
                                 select c).FirstOrDefault();
            return cust;
        }


    }
    

}
