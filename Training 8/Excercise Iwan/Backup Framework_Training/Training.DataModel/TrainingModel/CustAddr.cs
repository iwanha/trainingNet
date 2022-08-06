using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class CustAddr : ITimestampable
    {
        #region Primitive Properties

        public virtual long CustAddrId
        {
            get;
            set;
        }

        public virtual Nullable<long> CustId
        {
            get { return _custId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_custId != value)
                    {
                        if (Cust != null && Cust.CustId != value)
                        {
                            Cust = null;
                        }
                        _custId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _custId;

        public virtual string Address
        {
            get;
            set;
        }

        public virtual string AddressType
        {
            get;
            set;
        }

        public virtual string Rt
        {
            get;
            set;
        }

        public virtual string Rw
        {
            get;
            set;
        }

        public virtual string Kelurahan
        {
            get;
            set;
        }

        public virtual string Kecamatan
        {
            get;
            set;
        }

        public virtual string City
        {
            get;
            set;
        }

        public virtual string Zipcode
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

        public virtual Cust Cust
        {
            get { return _cust; }
            set
            {
                if (!ReferenceEquals(_cust, value))
                {
                    var previousValue = _cust;
                    _cust = value;
                    FixupCust(previousValue);
                }
            }
        }
        private Cust _cust;

        #endregion

        #region Association Fixup

        private bool _settingFK = false;

        private void FixupCust(Cust previousValue)
        {
            if (previousValue != null && previousValue.CustAddr.Contains(this))
            {
                previousValue.CustAddr.Remove(this);
            }

            if (Cust != null)
            {
                if (!Cust.CustAddr.Contains(this))
                {
                    Cust.CustAddr.Add(this);
                }
                if (CustId != Cust.CustId)
                {
                    CustId = Cust.CustId;
                }
            }
            else if (!_settingFK)
            {
                CustId = null;
            }
        }

        #endregion
    }
}
