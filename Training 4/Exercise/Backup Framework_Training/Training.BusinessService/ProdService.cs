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
    public partial class ProdService : BaseService, IProdService
    {
        public ProdService(IUnityContainer container)
            : base(container)
        {
        }
        public void AddProd(Prod prod)
        {
            IRepository repo = container.Resolve<IRepository>("TrainingEntities");
            repo.Add(prod);
            repo.SaveChanges();
        }
        public List<Prod> GetListOfProd()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Prod> prod = (from c in context.Prods
                               select c).ToList();
            return prod;
        }
        [Confins.BusinessService.Common.ServiceAttributes.TransactionSupported]
        public Prod GetProdByProdCode(string prodCode)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Prod prod = (from c in context.Prods
                         where c.ProdCode == prodCode
                         select c).FirstOrDefault();
            return prod;
        }
        
    }
    
}
