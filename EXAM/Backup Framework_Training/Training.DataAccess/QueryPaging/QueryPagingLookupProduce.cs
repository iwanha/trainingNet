using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QueryPagingLookupProduce : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QueryPagingLookupProduce(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from res in context.RefMasters
                         where res.MasterType == "PRODUCE"
                         select new
                         {
                             res.MasterCode,    //  source sql yang nantinya ditampilkan di Unity-GenericLookup.config
                             res.Description
                         });
            return query;
        }
    }
}
