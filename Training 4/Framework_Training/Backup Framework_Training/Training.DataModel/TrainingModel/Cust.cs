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
    public partial class Cust : ITimestampable
    {
        #region Primitive Properties

        public virtual long CustId
        {
            get;
            set;
        }

        public virtual string CustNo
        {
            get;
            set;
        }

        public virtual string CustType
        {
            get;
            set;
        }

        public virtual string CustName
        {
            get;
            set;
        }

        public virtual string IdentityType
        {
            get;
            set;
        }

        public virtual string IdentityNo
        {
            get;
            set;
        }

        public virtual System.DateTime BirthDt
        {
            get;
            set;
        }

        public virtual string BirthPlace
        {
            get;
            set;
        }

        public virtual string MaritalStatus
        {
            get;
            set;
        }

        public virtual string Religion
        {
            get;
            set;
        }

        public virtual string Nationality
        {
            get;
            set;
        }

        public virtual Nullable<decimal> MonthlyIncome
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
