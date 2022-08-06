using AdIns.Service;
using Rule.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.API;
using Training.DataModel.TrainingModel;

namespace Training.Training7
{
    public partial class ViewSupplier : WebFormBase
    {
        #region PROPERTIES
        private Int64 supplId
        {
            get { return (Int64)ViewState["supplId"]; }
            set { ViewState["supplId"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    supplId = Int64.Parse(Request.QueryString["supplId"].ToString());
                    setSupplListScreen();
                }
                catch
                {
                }
            }
        }
        #region METHOD
        private void setSupplListScreen()
    {
        ISupplService iss = (ISupplService)UnityFactory.Resolve<ISupplService>();
        IRefMasterService irs = (IRefMasterService)UnityFactory.Resolve<IRefMasterService>();
        Suppl suppl = iss.GetSupplById(supplId);
        lblSupplId.Text = Convert.ToString(suppl.SupplId);
        lblSupplName.Text = suppl.SupplName;
        lblSupplNo.Text = suppl.SupplNo;
        RefMaster rm = irs.GetRefMasterByMasterCode(suppl.Produce);
        lblProduce.Text = rm.Description;
        lblSupplAddress.Text = suppl.SupplAddress + ", Rt: " + suppl.SupplRt + ", Rw: " + suppl.SupplRw + ", Kecamatan: " + suppl.SupplKecamatan + ", Kelurahan: "
                              + suppl.SupplKelurahan + " " + suppl.SupplCity + " " + suppl.SupplZipcode;
    }
#endregion
    }
}