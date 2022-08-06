using AdIns.DataModel.Audit;
using Confins.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class RefCourse : ITimestampable
    {
        #region Primitive Properties

        public virtual long RefCourseId
        {
            get;
            set;
        }

        public virtual string CourseCode
        {
            get;
            set;
        }

        public virtual string CourseName
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

        public virtual ICollection<StudentScore> StudentScore
        {
            get
            {
                if (_studentScore == null)
                {
                    var newCollection = new FixupCollection<StudentScore>();
                    newCollection.CollectionChanged += FixupStudentScore;
                    _studentScore = newCollection;
                }
                return _studentScore;
            }
            set
            {
                if (!ReferenceEquals(_studentScore, value))
                {
                    var previousValue = _studentScore as FixupCollection<StudentScore>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupStudentScore;
                    }
                    _studentScore = value;
                    var newValue = value as FixupCollection<StudentScore>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupStudentScore;
                    }
                }
            }
        }
        private ICollection<StudentScore> _studentScore;

        #endregion

        #region Association Fixup

        private void FixupStudentScore(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (StudentScore item in e.NewItems)
                {
                    item.RefCourse = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (StudentScore item in e.OldItems)
                {
                    if (ReferenceEquals(item.RefCourse, this))
                    {
                        item.RefCourse = null;
                    }
                }
            }
        }

        #endregion

    }
}
