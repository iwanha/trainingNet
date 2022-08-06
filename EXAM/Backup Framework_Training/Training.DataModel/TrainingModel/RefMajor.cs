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
    public partial class RefMajor :ITimestampable
    {
        #region Primitive Properties

        public virtual long RefMajorId
        {
            get;
            set;
        }

        public virtual string MajorCode
        {
            get;
            set;
        }

        public virtual string Faculty
        {
            get;
            set;
        }

        public virtual string MajorName
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

        public virtual ICollection<Student> Students
        {
            get
            {
                if (_students == null)
                {
                    var newCollection = new FixupCollection<Student>();
                    newCollection.CollectionChanged += FixupStudents;
                    _students = newCollection;
                }
                return _students;
            }
            set
            {
                if (!ReferenceEquals(_students, value))
                {
                    var previousValue = _students as FixupCollection<Student>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupStudents;
                    }
                    _students = value;
                    var newValue = value as FixupCollection<Student>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupStudents;
                    }
                }
            }
        }
        private ICollection<Student> _students;

        #endregion

        #region Association Fixup

        private void FixupStudents(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Student item in e.NewItems)
                {
                    item.RefMajor = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Student item in e.OldItems)
                {
                    if (ReferenceEquals(item.RefMajor, this))
                    {
                        item.RefMajor = null;
                    }
                }
            }
        }

        #endregion

    }
}
