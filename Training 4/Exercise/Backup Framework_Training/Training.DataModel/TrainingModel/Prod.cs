using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    public partial class Prod : ITimestampable
    {
        #region Primitive Properties

        public virtual long ProdId
        {
            get;
            set;
        }

        public virtual string ProdCode
        {
            get;
            set;
        }

        public virtual string ProdName
        {
            get;
            set;
        }

        public virtual Nullable<decimal> Price
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
