using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class UserTimestamp : ITimestampable
    {
        #region Primitive Properties

        public string UsrCrt
        {
            get;
            set;
        }

        public System.DateTime DtmCrt
        {
            get;
            set;
        }

        public string UsrUpd
        {
            get;
            set;
        }

        public System.DateTime DtmUpd
        {
            get;
            set;
        }

        #endregion

    }
}
