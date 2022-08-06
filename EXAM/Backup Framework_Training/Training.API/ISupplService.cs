using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingModel;

namespace Training.API
{
    public interface ISupplService
    {
        void DeleteSuppl(Int64 supplId);
        List<Suppl> listOfSuppl();
        void AddSuppl(Suppl suppl);
        void EditSuppl();
        Suppl GetSupplById(Int64 supplId);
    }
}
