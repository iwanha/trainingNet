using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QryPagingCustHandling : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;

        //Constructor
        public QryPagingCustHandling(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");

            var query = (from ch in context.CustomerHandlings
                         select new
                         {
                             CustomerHandlingId = ch.CustomerHandlingId,
                             RegistrationNo = ch.RegistrationNo,
                             CustomerName = ch.CustomerName,
                             ServiceCategory = ch.ServiceCategory,
                             AdminFee = ch.AdminFee,
                         });
            return query;
        }
    }
}
