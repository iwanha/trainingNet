using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class ProductH :ITimestampable
    {
        #region Primitive Properties

        public virtual long ProductHId
        {
            get;
            set;
        }

        public virtual string BrandCode
        {
            get;
            set;
        }

        public virtual string BrandName
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
