using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class Suppl : ITimestampable
    {
        #region Primitive Properties

        public virtual long SupplId
        {
            get;
            set;
        }

        public virtual string SupplNo
        {
            get;
            set;
        }

        public virtual string SupplName
        {
            get;
            set;
        }

        public virtual string SupplAddress
        {
            get;
            set;
        }

        public virtual string SupplRt
        {
            get;
            set;
        }

        public virtual string SupplRw
        {
            get;
            set;
        }

        public virtual string SupplKelurahan
        {
            get;
            set;
        }

        public virtual string SupplKecamatan
        {
            get;
            set;
        }

        public virtual string SupplCity
        {
            get;
            set;
        }

        public virtual string SupplZipcode
        {
            get;
            set;
        }

        public virtual string Produce
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
