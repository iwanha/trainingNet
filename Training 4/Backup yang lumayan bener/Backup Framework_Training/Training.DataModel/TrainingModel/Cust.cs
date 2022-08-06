using AdIns.DataModel.Audit;
using Confins.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    public partial class Cust : ITimestampable
    {
        #region Primitive Properties

        public virtual long CustId
        {
            get;
            set;
        }

        public virtual string CustNo
        {
            get;
            set;
        }

        public virtual string CustType
        {
            get;
            set;
        }

        public virtual string CustName
        {
            get;
            set;
        }

        public virtual string IdentityType
        {
            get;
            set;
        }

        public virtual string IdentityNo
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

        public virtual ICollection<CustAddr> CustAddr
        {
            get
            {
                if (_custAddr == null)
                {
                    var newCollection = new FixupCollection<CustAddr>();
                    newCollection.CollectionChanged += FixupCustAddr;
                    _custAddr = newCollection;
                }
                return _custAddr;
            }
            set
            {
                if (!ReferenceEquals(_custAddr, value))
                {
                    var previousValue = _custAddr as FixupCollection<CustAddr>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCustAddr;
                    }
                    _custAddr = value;
                    var newValue = value as FixupCollection<CustAddr>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCustAddr;
                    }
                }
            }
        }
        private ICollection<CustAddr> _custAddr;

        #endregion

        #region Association Fixup

        private void FixupCustAddr(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (CustAddr item in e.NewItems)
                {
                    item.Cust = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (CustAddr item in e.OldItems)
                {
                    if (ReferenceEquals(item.Cust, this))
                    {
                        item.Cust = null;
                    }
                }
            }
        }

        #endregion

    }
}
