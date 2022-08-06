using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.DataModel.TrainingDay4Model;

namespace Training.API
{
    public interface ITrainingDay4Service
    {
        Product GetProductById(Int64 productId);
    }
}
