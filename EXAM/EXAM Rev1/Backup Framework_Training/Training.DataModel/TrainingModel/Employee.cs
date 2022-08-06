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
    public partial class Employee : ITimestampable
    {
        #region Primitive Properties

        public virtual long EmployeeId
        {
            get;
            set;
        }

        public virtual string EmployeeName
        {
            get;
            set;
        }

        public virtual string Position
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

        public virtual ICollection<PdcReceipt> PdcReceipt
        {
            get
            {
                if (_pdcReceipt == null)
                {
                    var newCollection = new FixupCollection<PdcReceipt>();
                    newCollection.CollectionChanged += FixupPdcReceipt;
                    _pdcReceipt = newCollection;
                }
                return _pdcReceipt;
            }
            set
            {
                if (!ReferenceEquals(_pdcReceipt, value))
                {
                    var previousValue = _pdcReceipt as FixupCollection<PdcReceipt>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPdcReceipt;
                    }
                    _pdcReceipt = value;
                    var newValue = value as FixupCollection<PdcReceipt>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPdcReceipt;
                    }
                }
            }
        }
        private ICollection<PdcReceipt> _pdcReceipt;

        #endregion

        #region Association Fixup

        private void FixupPdcReceipt(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PdcReceipt item in e.NewItems)
                {
                    item.Employee = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PdcReceipt item in e.OldItems)
                {
                    if (ReferenceEquals(item.Employee, this))
                    {
                        item.Employee = null;
                    }
                }
            }
        }

        #endregion

    }
}
