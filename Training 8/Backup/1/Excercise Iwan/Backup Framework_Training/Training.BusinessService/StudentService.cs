﻿using AdIns.DataAccess;
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
    public class StudentService : BaseService, IStudentService
    {
        #region "CONSTRUCTOR"
        public StudentService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        #region GETDATA
        public Student GetStudentById(Int64 studentId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Student stud = (from s in context.Students
                            where s.StudentId == studentId
                            select s).FirstOrDefault();
            return stud;
        }
        #endregion

        #region TRAINSACTION
        public void DeleteStudent(Int64 studentId)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Student student = new Student();
            student.StudentId = studentId;
            repository.Delete(studentId);
            repository.SaveChanges();
        }
        #endregion
    }
}
