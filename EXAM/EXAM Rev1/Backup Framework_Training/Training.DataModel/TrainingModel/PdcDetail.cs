using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class PdcDetail : ITimestampable
    {
        #region Primitive Properties

        public virtual long PdcDetailId
        {
            get;
            set;
        }

        public virtual Nullable<long> PdcHeaderId
        {
            get { return _pdcHeaderId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_pdcHeaderId != value)
                    {
                        if (PdcHeader != null && PdcHeader.PdcHeaderId != value)
                        {
                            PdcHeader = null;
                        }
                        _pdcHeaderId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _pdcHeaderId;

        public virtual string PaymentAllocation
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual Nullable<decimal> Amount
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

        public virtual PdcHeader PdcHeader
        {
            get { return _pdcHeader; }
            set
            {
                if (!ReferenceEquals(_pdcHeader, value))
                {
                    var previousValue = _pdcHeader;
                    _pdcHeader = value;
                    FixupPdcHeader(previousValue);
                }
            }
        }
        private PdcHeader _pdcHeader;

        #endregion

        #region Association Fixup

        private bool _settingFK = false;

        private void FixupPdcHeader(PdcHeader previousValue)
        {
            if (previousValue != null && previousValue.PdcDetail.Contains(this))
            {
                previousValue.PdcDetail.Remove(this);
            }

            if (PdcHeader != null)
            {
                if (!PdcHeader.PdcDetail.Contains(this))
                {
                    PdcHeader.PdcDetail.Add(this);
                }
                if (PdcHeaderId != PdcHeader.PdcHeaderId)
                {
                    PdcHeaderId = PdcHeader.PdcHeaderId;
                }
            }
            else if (!_settingFK)
            {
                PdcHeaderId = null;
            }
        }

        #endregion

    }
}
