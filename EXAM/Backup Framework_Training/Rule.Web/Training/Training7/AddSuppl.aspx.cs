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
    public partial class AddSuppl : WebFormBase
    {
        #region PAGE CONTROL
        protected global::Rule.Web.WebUserControl.Lookup.UCLookupProduce ucProduce;
        #endregion
        #region PROPERTIES
        private enum SaveMode
        {
            Add,
            Edit,
        }
        private SaveMode mode
        {
            get { return (SaveMode)ViewState["mode"]; }
            set { ViewState["mode"] = value; }
        }
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
                    supplId = Convert.ToInt64(base.RedirectState["supplId"]);
                    setEditScreen();
                    mode = SaveMode.Edit;
                }
                catch
                {
                    mode = SaveMode.Add;
                }
            }
            ucProduce.TextBoxEnable = false;
            ucProduce.LookupBase.EnableTextChanged();
            ucProduce.LookupBase.txtInputObj.TextChanged += new EventHandler(ucProduce.LookupBase.txtInput_TextChanged);
        }
        #region TOOLBAR
        protected void lb_Toolbar_Submit_Click(object sender, EventArgs e)
        {
            ISupplService iss = (ISupplService)UnityFactory.Resolve<ISupplService>();
            if (mode == SaveMode.Add)
            {
                Suppl suppl = new Suppl();
                suppl.SupplNo = txtSupplNo.Text;
                suppl.SupplName = txtSupplName.Text;
                suppl.SupplAddress = txtSupplAddress.Text;
                suppl.SupplRt = txtSupplRt.Text;
                suppl.SupplRw = txtSupplRw.Text;
                suppl.SupplKelurahan = txtSupplKelurahan.Text;
                suppl.SupplKecamatan = txtSupplKecamatan.Text;
                suppl.SupplCity = txtSupplCity.Text;
                suppl.SupplZipcode = txtSupplZipcode.Text;
                suppl.Produce = ucProduce.ProduceCode;
                iss.AddSuppl(suppl);
            }
            else if (mode == SaveMode.Edit)
            {
                Suppl suppl = iss.GetSupplById(supplId);
                suppl.SupplNo = txtSupplNo.Text;
                suppl.SupplName = txtSupplName.Text;
                suppl.SupplAddress = txtSupplAddress.Text;
                suppl.SupplRt = txtSupplRt.Text;
                suppl.SupplRw = txtSupplRw.Text;
                suppl.SupplKelurahan = txtSupplKelurahan.Text;
                suppl.SupplKecamatan = txtSupplKecamatan.Text;
                suppl.SupplCity = txtSupplCity.Text;
                suppl.SupplZipcode = txtSupplZipcode.Text;
                suppl.Produce = ucProduce.ProduceCode;
                iss.EditSuppl();
            }
            RedirectUrl("~/Training/Training7/SupplPaging.aspx");
        }

        protected void lb_Toolbar_Cancel_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/Training7/SupplPaging.aspx");
        }
        #endregion
        #region METHOD
        private void setEditScreen()
        {
            ISupplService iss = (ISupplService)UnityFactory.Resolve<ISupplService>();
            IRefMasterService irms = (IRefMasterService)UnityFactory.Resolve<IRefMasterService>();
            Suppl suppl = iss.GetSupplById(supplId);
            txtSupplNo.Text = suppl.SupplNo;
            txtSupplName.Text = suppl.SupplName;
            txtSupplAddress.Text = suppl.SupplAddress;
            txtSupplCity.Text = suppl.SupplCity;
            txtSupplRt.Text = suppl.SupplRt;
            txtSupplRw.Text = suppl.SupplRw;
            txtSupplZipcode.Text = suppl.SupplZipcode;
            txtSupplKecamatan.Text = suppl.SupplKecamatan;
            txtSupplKelurahan.Text = suppl.SupplKelurahan;
            RefMaster rm = irms.GetRefMasterByMasterCode(suppl.Produce);
            ucProduce.Text = rm.Description;
            ucProduce.ProduceCode = suppl.Produce;
            txtSupplNo.Enabled = false;
        }
        #endregion
    }
}