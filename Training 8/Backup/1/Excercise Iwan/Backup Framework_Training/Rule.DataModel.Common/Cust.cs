//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Rule.DataModel.Common
{
    public partial class Cust
    {
        #region Primitive Properties
    
        public virtual long CustId
        {
            get;
            set;
        }
    
        public virtual string CustName
        {
            get;
            set;
        }
    
        public virtual string CustNo
        {
            get;
            set;
        }
    
        public virtual string CustAddr
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
