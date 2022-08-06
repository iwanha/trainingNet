using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IRefCourseService
    {
        List<RefCourse> listOfRefCourse(string courseName);
        RefCourse GetRefCourseByCourseCode(string courseCode);
    }
}
