using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rule.Web;
using Training.API;
using AdIns.Service;
using Training.DataModel.TrainingDay4Model;

namespace Training
{
    public partial class ProductTRN : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindForm(1);
            }
        }

        private void bindForm(Int64 ProdId)
        {
            //ITrainingDay4Service ITrn4Svc = UnityFactory.Resolve<ITrainingDay4Service>();
            //if (ITrn4Svc != null)
            //{
            //    Product prod = ITrn4Svc.GetProductById(ProdId);
            //    lblProductName.Text = prod.ProductName;
            //}
        }
    }
}