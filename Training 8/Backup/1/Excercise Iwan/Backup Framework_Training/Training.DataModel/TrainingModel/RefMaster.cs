using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class RefMaster : ITimestampable
    {
        #region Primitive Properties

        public virtual long RefMasterId
        {
            get;
            set;
        }

        public virtual string MasterCode
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string MasterType
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
