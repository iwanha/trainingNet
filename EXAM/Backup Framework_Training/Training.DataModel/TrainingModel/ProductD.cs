using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class ProductD : ITimestampable
    {
        #region Primitive Properties

        public virtual long ProductDId
        {
            get;
            set;
        }

        public virtual Nullable<long> ProductHId
        {
            get;
            set;
        }

        public virtual string ModelCode
        {
            get;
            set;
        }

        public virtual string ModelName
        {
            get;
            set;
        }

        public virtual Nullable<decimal> Price
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> ReleaseDt
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

    }
}
