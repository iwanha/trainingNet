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

        public virtual System.DateTime BirthDt
        {
            get;
            set;
        }

        public virtual string BirthPlace
        {
            get;
            set;
        }

        public virtual string MaritalStatus
        {
            get;
            set;
        }

        public virtual string Religion
        {
            get;
            set;
        }

        public virtual string Nationality
        {
            get;
            set;
        }

        public virtual Nullable<decimal> MonthlyIncome
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

        public virtual ICollection<ProdTrxH> ProdTrxH
        {
            get
            {
                if (_prodTrxH == null)
                {
                    var newCollection = new FixupCollection<ProdTrxH>();
                    newCollection.CollectionChanged += FixupProdTrxH;
                    _prodTrxH = newCollection;
                }
                return _prodTrxH;
            }
            set
            {
                if (!ReferenceEquals(_prodTrxH, value))
                {
                    var previousValue = _prodTrxH as FixupCollection<ProdTrxH>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProdTrxH;
                    }
                    _prodTrxH = value;
                    var newValue = value as FixupCollection<ProdTrxH>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProdTrxH;
                    }
                }
            }
        }
        private ICollection<ProdTrxH> _prodTrxH;

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

        private void FixupProdTrxH(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProdTrxH item in e.NewItems)
                {
                    item.Cust = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (ProdTrxH item in e.OldItems)
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
