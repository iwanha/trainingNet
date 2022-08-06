using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QryPagingExamCustomer : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QryPagingExamCustomer(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from Agrmnt in context.Agrmnts
                        join customer in context.Customers on Agrmnt.CustomerId equals customer.CustomerId
                        join currency in context.RefCurrencies on Agrmnt.CurrencyId equals currency.RefCurrencyId
                        select new
                        {
                            Agrmnt.AgrmntId,
                            Agrmnt.AgrmntNo,
                            customer.CustomerName,
                            Address = customer.Address + " ,RT: " + customer.Rt + " ,RW: " + customer.Rw + " ,Kel." + customer.Kelurahan + " ,Kec. " + customer.Kecamatan + " , " + customer.City + " , " + customer.ZipCode,
                            Agrmnt.AppStep,
                            Agrmnt.ContractStat,
                            Agrmnt.InstAmt,
                            currency.RefCurrencyId,
                            currency.CurrencyName,
                            currency.CurrencyCode,
                            Agrmnt.Branch,
                            Agrmnt.BranchId,
                            Agrmnt.AppNo,
                            Agrmnt.Customer,
                            Agrmnt.CustomerId,
                            Agrmnt.PdcHeader,
                            Agrmnt.RefCurrency
                        });
            return query;
        }
    }
}
