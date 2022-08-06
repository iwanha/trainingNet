using AdIns.DataAccess.Query;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataAccess.Entities;

namespace Training.DataAccess.QueryPaging
{
    public class QryPagingStudent : BaseGenericQueryPagingExecutor
    {
        private IUnityContainer unityContainer;

        //Constructor
        public QryPagingStudent(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IQueryable GetQuery()
        {
            TrainingEntities context = (TrainingEntities)this.unityContainer.Resolve<TrainingEntities>("TrainingEntities");

            var query = (from rc in context.Students
                         select new
                         {
                             StudentNo = rc.StudentNo,
                             StudentId = rc.StudentId,
                             Name = rc.Name,
                             Address = rc.Address,
                             BirthPlace = rc.BirthPlace,
                             BirthDt = rc.BirthDt,
                             StudentScore = rc.StudentScore,
                             RefMajor = rc.RefMajor,
                             RefMajorId = rc.RefMajorId

                             //CustomerHandlingId = ch.CustomerHandlingId,
                             //RegistrationNo = ch.RegistrationNo,
                             //CustomerName = ch.CustomerName,
                             //ServiceCategory = ch.ServiceCategory,
                             //AdminFee = ch.AdminFee,
                         });
            return query;
        }
    }
}
