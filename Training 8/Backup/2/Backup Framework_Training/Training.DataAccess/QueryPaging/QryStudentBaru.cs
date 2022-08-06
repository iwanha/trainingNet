using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QryStudentBaru : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;

        public QryStudentBaru(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");
            var query = (from res in context.Students
                         select new
                         {
                             StudentId = res.StudentId,
                             Name = res.Name,
                             StudentNo = res.StudentNo,
                             Address = res.Address,
                             BirthPlace = res.BirthPlace,
                             BirthDt = res.BirthDt,
                             RefMajorId = res.RefMajorId
                         });
            return query;
        }
    }
}
