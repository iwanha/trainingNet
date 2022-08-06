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
    public partial class Customer : ITimestampable
    {
        #region Primitive Properties

        public virtual long CustomerId
        {
            get;
            set;
        }

        public virtual string CustomerName
        {
            get;
            set;
        }

        public virtual string CustomerNo
        {
            get;
            set;
        }

        public virtual string CustomerType
        {
            get;
            set;
        }

        public virtual string Address
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

        public virtual string ZipCode
        {
            get;
            set;
        }

        public virtual string Phone
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
                    item.Customer = this;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Agrmnt item in e.OldItems)
                {
                    if (ReferenceEquals(item.Customer, this))
                    {
                        item.Customer = null;
                    }
                }
            }
        }

        #endregion

    }
}
