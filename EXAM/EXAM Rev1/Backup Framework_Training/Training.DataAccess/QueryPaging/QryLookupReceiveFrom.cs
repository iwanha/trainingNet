using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QryLookupReceiveFrom : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QryLookupReceiveFrom(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from rm in context.Employees
                         select new
                         {
                             rm.EmployeeName,
                             rm.Position
                         });
            return query;
        }
    }
}
