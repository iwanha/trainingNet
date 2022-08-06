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
    public partial class ProdTrxH : ITimestampable
    {
        #region Primitive Properties

        public virtual long ProdTrxHId
        {
            get;
            set;
        }

        public virtual string ProdTrxNo
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> ProdTrxDt
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

        public virtual Nullable<decimal> TotalPrice
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

        public virtual ICollection<ProdTrxD> ProdTrxD
        {
            get
            {
                if (_prodTrxD == null)
                {
                    var newCollection = new FixupCollection<ProdTrxD>();
                    newCollection.CollectionChanged += FixupProdTrxD;
                    _prodTrxD = newCollection;
                }
                return _prodTrxD;
            }
            set
            {
                if (!ReferenceEquals(_prodTrxD, value))
                {
                    var previousValue = _prodTrxD as FixupCollection<ProdTrxD>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProdTrxD;
                    }
                    _prodTrxD = value;
                    var newValue = value as FixupCollection<ProdTrxD>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProdTrxD;
                    }
                }
            }
        }
        private ICollection<ProdTrxD> _prodTrxD;

        #endregion

        #region Association Fixup

        private bool _settingFK = false;

        private void FixupCust(Cust previousValue)
        {
            if (previousValue != null && previousValue.ProdTrxH.Contains(this))
            {
                previousValue.ProdTrxH.Remove(this);
            }

            if (Cust != null)
            {
                if (!Cust.ProdTrxH.Contains(this))
                {
                    Cust.ProdTrxH.Add(this);
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

        private void FixupProdTrxD(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProdTrxD item in e.NewItems)
                {
                    item.ProdTrxH = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (ProdTrxD item in e.OldItems)
                {
                    if (ReferenceEquals(item.ProdTrxH, this))
                    {
                        item.ProdTrxH = null;
                    }
                }   
            }
        }

        #endregion

    }
}
