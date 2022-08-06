using AdIns.DataAccess;
using Confins.BusinessService.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.API;
using Training.DataAccess.Entities;
using Training.DataModel.TrainingModel;

namespace Training.BusinessService
{
    public class RefMasterService : BaseService, IRefMasterService
    {
        #region "Constructor and Private Variable"
        public RefMasterService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        #region GETDATA
        public List<RefMaster> listOfRefMaster(string masterType)
        {
            TrainingEntities context = (TrainingEntities)
                container.Resolve<BaseObjectContext>("TrainingEntities");
            List<RefMaster> listRefMaster = (from rm in context.RefMasters
                                             where rm.MasterType == masterType
                                             select rm).ToList();
            return listRefMaster;
        }
        #endregion
        public RefMaster GetRefMasterByMasterCode(string masterCode)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            RefMaster refMaster = (from s in context.RefMasters
                                   where s.MasterCode == masterCode
                                   select s).FirstOrDefault();
            return refMaster;
        }
    }
}
