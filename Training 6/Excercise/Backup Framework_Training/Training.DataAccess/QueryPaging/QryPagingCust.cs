using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QryPagingCust : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;

        //Constructor
        public QryPagingCust(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");

            var query = (from cu in context.Custs// data2 yang akan ditampilkan di grid view
                         select new
                         {
                             CustId = cu.CustId,
                             CustNo = cu.CustNo,
                             CustName = cu.CustName,
                             BirthDt = cu.BirthDt,
                             MaritalStat = cu.MaritalStatus,
                             MonthlyIncome = cu.MonthlyIncome
                         });
            return query;
        }
    }
}
