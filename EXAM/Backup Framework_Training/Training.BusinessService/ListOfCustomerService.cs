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
    public class ListOfCustomerService : BaseService, IListOfCustomerService
    {
        #region Constructor and Private Variable
        public ListOfCustomerService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        public List<Cust> listOfCust()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Cust> listOfCust = (from c in context.Custs
                                    join p in context.ProdTrxHs on c.CustId equals p.CustId
                                     select c).ToList();
            return listOfCust;
        }
        #region GETDATA
        public Cust GetCustById(Int64 custId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Cust cust = (from c in context.Custs
                           where c.CustId == custId
                           select c).FirstOrDefault();
            return cust;
        }

        public CustAddr GetCustAddrById(Int64 custAddrId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            CustAddr custAddr = (from ca in context.CustAddrs
                             where ca.CustId == custAddrId
                         select ca).FirstOrDefault();
            return custAddr;
        }
        public void DeleteListOfCust(Int64 custId)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Cust cust = new Cust();
            cust.CustId = custId;
            repository.Delete(cust);
            repository.SaveChanges();
        }
        public ProdTrxD GetProdTrxDById(Int64 prodTrxDId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            ProdTrxD prodtrxd = (from ptd in context.ProdTrxDs
                                 where ptd.ProdTrxDId == prodTrxDId
                                 select ptd).FirstOrDefault();
            return prodtrxd;
        }
        public ProdTrxH GetProdTrxHById(Int64 prodTrxHId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            ProdTrxH prodtrxh = (from pth in context.ProdTrxHs
                                 where pth.ProdTrxHId == prodTrxHId
                                 select pth).FirstOrDefault();
            return prodtrxh;
        }
        public ProductD GetProductDById(Int64 productDId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            ProductD productd = (from pd in context.ProductDs
                                 where pd.ProductDId == productDId
                                 select pd).FirstOrDefault();
            return productd;
        }
        public ProductH GetProductHById(Int64 productHId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            ProductH producth = (from ph in context.ProductHs
                                 where ph.ProductHId == productHId
                                 select ph).FirstOrDefault();
            return producth;
        }
        #endregion

        #region TRANSACTION
        public void AddListOfCust(Cust cust)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(cust);
            repository.SaveChanges();
        }
        public void EditListOfCust()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }

        public void AddListOfProdTrxD(ProdTrxD prodTrxD)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(prodTrxD);
            repository.SaveChanges();
        }
        public void EditListOfProdTrxD()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }

        public void AddListOfProdTrxH(ProdTrxH prodTrxH)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(prodTrxH);
            repository.SaveChanges();
        }
        public void EditListOfProdTrxH()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        #endregion

        public void AddListOfProductD(ProductD productD)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(productD);
            repository.SaveChanges();
        }
        public void EditListOfproductD()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }

        public void AddListOfProductH(ProductH productH)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(productH);
            repository.SaveChanges();
        }
        public void EditListOfproductH()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
    }
}
