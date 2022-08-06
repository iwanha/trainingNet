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
    public partial class PdcHeader : ITimestampable
    {
        #region Primitive Properties

        public virtual long PdcHeaderId
        {
            get;
            set;
        }

        public virtual Nullable<long> PdcReceiptId
        {
            get { return _pdcReceiptId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_pdcReceiptId != value)
                    {
                        if (PdcReceipt != null && PdcReceipt.PdcReceiptId != value)
                        {
                            PdcReceipt = null;
                        }
                        _pdcReceiptId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _pdcReceiptId;

        public virtual Nullable<long> AgrmntId
        {
            get { return _agrmntId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_agrmntId != value)
                    {
                        if (Agrmnt != null && Agrmnt.AgrmntId != value)
                        {
                            Agrmnt = null;
                        }
                        _agrmntId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _agrmntId;

        public virtual string PdcNo
        {
            get;
            set;
        }

        public virtual Nullable<long> RefBankId
        {
            get { return _refBankId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_refBankId != value)
                    {
                        if (RefBank != null && RefBank.RefBankId != value)
                        {
                            RefBank = null;
                        }
                        _refBankId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _refBankId;

        public virtual Nullable<int> GiroSeqNo
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> ReceiveDate
        {
            get;
            set;
        }

        public virtual Nullable<decimal> PdcAmount
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> PdcDueDate
        {
            get;
            set;
        }

        public virtual string PdcType
        {
            get;
            set;
        }

        public virtual Nullable<bool> IsInkaso
        {
            get;
            set;
        }

        public virtual Nullable<bool> IsCummulative
        {
            get;
            set;
        }

        public virtual string PdcStatus
        {
            get;
            set;
        }

        public virtual string FisikStatus
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

        public virtual Agrmnt Agrmnt
        {
            get { return _agrmnt; }
            set
            {
                if (!ReferenceEquals(_agrmnt, value))
                {
                    var previousValue = _agrmnt;
                    _agrmnt = value;
                    FixupAgrmnt(previousValue);
                }
            }
        }
        private Agrmnt _agrmnt;

        public virtual ICollection<PdcDetail> PdcDetail
        {
            get
            {
                if (_pdcDetail == null)
                {
                    var newCollection = new FixupCollection<PdcDetail>();
                    newCollection.CollectionChanged += FixupPdcDetail;
                    _pdcDetail = newCollection;
                }
                return _pdcDetail;
            }
            set
            {
                if (!ReferenceEquals(_pdcDetail, value))
                {
                    var previousValue = _pdcDetail as FixupCollection<PdcDetail>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPdcDetail;
                    }
                    _pdcDetail = value;
                    var newValue = value as FixupCollection<PdcDetail>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPdcDetail;
                    }
                }
            }
        }
        private ICollection<PdcDetail> _pdcDetail;

        public virtual PdcReceipt PdcReceipt
        {
            get { return _pdcReceipt; }
            set
            {
                if (!ReferenceEquals(_pdcReceipt, value))
                {
                    var previousValue = _pdcReceipt;
                    _pdcReceipt = value;
                    FixupPdcReceipt(previousValue);
                }
            }
        }
        private PdcReceipt _pdcReceipt;

        public virtual RefBank RefBank
        {
            get { return _refBank; }
            set
            {
                if (!ReferenceEquals(_refBank, value))
                {
                    var previousValue = _refBank;
                    _refBank = value;
                    FixupRefBank(previousValue);
                }
            }
        }
        private RefBank _refBank;

        public virtual ICollection<PdcHistory> PdcHistory
        {
            get
            {
                if (_pdcHistory == null)
                {
                    var newCollection = new FixupCollection<PdcHistory>();
                    newCollection.CollectionChanged += FixupPdcHistory;
                    _pdcHistory = newCollection;
                }
                return _pdcHistory;
            }
            set
            {
                if (!ReferenceEquals(_pdcHistory, value))
                {
                    var previousValue = _pdcHistory as FixupCollection<PdcHistory>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPdcHistory;
                    }
                    _pdcHistory = value;
                    var newValue = value as FixupCollection<PdcHistory>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPdcHistory;
                    }
                }
            }
        }
        private ICollection<PdcHistory> _pdcHistory;

        #endregion

        #region Association Fixup

        private bool _settingFK = false;

        private void FixupAgrmnt(Agrmnt previousValue)
        {
            if (previousValue != null && previousValue.PdcHeader.Contains(this))
            {
                previousValue.PdcHeader.Remove(this);
            }

            if (Agrmnt != null)
            {
                if (!Agrmnt.PdcHeader.Contains(this))
                {
                    Agrmnt.PdcHeader.Add(this);
                }
                if (AgrmntId != Agrmnt.AgrmntId)
                {
                    AgrmntId = Agrmnt.AgrmntId;
                }
            }
            else if (!_settingFK)
            {
                AgrmntId = null;
            }
        }

        private void FixupPdcReceipt(PdcReceipt previousValue)
        {
            if (previousValue != null && previousValue.PdcHeader.Contains(this))
            {
                previousValue.PdcHeader.Remove(this);
            }

            if (PdcReceipt != null)
            {
                if (!PdcReceipt.PdcHeader.Contains(this))
                {
                    PdcReceipt.PdcHeader.Add(this);
                }
                if (PdcReceiptId != PdcReceipt.PdcReceiptId)
                {
                    PdcReceiptId = PdcReceipt.PdcReceiptId;
                }
            }
            else if (!_settingFK)
            {
                PdcReceiptId = null;
            }
        }

        private void FixupRefBank(RefBank previousValue)
        {
            if (previousValue != null && previousValue.PdcHeader.Contains(this))
            {
                previousValue.PdcHeader.Remove(this);
            }

            if (RefBank != null)
            {
                if (!RefBank.PdcHeader.Contains(this))
                {
                    RefBank.PdcHeader.Add(this);
                }
                if (RefBankId != RefBank.RefBankId)
                {
                    RefBankId = RefBank.RefBankId;
                }
            }
            else if (!_settingFK)
            {
                RefBankId = null;
            }
        }

        private void FixupPdcDetail(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PdcDetail item in e.NewItems)
                {
                    item.PdcHeader = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PdcDetail item in e.OldItems)
                {
                    if (ReferenceEquals(item.PdcHeader, this))
                    {
                        item.PdcHeader = null;
                    }
                }
            }
        }

        private void FixupPdcHistory(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PdcHistory item in e.NewItems)
                {
                    item.PdcHeader = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PdcHistory item in e.OldItems)
                {
                    if (ReferenceEquals(item.PdcHeader, this))
                    {
                        item.PdcHeader = null;
                    }
                }
            }
        }

        #endregion

    }
}
