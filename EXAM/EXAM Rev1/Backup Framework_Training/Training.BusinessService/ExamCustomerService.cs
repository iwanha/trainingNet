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
        public Customer GetCustomerById(Int64 customerId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Customer customer = (from c in context.Customers
                               where c.CustomerId == customerId
                               select c).FirstOrDefault();
            return customer;
        }
        public RefCurrency GetCurrenciesById(Int64 currencyId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            RefCurrency currency = (from cu in context.RefCurrencies
                                    where cu.RefCurrencyId == currencyId
                                    select cu).FirstOrDefault();
            return currency;
        }
        public PdcReceipt GetPdcReceiptByReceiptId(Int64 receiptId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            PdcReceipt receive = (from r in context.PdcReceipts
                                  where r.PdcReceiptId == receiptId
                                  select r).FirstOrDefault();
            return receive;
        }
        public PdcDetail GetPdcDetailByDetailId(Int64 detailId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            PdcDetail pdcDetail = (from pd in context.PdcDetails
                                 where pd.PdcDetailId == detailId
                                  select pd).FirstOrDefault();
            return pdcDetail;
        }
        public PdcHistory GetPdcHistoryByHistoryId(Int64 historyId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            PdcHistory pdcHistory = (from ph in context.PdcHistories
                                     where ph.PdcHistoryId == historyId
                                   select ph).FirstOrDefault();
            return pdcHistory;
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
        public void AddEditDataAgrmnt(Agrmnt ch, string mode)
        {
            IRepository repository = (IRepository)container.Resolve<IRepository>("TrainingEntities");

            if (mode == "Add")
            {
                repository.Add(ch);

            }
            repository.SaveChanges();
        }
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
        public void AddPdcDetail(PdcDetail pdcDetail)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(pdcDetail);
            repository.SaveChanges();
        }

        public void EditPdcDetail()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        public void AddPdcHistory(PdcHistory pdcHistory)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(pdcHistory);
            repository.SaveChanges();
        }

        public void EditPdcHistory()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }

        #endregion
        
    }
}
