using AdIns.DataAccess;
using AdIns.DataAccess.Session;
using AdIns.DataAccess.Session.EF;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;


namespace Training.DataAccess.Entities
{
    public class TrainingEntities : BaseObjectContext
    {
        #region Constructors

        public TrainingEntities(ISession session, string entityContainerName)
            : base((EFSession)session, entityContainerName)
        {

        }

        #endregion
        #region ObjectSet Properties
        public ObjectSet<Cust> Custs
        {
            get { return _custs ?? (_custs = CreateObjectSet<Cust>("Custs")); }
        }
        private ObjectSet<Cust> _custs;

        public ObjectSet<CustAddr> CustAddrs
        {
            get { return _custAddrs ?? (_custAddrs = CreateObjectSet<CustAddr>("CustAddrs")); }
        }
        private ObjectSet<CustAddr> _custAddrs;
        
        #endregion
    }
}
