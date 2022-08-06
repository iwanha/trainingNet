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
    public partial class Student :ITimestampable
    {
        #region Primitive Properties

        public virtual long StudentId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string StudentNo
        {
            get;
            set;
        }

        public virtual string Address
        {
            get;
            set;
        }

        public virtual string BirthPlace
        {
            get;
            set;
        }

        public virtual System.DateTime BirthDt
        {
            get;
            set;
        }

        public virtual long RefMajorId
        {
            get { return _refMajorId; }
            set
            {
                if (_refMajorId != value)
                {
                    if (RefMajor != null && RefMajor.RefMajorId != value)
                    {
                        RefMajor = null;
                    }
                    _refMajorId = value;
                }
            }
        }
        private long _refMajorId;

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

        public virtual RefMajor RefMajor
        {
            get { return _refMajor; }
            set
            {
                if (!ReferenceEquals(_refMajor, value))
                {
                    var previousValue = _refMajor;
                    _refMajor = value;
                    FixupRefMajor(previousValue);
                }
            }
        }
        private RefMajor _refMajor;

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

        private void FixupRefMajor(RefMajor previousValue)
        {
            if (previousValue != null && previousValue.Students.Contains(this))
            {
                previousValue.Students.Remove(this);
            }

            if (RefMajor != null)
            {
                if (!RefMajor.Students.Contains(this))
                {
                    RefMajor.Students.Add(this);
                }
                if (RefMajorId != RefMajor.RefMajorId)
                {
                    RefMajorId = RefMajor.RefMajorId;
                }
            }
        }

        private void FixupStudentScore(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (StudentScore item in e.NewItems)
                {
                    item.Student = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (StudentScore item in e.OldItems)
                {
                    if (ReferenceEquals(item.Student, this))
                    {
                        item.Student = null;
                    }
                }
            }
        }

        #endregion

    }
}
