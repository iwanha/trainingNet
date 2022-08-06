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

        public ObjectSet<RefMaster> RefMasters
        {
            get { return _refMasters ?? (_refMasters = CreateObjectSet<RefMaster>("RefMasters")); }
        }
        private ObjectSet<RefMaster> _refMasters;

        public ObjectSet<CustomerHandling> CustomerHandlings
        {
            get { return _customerHandlings ?? (_customerHandlings = CreateObjectSet<CustomerHandling>("CustomerHandlings")); }
        }
        private ObjectSet<CustomerHandling> _customerHandlings;

        public ObjectSet<Suppl> Suppls
        {
            get { return _suppls ?? (_suppls = CreateObjectSet<Suppl>("Suppls")); }
        }
        private ObjectSet<Suppl> _suppls;
        public ObjectSet<CustAddr> CustAddrs
        {
            get { return _custAddrs ?? (_custAddrs = CreateObjectSet<CustAddr>("CustAddrs")); }
        }
        private ObjectSet<CustAddr> _custAddrs;

        public ObjectSet<ProdTrxD> ProdTrxDs
        {
            get { return _prodTrxDs ?? (_prodTrxDs = CreateObjectSet<ProdTrxD>("ProdTrxDs")); }
        }
        private ObjectSet<ProdTrxD> _prodTrxDs;

        public ObjectSet<ProdTrxH> ProdTrxHs
        {
            get { return _prodTrxHs ?? (_prodTrxHs = CreateObjectSet<ProdTrxH>("ProdTrxHs")); }
        }
        private ObjectSet<ProdTrxH> _prodTrxHs;

        public ObjectSet<ProductD> ProductDs
        {
            get { return _productDs ?? (_productDs = CreateObjectSet<ProductD>("ProductDs")); }
        }
        private ObjectSet<ProductD> _productDs;

        public ObjectSet<ProductH> ProductHs
        {
            get { return _productHs ?? (_productHs = CreateObjectSet<ProductH>("ProductHs")); }
        }
        private ObjectSet<ProductH> _productHs;

        public ObjectSet<RefCourse> RefCourses
        {
            get { return _refCourses ?? (_refCourses = CreateObjectSet<RefCourse>("RefCourses")); }
        }
        private ObjectSet<RefCourse> _refCourses;

        public ObjectSet<RefMajor> RefMajors
        {
            get { return _refMajors ?? (_refMajors = CreateObjectSet<RefMajor>("RefMajors")); }
        }
        private ObjectSet<RefMajor> _refMajors;

        public ObjectSet<Student> Students
        {
            get { return _students ?? (_students = CreateObjectSet<Student>("Students")); }
        }
        private ObjectSet<Student> _students;

        public ObjectSet<StudentScore> StudentScores
        {
            get { return _studentScores ?? (_studentScores = CreateObjectSet<StudentScore>("StudentScores")); }
        }
        private ObjectSet<StudentScore> _studentScores;

        #endregion
    }
}
