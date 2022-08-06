using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class CustomerHandling : ITimestampable
    {
        #region Primitive Properties

        public virtual long CustomerHandlingId
        {
            get;
            set;
        }

        public virtual string RegistrationNo
        {
            get;
            set;
        }

        public virtual string CustomerName
        {
            get;
            set;
        }

        public virtual string MobilePhoneNo
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string ServiceCategory
        {
            get;
            set;
        }

        public virtual string MediaOfService
        {
            get;
            set;
        }

        public virtual string Chronologic
        {
            get;
            set;
        }

        public virtual string ServiceStatus
        {
            get;
            set;
        }

        public virtual Nullable<decimal> AdminFee
        {
            get;
            set;
        }

        public virtual Nullable<System.DateTime> CompletionDt
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
