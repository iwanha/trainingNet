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
    public partial class Agrmnt : ITimestampable
    {
        #region Primitive Properties

        public virtual long AgrmntId
        {
            get;
            set;
        }

        public virtual string AppNo
        {
            get;
            set;
        }

        public virtual string AgrmntNo
        {
            get;
            set;
        }

        public virtual Nullable<long> BranchId
        {
            get { return _branchId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_branchId != value)
                    {
                        if (Branch != null && Branch.BranchId != value)
                        {
                            Branch = null;
                        }
                        _branchId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _branchId;

        public virtual Nullable<long> CustomerId
        {
            get { return _customerId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_customerId != value)
                    {
                        if (Customer != null && Customer.CustomerId != value)
                        {
                            Customer = null;
                        }
                        _customerId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _customerId;

        public virtual Nullable<long> CurrencyId
        {
            get { return _currencyId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_currencyId != value)
                    {
                        if (RefCurrency != null && RefCurrency.RefCurrencyId != value)
                        {
                            RefCurrency = null;
                        }
                        _currencyId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _currencyId;

        public virtual string AppStep
        {
            get;
            set;
        }

        public virtual string ContractStat
        {
            get;
            set;
        }

        public virtual Nullable<decimal> InstAmt
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

        public virtual Branch Branch
        {
            get { return _branch; }
            set
            {
                if (!ReferenceEquals(_branch, value))
                {
                    var previousValue = _branch;
                    _branch = value;
                    FixupBranch(previousValue);
                }
            }
        }
        private Branch _branch;

        public virtual RefCurrency RefCurrency
        {
            get { return _refCurrency; }
            set
            {
                if (!ReferenceEquals(_refCurrency, value))
                {
                    var previousValue = _refCurrency;
                    _refCurrency = value;
                    FixupRefCurrency(previousValue);
                }
            }
        }
        private RefCurrency _refCurrency;

        public virtual Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                }
            }
        }
        private Customer _customer;

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

        private void FixupBranch(Branch previousValue)
        {
            if (previousValue != null && previousValue.Agrmnts.Contains(this))
            {
                previousValue.Agrmnts.Remove(this);
            }

            if (Branch != null)
            {
                if (!Branch.Agrmnts.Contains(this))
                {
                    Branch.Agrmnts.Add(this);
                }
                if (BranchId != Branch.BranchId)
                {
                    BranchId = Branch.BranchId;
                }
            }
            else if (!_settingFK)
            {
                BranchId = null;
            }
        }

        private void FixupRefCurrency(RefCurrency previousValue)
        {
            if (previousValue != null && previousValue.Agrmnts.Contains(this))
            {
                previousValue.Agrmnts.Remove(this);
            }

            if (RefCurrency != null)
            {
                if (!RefCurrency.Agrmnts.Contains(this))
                {
                    RefCurrency.Agrmnts.Add(this);
                }
                if (CurrencyId != RefCurrency.RefCurrencyId)
                {
                    CurrencyId = RefCurrency.RefCurrencyId;
                }
            }
            else if (!_settingFK)
            {
                CurrencyId = null;
            }
        }

        private void FixupCustomer(Customer previousValue)
        {
            if (previousValue != null && previousValue.Agrmnts.Contains(this))
            {
                previousValue.Agrmnts.Remove(this);
            }

            if (Customer != null)
            {
                if (!Customer.Agrmnts.Contains(this))
                {
                    Customer.Agrmnts.Add(this);
                }
                if (CustomerId != Customer.CustomerId)
                {
                    CustomerId = Customer.CustomerId;
                }
            }
            else if (!_settingFK)
            {
                CustomerId = null;
            }
        }

        private void FixupPdcHeader(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PdcHeader item in e.NewItems)
                {
                    item.Agrmnt = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PdcHeader item in e.OldItems)
                {
                    if (ReferenceEquals(item.Agrmnt, this))
                    {
                        item.Agrmnt = null;
                    }
                }
            }
        }

        #endregion
    }
}
