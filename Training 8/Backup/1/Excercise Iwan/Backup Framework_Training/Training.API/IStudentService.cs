using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface IStudentService
    {
        
        Student GetStudentById(Int64 studentId);
        void DeleteStudent(Int64 studentId);
    }
}
