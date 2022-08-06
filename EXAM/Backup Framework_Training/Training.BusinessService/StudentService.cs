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
        public List<Student> listOfStud()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Student> listStud = (from student in context.Students
                                      join studentscore in context.StudentScores on student.StudentId equals studentscore.StudentId
                                      join refmajor in context.RefMajors on student.RefMajorId equals refmajor.RefMajorId
                                      select student).ToList();
            return listStud;
        }
        public RefCourse GetRefCourseById(Int64 refCourseId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            RefCourse refCourse = (from s in context.RefCourses
                                   where s.RefCourseId == refCourseId
                                   select s).FirstOrDefault();
            return refCourse;
        }
        public List<RefCourse> listOfCourse()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<RefCourse> listCourse = (from rc in context.RefCourses
                                          select rc).ToList();
            return listCourse;
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
        public void AddStud(Student student)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(student);
            repository.SaveChanges();
        }
        public void EditStud()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        #endregion
    }
}
