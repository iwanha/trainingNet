using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QueryPagingLookupBrand : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QueryPagingLookupBrand(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from pd in context.ProductDs
                         join ph in context.ProductHs on pd.ProductHId equals ph.ProductHId
                         select new
                         {
                             pd.ProductDId,
                             Brand = pd.ModelName + " " + ph.BrandName,
                             pd.Price

                         });
            return query;
        }
        
    }
}
