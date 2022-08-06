using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QueryPagingSuppl : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;
        public QueryPagingSuppl(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from suppl in context.Suppls
                         select new
                         {
                             suppl.SupplId,
                             suppl.SupplNo,
                             suppl.SupplName,
                             SupplAddress = suppl.SupplAddress + ", Rt: " + suppl.SupplRt + ", Rw: " + suppl.SupplRw + ", Kecamatan: " + suppl.SupplKecamatan + ", Kelurahan: "
                              + suppl.SupplKelurahan + " " + suppl.SupplCity + " " + suppl.SupplZipcode,
                             suppl.Produce
                         });
            return query;
        }
    }
}
