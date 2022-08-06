using AdIns.DataAccess;
using Confins.BusinessService.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.API;
using Training.DataAccess.Entities;
using Training.DataModel.TrainingModel;

namespace Training.BusinessService
{
    public class RefCourseService : BaseService, IRefCourseService
    {
        #region "CONSTRUCTOR"
        public RefCourseService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        #region GETDATA
        public List<RefCourse> listOfRefCourse(string courseName)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");

            List<RefCourse> listRefCourse = (from rc in context.RefCourses
                                             where rc.CourseName == courseName
                                             select rc).ToList();
            return listRefCourse;
        }
        public RefCourse GetRefCourseByCourseCode(string courseCode)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            RefCourse refCourse = (from c in context.RefCourses
                                   where c.CourseCode == courseCode
                                   select c).FirstOrDefault();
            return refCourse;
        }
        #endregion
    }
}
