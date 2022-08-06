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
    public class PembelianService : BaseService, IPembelianService
    {
        #region "CONSTRUCTOR"
        public PembelianService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        #region TRAINSACTION
        public void AddCust(Cust cust)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(cust);
            repository.SaveChanges();
        }
        public void EditCust()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        #endregion
        public Cust GetCustById(Int64 custId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Cust cust = (from s in context.Custs
                          where s.CustId == custId
                          select s).FirstOrDefault();
            return cust;
        }
        public CustAddr GetCustAddrById(Int64 custAddrId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            CustAddr custAddre = (from s in context.CustAddrs
                             where s.CustId == custAddrId
                             select s).FirstOrDefault();
            return custAddre;
        }
        public List<Cust> listOfCust()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Cust> listCust = (from s in context.Custs
                                     select s).ToList();
            return listCust;
        }
        
    }
}
