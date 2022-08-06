using AdIns.DataModel.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.DataModel.TrainingModel
{
    [Serializable]
    public partial class ProdTrxD : ITimestampable
    {
        #region Primitive Properties

        public virtual long ProdTrxDId
        {
            get;
            set;
        }

        public virtual Nullable<long> ProdTrxHId
        {
            get { return _prodTrxHId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_prodTrxHId != value)
                    {
                        if (ProdTrxH != null && ProdTrxH.ProdTrxHId != value)
                        {
                            ProdTrxH = null;
                        }
                        _prodTrxHId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _prodTrxHId;

        public virtual Nullable<long> ProductDId
        {
            get;
            set;
        }

        public virtual Nullable<long> Qty
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

        public virtual ProdTrxH ProdTrxH
        {
            get { return _prodTrxH; }
            set
            {
                if (!ReferenceEquals(_prodTrxH, value))
                {
                    var previousValue = _prodTrxH;
                    _prodTrxH = value;
                    FixupProdTrxH(previousValue);
                }
            }
        }
        private ProdTrxH _prodTrxH;

        #endregion

        #region Association Fixup

        private bool _settingFK = false;

        private void FixupProdTrxH(ProdTrxH previousValue)
        {
            if (previousValue != null && previousValue.ProdTrxD.Contains(this))
            {
                previousValue.ProdTrxD.Remove(this);
            }

            if (ProdTrxH != null)
            {
                if (!ProdTrxH.ProdTrxD.Contains(this))
                {
                    ProdTrxH.ProdTrxD.Add(this);
                }
                if (ProdTrxHId != ProdTrxH.ProdTrxHId)
                {
                    ProdTrxHId = ProdTrxH.ProdTrxHId;
                }
            }
            else if (!_settingFK)
            {
                ProdTrxHId = null;
            }
        }

        #endregion
    }
}
