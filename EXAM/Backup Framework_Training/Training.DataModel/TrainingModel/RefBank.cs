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
    public partial class RefBank : ITimestampable
    {
        #region Primitive Properties

        public virtual long RefBankId
        {
            get;
            set;
        }

        public virtual string BankCode
        {
            get;
            set;
        }

        public virtual string BankName
        {
            get;
            set;
        }

        public virtual Nullable<bool> IsActive
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

        private void FixupPdcHeader(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PdcHeader item in e.NewItems)
                {
                    item.RefBank = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (PdcHeader item in e.OldItems)
                {
                    if (ReferenceEquals(item.RefBank, this))
                    {
                        item.RefBank = null;
                    }
                }
            }
        }

        #endregion

    }
}
