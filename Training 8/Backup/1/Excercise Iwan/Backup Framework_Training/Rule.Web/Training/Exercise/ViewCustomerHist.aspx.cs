using AdIns.Service;
using Rule.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.API;
using Training.DataModel.TrainingModel;

namespace Training.Exercise
{
    public partial class ViewCustomerHist : WebFormBase
    {
        #region PROPERTIES
        private Int64 custId
        {
            get { return (Int64)ViewState["custId"]; }
            set { ViewState["custId"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    custId = Int64.Parse(Request.QueryString["custId"].ToString());
                    setCustListScreen();
                }
                catch
                {
                }
            }
        }
        #region METHOD
        private void setCustListScreen()
        {
            IPembelianService iss = (IPembelianService)UnityFactory.Resolve<IPembelianService>();
            IRefMasterService irs = (IRefMasterService)UnityFactory.Resolve<IRefMasterService>();
            Cust cust = iss.GetCustById(custId);
            CustAddr custAddr = iss.GetCustAddrById(custId);
            lblCustId.Text = Convert.ToString(cust.CustId);
            lblCustNo.Text = cust.CustNo;
            lblCustName.Text = cust.CustName;
            lblAddress.Text = custAddr.Address + " " + custAddr.City;
            lblRt.Text = custAddr.Rt + "/" + custAddr.Rw;
            lblKelurahan.Text = custAddr.Kelurahan;
            lblKecamatan.Text = custAddr.Kecamatan;
            lblCity.Text = custAddr.City;
            lblZipcode.Text = custAddr.Zipcode;
            RefMaster rm = irs.GetRefMasterByMasterCode(cust.CustType);
            lblCustType.Text = rm.Description;
            
        }
        #endregion

        private DataTable createDataTableCustHist()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TranNo");
            dt.Columns.Add("TranDt");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Price");
            dt.Columns.Add("SubTotal");
            return dt;
        }

        protected void gvCustHistTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            //{

            //    List<ProductD> listProductD = new List<ProductD>();
            //    List<ProductH> listProductH = new List<ProductH>();
            //    List<ProdTrxD> listProdTrxD = new List<ProdTrxD>();

            //    DataTable dt = createDataTableCustHist();
            //    for (int i = 0; i < gvCustHistTemp.Rows.Count; i++)
            //    {

            //    }
            //}
        }
        
    }
}