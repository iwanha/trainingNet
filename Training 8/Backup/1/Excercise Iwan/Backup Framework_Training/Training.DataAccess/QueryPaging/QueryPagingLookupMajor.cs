using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QueryPagingLookupMajor : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QueryPagingLookupMajor(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }
        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from major in context.RefMajors
                         select new
                         {
                             major.MajorCode,
                             major.RefMajorId,
                             
                             major.MajorName,
                             major.Faculty
                         });
            return query;
        }
    }
}
