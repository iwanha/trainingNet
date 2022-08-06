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

namespace Training.excercise
{
    public partial class AddPembelian : WebFormBase
    {
        #region PAGE CONTROL
        protected global::Rule.Web.WebUserControl.Lookup.UCLookupBrand ucBrand;
        protected global::Rule.Web.WebUserControl.UCDatePicker ucTranDt;
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
                    custId = Convert.ToInt64(base.RedirectState["custId"]);
                    //setEditScreen();
                    mode = SaveMode.Edit;
                }
                catch
                {
                    mode = SaveMode.Add;
                }
            }
            ucBrand.LookupBase.EnableTextChanged();
            ucBrand.LookupBase.txtInputObj.TextChanged += new EventHandler(ucBrand.LookupBase.txtInput_TextChanged);
        }
        #region TOOLBAR
        protected void lb_Toolbar_Submit_Click(object sender, EventArgs e)
        {
            IListOfCustomerService ips = (IListOfCustomerService)UnityFactory.Resolve<IListOfCustomerService>();

            ProdTrxH prodTrxH = new ProdTrxH();
            ProdTrxD prodTrxD = new ProdTrxD();
            prodTrxH.ProdTrxNo = txtProdTrxNo.Text;
            prodTrxD.Qty = Convert.ToInt64(txtQty.Text);
            ips.AddListOfProdTrxD(prodTrxD);
            ips.AddListOfProdTrxH(prodTrxH);
            RedirectUrl("~/Training/Exercise/AddPembelian.aspx");
        }
        #endregion
        protected void lb_Toolbar_Cancel_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/Exercise/PembelianPaging.aspx");
        }
        private void setEditScreen()
        {
            //IListOfCustomerService ips = (IListOfCustomerService)UnityFactory.Resolve<IListOfCustomerService>();
            //ProdTrxH prodTrxH = ips.GetProdTrxHById(prodTrxHId);
            //ProdTrxD prodTrxD = ips.GetProdTrxDById(prodTrxDId);
            //txtQty.Text = Convert.ToDecimal(prodTrxD.Qty;
            //txtProdTrxNo.Text = prodTrxH.ProdTrxNo;

        }

        private DataTable createDataTableProduct()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
            return dt;
        }

        protected void gvProductTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                List<ProductD> listProductD = new List<ProductD>();
                List<ProductH> listProductH = new List<ProductH>();
                List<ProdTrxD> listProdTrxD = new List<ProdTrxD>();

                Label lblProductHDelete = (Label)gvProductTemp.Rows[index].FindControl("lblProductHTemp");
                DataTable dt = createDataTableProduct();
                for (int i = 0; i < gvProductTemp.Rows.Count; i++)
                {
                    ProductD productD = new ProductD();
                    ProductH productH = new ProductH();
                    ProdTrxD prodTrxD = new ProdTrxD();

                    Label lblProductHTemp = (Label)gvProductTemp.Rows[i].FindControl("ProductName");
                    Label lblProductDTemp = (Label)gvProductTemp.Rows[i].FindControl("Price");
                    Label lblProdTrxDTemp = (Label)gvProductTemp.Rows[i].FindControl("Quantity");
                    Label lblTotalTemp = (Label)gvProductTemp.Rows[i].FindControl("Total");

                    //if (lblProductHDelete.Text != lblProductDTemp.Text)
                    if (i != index)
                    {
                        //productH.BrandName = lblProductHTemp.Text;
                        //productD.Price = Convert.ToDecimal(lblProductDTemp.Text);
                        //prodTrxD.Qty = Convert.ToInt64(lblProdTrxDTemp.Text);
                        //listProductD.Add(productD);
                        //listProductH.Add(productH);
                        //listProdTrxD.Add(prodTrxD);
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblProductHTemp.Text;
                        drowTemp[1] = lblProductDTemp.Text;
                        drowTemp[2] = lblProdTrxDTemp.Text;
                        drowTemp[3] = lblTotalTemp.Text;
                        dt.Rows.Add(drowTemp);
                    }
                }
                gvProductTemp.DataSource = listProductD;
                gvProductTemp.DataSource = listProductH;
                gvProductTemp.DataSource = listProdTrxD;
                gvProductTemp.DataBind();
                upFormTemp.Update();
            }
        }

        protected void lblAddToTemp_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        List<ProductD> listProductD = new List<ProductD>();
            //        List<ProductH> listProductH = new List<ProductH>();
            //        List<ProdTrxD> listProdTrxD = new List<ProdTrxD>();


            //        for (int i = 0; i < gvProductTemp.Rows.Count; i++)
            //        {
            //            ProductD productD = new ProductD();
            //            ProductH productH = new ProductH();
            //            ProdTrxD prodTrxD = new ProdTrxD();

            //            Label lblProductHTemp = (Label)gvProductTemp.Rows[i].FindControl("ProductName");
            //            Label lblProductDTemp = (Label)gvProductTemp.Rows[i].FindControl("Price");
            //            Label lblProdTrxDTemp = (Label)gvProductTemp.Rows[i].FindControl("Quantity");
            //            Label lblTotalTemp = (Label)gvProductTemp.Rows[i].FindControl("Total");

            //            productH.BrandName = lblProductHTemp.Text;
            //            productD.Price = Convert.ToDecimal(lblProductDTemp.Text);
            //            prodTrxD.Qty = Convert.ToInt64(lblProdTrxDTemp.Text);
            //            listProductD.Add(productD);
            //            listProductH.Add(productH);
            //            listProdTrxD.Add(prodTrxD);
            //        }
            //        gvProductTemp.DataSource = listProductD;
            //        gvProductTemp.DataSource = listProductH;
            //        gvProductTemp.DataSource = listProdTrxD;
            //        gvProductTemp.DataBind();
            //        upFormTemp.Update();
            //    }
            //    catch (Exception Ex)
            //    {
            //        throw new Exception(Ex.Message);
            //    }
            DataTable dt = createDataTableProduct();
            if (txtProductH.Enabled == true)
            {
                for (int i = 0; i < gvProductTemp.Rows.Count; i++)
                {
                    Label lblProductHTemp = (Label)gvProductTemp.Rows[i].FindControl("ProductName");
                    Label lblProductDTemp = (Label)gvProductTemp.Rows[i].FindControl("Price");
                    Label lblProdTrxDTemp = (Label)gvProductTemp.Rows[i].FindControl("Quantity");
                    Label lblTotalTemp = (Label)gvProductTemp.Rows[i].FindControl("Total");

                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = lblProductHTemp.Text;
                    drowTemp[1] = lblProductDTemp.Text;
                    drowTemp[2] = lblProdTrxDTemp.Text;
                    drowTemp[3] = lblTotalTemp.Text;
                    dt.Rows.Add(drowTemp);
                }
                txtProductH.Text = ucBrand.Brand;
                txtProductD.Text = ucBrand.Brand;
                DataRow drow = dt.NewRow();
                drow[0] = txtProductH.Text;
                drow[1] = txtProductD.Text;
                drow[2] = txtQty.Text;
                drow[3] = txtTotal.Text;
                dt.Rows.Add(drow);
            }
            txtProductH.Enabled = true;
            gvProductTemp.DataSource = dt;
            gvProductTemp.DataBind();
            upFormTemp.Update();
        }
    }
}