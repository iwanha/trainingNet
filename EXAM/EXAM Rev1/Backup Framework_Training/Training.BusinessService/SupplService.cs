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
    public class SupplService : BaseService, ISupplService
    {
        #region "CONSTRUCTOR"
        public SupplService(IUnityContainer container)
            : base(container)
        {
        }
        #endregion
        public void DeleteSuppl(Int64 supplId)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Suppl suppl = new Suppl();
            suppl.SupplId = supplId;
            repository.Delete(suppl);
            repository.SaveChanges();
        }
        #region TRAINSACTION
        public void AddSuppl(Suppl suppl)
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.Add(suppl);
            repository.SaveChanges();
        }
        public void EditSuppl()
        {
            IRepository repository = container.Resolve<IRepository>("TrainingEntities");
            repository.SaveChanges();
        }
        #endregion
        public Suppl GetSupplById(Int64 supplId)
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            Suppl suppl = (from s in context.Suppls
                           where s.SupplId == supplId
                           select s).FirstOrDefault();
            return suppl;
        }
        public List<Suppl> listOfSuppl()
        {
            TrainingEntities context = (TrainingEntities)container.Resolve<BaseObjectContext>("TrainingEntities");
            List<Suppl> listSuppl = (from s in context.Suppls
                                     select s).ToList();
            return listSuppl;
        }
        
    }
}
