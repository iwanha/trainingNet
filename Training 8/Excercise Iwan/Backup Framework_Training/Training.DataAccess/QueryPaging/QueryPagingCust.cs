using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QueryPagingCust : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QueryPagingCust(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from cust in context.Custs
                         join custaddr in context.CustAddrs on cust.CustId equals custaddr.CustId
                         select new
                         {
                             cust.CustId,
                             cust.CustNo,
                             cust.CustName,
                             cust.CustType,
                             Address = custaddr.Address + " " + custaddr.AddressType + ", Rt: " + custaddr.Rt + ", Rw: " + custaddr.Rw
                             + ", Kelurahan: " + custaddr.Kelurahan + ", Kecamatan: " + custaddr.Kecamatan
                             + ", " + custaddr.City + ", " + custaddr.Zipcode
                         });

            return query;
        }
    }
}
