using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.API;
using Confins.BusinessService.Common;
using Microsoft.Practices.Unity;
using Training.DataModel.TrainingDay4Model;
using Training.DataAccess.Entities;
using AdIns.DataAccess;
using Rule.Common;

namespace Training.BusinessService
{
    [Confins.BusinessService.Common.ServiceAttributes.LogRequired]
    [Confins.BusinessService.Common.ServiceAttributes.TransactionRequired]
    public class TrainingDay4Service : BaseService, ITrainingDay4Service
    {
        #region "Constructor and Private Variables"
        public TrainingDay4Service(IUnityContainer container)
            : base(container)
        { }
        #endregion

        #region Product
        public virtual Product GetProductById(Int64 productId)
        {
            TrainingDay4Entities ent = (TrainingDay4Entities)container.Resolve<BaseObjectContext>(ConfinsEntitiesType.TRN.ToString());

            Product prod = (from prd in ent.Products1
                            where prd.ProductId == productId
                            select prd).FirstOrDefault();

            return prod;
        }
        #endregion
    }
}
