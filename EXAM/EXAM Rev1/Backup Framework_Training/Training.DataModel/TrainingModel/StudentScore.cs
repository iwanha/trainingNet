using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class StudentScore : ITimestampable
    {
        #region Primitive Properties

        public virtual long StudentScoreId
        {
            get;
            set;
        }

        public virtual long StudentId
        {
            get { return _studentId; }
            set
            {
                if (_studentId != value)
                {
                    if (Student != null && Student.StudentId != value)
                    {
                        Student = null;
                    }
                    _studentId = value;
                }
            }
        }
        private long _studentId;

        public virtual long RefCourseId
        {
            get { return _refCourseId; }
            set
            {
                if (_refCourseId != value)
                {
                    if (RefCourse != null && RefCourse.RefCourseId != value)
                    {
                        RefCourse = null;
                    }
                    _refCourseId = value;
                }
            }
        }
        private long _refCourseId;

        public virtual Nullable<decimal> Score
        {
            get;
            set;
        }

        #endregion

        #region Complex Properties

        public virtual UserTimestamp LastUserTimestamp
        {
            get { return _lastUserTimestamp; }
            set { _lastUserTimestamp = value; }
        }
        private UserTimestamp _lastUserTimestamp = new UserTimestamp();

        #endregion

        #region Navigation Properties

        public virtual RefCourse RefCourse
        {
            get { return _refCourse; }
            set
            {
                if (!ReferenceEquals(_refCourse, value))
                {
                    var previousValue = _refCourse;
                    _refCourse = value;
                    FixupRefCourse(previousValue);
                }
            }
        }
        private RefCourse _refCourse;

        public virtual Student Student
        {
            get { return _student; }
            set
            {
                if (!ReferenceEquals(_student, value))
                {
                    var previousValue = _student;
                    _student = value;
                    FixupStudent(previousValue);
                }
            }
        }
        private Student _student;

        #endregion

        #region Association Fixup

        private void FixupRefCourse(RefCourse previousValue)
        {
            if (previousValue != null && previousValue.StudentScore.Contains(this))
            {
                previousValue.StudentScore.Remove(this);
            }

            if (RefCourse != null)
            {
                if (!RefCourse.StudentScore.Contains(this))
                {
                    RefCourse.StudentScore.Add(this);
                }
                if (RefCourseId != RefCourse.RefCourseId)
                {
                    RefCourseId = RefCourse.RefCourseId;
                }
            }
        }

        private void FixupStudent(Student previousValue)
        {
            if (previousValue != null && previousValue.StudentScore.Contains(this))
            {
                previousValue.StudentScore.Remove(this);
            }

            if (Student != null)
            {
                if (!Student.StudentScore.Contains(this))
                {
                    Student.StudentScore.Add(this);
                }
                if (StudentId != Student.StudentId)
                {
                    StudentId = Student.StudentId;
                }
            }
        }

        #endregion

    }
}
