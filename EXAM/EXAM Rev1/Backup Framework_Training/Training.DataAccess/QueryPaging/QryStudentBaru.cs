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
                         join refmajor in context.RefMajors on res.RefMajorId equals refmajor.RefMajorId
                         join studentscore in context.StudentScores on res.StudentId equals studentscore.StudentId
                         select new
                         {
                             refmajor.RefMajorId,
                             res.StudentId,
                             res.StudentNo,
                             res.Name,
                             refmajor.Faculty,
                             refmajor.MajorName,
                             studentscore.RefCourseId,
                             studentscore.Score
                         });
            return query;
        }
    }
}
