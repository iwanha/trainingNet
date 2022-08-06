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
    public partial class PdcReceipt : ITimestampable
    {
        #region Primitive Properties

        public virtual long PdcReceiptId
        {
            get;
            set;
        }

        public virtual string PdcReceiptNo
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> ReceiveDate
        {
            get;
            set;
        }

        public virtual string ReceiveFrom
        {
            get;
            set;
        }

        public virtual Nullable<long> EmployeeId
        {
            get { return _employeeId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_employeeId != value)
                    {
                        if (Employee != null && Employee.EmployeeId != value)
                        {
                            Employee = null;
                        }
                        _employeeId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _employeeId;

        public virtual string AtasNamaPdc
        {
            get;
            set;
        }

        public virtual Nullable<int> NumOfPdc
        {
            get;
            set;
        }

        public virtual Nullable<decimal> TotalPdcAmt
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

        public virtual Employee Employee
        {
            get { return _employee; }
            set
            {
                if (!ReferenceEquals(_employee, value))
                {
                    var previousValue = _employee;
                    _employee = value;
                    FixupEmployee(previousValue);
                }
            }
        }
        private Employee _employee;

        public virtual ICollection<PdcHeader> PdcHeader
        {
            get
            {
                if (_pdcHeader == null)
                {
                    var newCollection = new FixupCollection<PdcHeader>();
                    newCollection.CollectionChanged += FixupPdcHeader;
                    _pdcHeader = newCollection;
                }
                return _pdcHeader;
            }
            set
            {
                if (!ReferenceEquals(_pdcHeader, value))
                {
                    var previousValue = _pdcHeader as FixupCollection<PdcHeader>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPdcHeader;
                    }
                    _pdcHeader = value;
                    var newValue = value as FixupCollection<PdcHeader>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPdcHeader;
                    }
                }
            }
        }
        private ICollection<PdcHeader> _pdcHeader;

        #endregion

        #region Association Fixup

        private bool _settingFK = false;

        private void FixupEmployee(Employee previousValue)
        {
            if (previousValue != null && previousValue.PdcReceipt.Contains(this))
            {
                previousValue.PdcReceipt.Remove(this);
            }

            if (Employee != null)
            {
                if (!Employee.PdcReceipt.Contains(this))
                {
                    Employee.PdcReceipt.Add(this);
                }
                if (EmployeeId != Employee.EmployeeId)
                {
                    EmployeeId = Employee.EmployeeId;
                }
            }
            else if (!_settingFK)
            {
                EmployeeId = null;
            }
        }

        private void FixupPdcHeader(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PdcHeader item in e.NewItems)
                {
                    item.PdcReceipt = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PdcHeader item in e.OldItems)
                {
                    if (ReferenceEquals(item.PdcReceipt, this))
                    {
                        item.PdcReceipt = null;
                    }
                }
            }
        }

        #endregion

    }
}
