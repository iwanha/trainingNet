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
    public class RefMajorService : BaseService, IRefMajorService
    {
        #region "CONSTRUCTOR"
        public RefMajorService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        #region GETDATA
        public List<RefMajor> listOfRefMajor()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");

            List<RefMajor> listRefMajor = (from rm in context.RefMajors
                                           select rm).ToList();
            return listRefMajor;
        }
        public RefMajor GetRefMajorByMajorCode(string majorCode)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            RefMajor refMajor = (from m in context.RefMajors
                                 where m.MajorCode == majorCode
                                 select m).FirstOrDefault();
            return refMajor;
        }
        #endregion
    }
}
