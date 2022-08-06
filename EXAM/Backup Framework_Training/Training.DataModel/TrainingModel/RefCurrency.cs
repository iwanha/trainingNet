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
    public partial class RefCurrency : ITimestampable
    {
        #region Primitive Properties

        public virtual long RefCurrencyId
        {
            get;
            set;
        }

        public virtual string CurrencyCode
        {
            get;
            set;
        }

        public virtual string CurrencyName
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

        public virtual ICollection<Agrmnt> Agrmnts
        {
            get
            {
                if (_agrmnts == null)
                {
                    var newCollection = new FixupCollection<Agrmnt>();
                    newCollection.CollectionChanged += FixupAgrmnts;
                    _agrmnts = newCollection;
                }
                return _agrmnts;
            }
            set
            {
                if (!ReferenceEquals(_agrmnts, value))
                {
                    var previousValue = _agrmnts as FixupCollection<Agrmnt>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAgrmnts;
                    }
                    _agrmnts = value;
                    var newValue = value as FixupCollection<Agrmnt>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAgrmnts;
                    }
                }
            }
        }
        private ICollection<Agrmnt> _agrmnts;

        #endregion

        #region Association Fixup

        private void FixupAgrmnts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Agrmnt item in e.NewItems)
                {
                    item.RefCurrency = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Agrmnt item in e.OldItems)
                {
                    if (ReferenceEquals(item.RefCurrency, this))
                    {
                        item.RefCurrency = null;
                    }
                }
            }
        }

        #endregion

    }
}
