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
    public class ExamCustomerService : BaseService, IExamCustomerService
    {
        #region Constructor and Private Variable
        public ExamCustomerService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        #region LIST
        public Agrmnt GetAgrmntsById(Int64 agrmntId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Agrmnt agrmnt = (from a in context.Agrmnts
                             where a.AgrmntId == agrmntId
                             select a).FirstOrDefault();
            return agrmnt;
        }
        public Customer GetCustomerByName(string customerName)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Customer customer = (from c in context.Customers
                               where c.CustomerName == customerName
                               select c).FirstOrDefault();
            return customer;
        }
        public RefCurrency GetCurrenciesByName(string currencyName)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            RefCurrency currency = (from cu in context.RefCurrencies
                                    where cu.CurrencyName == currencyName
                                    select cu).FirstOrDefault();
            return currency;
        }
        public PdcReceipt GetPdcReceiptByReceiveFrom(string receiveFrom)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            PdcReceipt receive = (from r in context.PdcReceipts
                                  where r.ReceiveFrom == receiveFrom
                                  select r).FirstOrDefault();
            return receive;
        }
        public Branch GetBranchById(Int64 branchId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Branch branch = (from b in context.Branches
                             where b.BranchId == branchId
                             select b).FirstOrDefault();
            return branch;
        }
        public List<Agrmnt> listOfAgrmnt()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Agrmnt> listAgrmnt = (from a in context.Agrmnts
                                       select a).ToList();
            return listAgrmnt;
        }
        public List<Customer> listOfCust()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Customer> listCust = (from c in context.Customers
                                       select c).ToList();
            return listCust;
        }
        public List<RefCurrency> listOfCurrency()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<RefCurrency> listCurrency = (from lc in context.RefCurrencies
                                              select lc).ToList();
            return listCurrency;
        }
        public List<PdcReceipt> listOfPdcReceipt()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<PdcReceipt> listPdcReceipt = (from pr in context.PdcReceipts
                                                select pr).ToList();
            return listPdcReceipt;
        }
        public List<PdcHeader> listOfPdcHeader()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<PdcHeader> listPdcHeader = (from pr in context.PdcHeaders
                                               select pr).ToList();
            return listPdcHeader;
        }
        public List<RefBank> listOfRefBank()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<RefBank> listRefBank = (from pr in context.RefBanks
                                             select pr).ToList();
            return listRefBank;
        }
        #endregion
        #region Transaction
        public void AddAgrmnt(Agrmnt agrmnt)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(agrmnt);
            repository.SaveChanges();
        }
        
        public void EditAgrmnt()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        public void AddPdcReceipt(PdcReceipt pdcReceipt)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(pdcReceipt);
            repository.SaveChanges();
        }

        public void EditPdcReceipt()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        public void AddPdcHeader(PdcHeader pdcHeader)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(pdcHeader);
            repository.SaveChanges();
        }

        public void EditPdcHeader()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        #endregion
        
    }
}
