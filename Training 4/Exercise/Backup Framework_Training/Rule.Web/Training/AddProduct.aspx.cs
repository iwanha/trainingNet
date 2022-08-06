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
using Training.BusinessService;
using System.Data;

namespace Training
{
    public partial class AddProduct : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setGridListOfProd();
            }
        }

        private DataTable createDataTableProduct()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("lblProdCode");
            dt.Columns.Add("lblProdName");
            dt.Columns.Add("lblPrice");
            return dt;
        }

        private void setGridListOfProd()
        {
            IProdService ips = (IProdService)UnityFactory.Resolve<IProdService>();
            List<Prod> listProds = ips.GetListOfProd();
            gvProduct.DataSource = listProds;
            gvProduct.DataBind();
        }

        protected void lb_Toolbar_Add_Click(object sender, EventArgs e)
        { 
            IProdService ics = (IProdService)UnityFactory.Resolve<IProdService>();
            string user = "Training";
            DateTime date = DateTime.Now;

            Prod prod = new Prod();

            prod.ProdCode = txtProdCode.Text;
            prod.ProdName = txtProdName.Text;
            prod.Price = Convert.ToDecimal(txtPrice.Text);

            ics.AddProd(prod);

            RedirectUrl("~/Training/AddProduct.aspx");

            DataTable dt = createDataTableProduct();
            if (txtProdCode.Enabled == true)
            {
                for (int i = 0; i < gvProduct.Rows.Count; i++)
                {
                    Label lblProdCode = (Label)gvProduct.Rows[i].FindControl("lblProdCode");
                    Label lblProdName = (Label)gvProduct.Rows[i].FindControl("lblProdName");
                    Label lblPrice = (Label)gvProduct.Rows[i].FindControl("lblPrice");

                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = lblProdCode.Text;
                    drowTemp[1] = lblProdName.Text;
                    drowTemp[2] = Convert.ToDecimal(lblPrice.Text);
                    dt.Rows.Add(drowTemp);
                }
                DataRow drow = dt.NewRow();
                drow[0] = txtProdCode.Text;
                drow[1] = txtProdName.Text;
                drow[2] = Convert.ToDecimal(txtPrice.Text);
                dt.Rows.Add(drow);
            }
            txtProdCode.Enabled = true;
            gvProduct.DataSource = dt;
            gvProduct.DataBind();
            upProductTampil.Update();
        }

        protected void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbAll = (CheckBox)gvProduct.HeaderRow.FindControl("cbAll");
            if (cbAll.Checked)
            {
                for (int i = 0; i < gvProduct.Rows.Count; i++)
                {
                    CheckBox cbCheck = (CheckBox)gvProduct.Rows[i].FindControl("cbCheck");
                    cbCheck.Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < gvProduct.Rows.Count; i++)
                {
                    CheckBox cbCheck = (CheckBox)gvProduct.Rows[i].FindControl("cbCheck");
                    cbCheck.Checked = false;
                }
            }

        }

        protected void gvProdTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                List<Prod> listProd = new List<Prod>();
                List<Prod> listProdTemp = new List<Prod>();

                Label lblProdCodeDelete = (Label)gvProdTemp.Rows[index].FindControl("lblProdCodeTemp");

                for (int i = 0; i < gvProduct.Rows.Count; i++)
                {
                    Prod prod = new Prod();

                    Label lblProdCode = (Label)gvProduct.Rows[i].FindControl("lblProdCode");
                    Label lblProdName = (Label)gvProduct.Rows[i].FindControl("lblProdName");
                    Label lblPrice = (Label)gvProduct.Rows[i].FindControl("lblPrice");

                    prod.ProdCode = lblProdCode.Text;
                    prod.ProdName = lblProdName.Text;
                    prod.Price = Convert.ToDecimal(txtPrice.Text);
                    listProd.Add(prod);
                }
                for (int j = 0; j < gvProdTemp.Rows.Count; j++)
                {
                    Label lblProdCodeTemp = (Label)gvProdTemp.Rows[j].FindControl("lblProdCodeTemp");
                    Label lblProdNameTemp = (Label)gvProdTemp.Rows[j].FindControl("lblProdNameTemp");
                    Label lblPriceTemp = (Label)gvProdTemp.Rows[j].FindControl("lblPriceTemp");

                    Prod prod = new Prod();
                    if (lblProdCodeDelete.Text != lblProdCodeTemp.Text)
                    {
                        prod.ProdCode = lblProdCodeTemp.Text;
                        prod.ProdName = lblProdNameTemp.Text;
                        prod.Price = Convert.ToDecimal(lblPriceTemp.Text);
                        listProdTemp.Add(prod);
                    }
                    else
                    {
                        prod.ProdCode = lblProdCodeTemp.Text;
                        prod.ProdName = lblProdNameTemp.Text;
                        prod.Price = Convert.ToDecimal(lblPriceTemp.Text);
                        listProd.Add(prod);
                    }
                }
                gvProduct.DataSource = listProd;
                gvProduct.DataBind();
                gvProdTemp.DataSource = listProdTemp;
                gvProdTemp.DataBind();
                upForm.Update();
                upFormTemp.Update();
            }
        }

        protected void lbAddToTemp_Click(object sender, EventArgs e)
        {
            List<Prod> listProd = new List<Prod>();
            List<Prod> listProdTemp = new List<Prod>();

            for (int i = 0; i < gvProduct.Rows.Count; i++)
            {
                CheckBox cbCheck = (CheckBox)gvProduct.Rows[i].FindControl("cbCheck");
                Label lblProdCode = (Label)gvProduct.Rows[i].FindControl("lblProdCode");
                Label lblProdName = (Label)gvProduct.Rows[i].FindControl("lblProdName");
                Label lblPrice = (Label)gvProduct.Rows[i].FindControl("lblPrice");

                Prod prod = new Prod();
                if (cbCheck.Checked)
                {
                    prod.ProdCode = lblProdCode.Text;
                    prod.ProdName = lblProdName.Text;
                    prod.Price = Convert.ToDecimal(txtPrice);
                    listProdTemp.Add(prod);
                }
                else
                {
                    prod.ProdCode = lblProdCode.Text;
                    prod.ProdName = lblProdName.Text;
                    prod.Price = Convert.ToDecimal(lblPrice.Text);
                    listProd.Add(prod);
                }
            }
            for (int i = 0; i < gvProdTemp.Rows.Count; i++)
            {
                Prod prod = new Prod();
                Label lblProdCodeTemp = (Label)gvProdTemp.Rows[i].FindControl("lblProdCodeTemp");
                Label lblProdNameTemp = (Label)gvProdTemp.Rows[i].FindControl("lblProdNameTemp");
                Label lblPriceTemp = (Label)gvProdTemp.Rows[i].FindControl("lblPriceTemp");

                prod.ProdCode = lblProdCodeTemp.Text;
                prod.ProdName = lblProdNameTemp.Text;
                prod.Price = Convert.ToDecimal(lblPriceTemp.Text);
                listProdTemp.Add(prod);
            }
            gvProduct.DataSource = listProd;
            gvProduct.DataBind();
            gvProdTemp.DataSource = listProdTemp;
            gvProdTemp.DataBind();
            upForm.Update();
            upFormTemp.Update();
        }

        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                DataTable dt = createDataTableProduct();
                for (int i = 0; i < gvProduct.Rows.Count; i++)
                {
                    Label lblProdCode = (Label)gvProduct.Rows[i].FindControl("lblProdCode");
                    Label lblProdName = (Label)gvProduct.Rows[i].FindControl("lblProdName");
                    Label lblPrice = (Label)gvProduct.Rows[i].FindControl("lblPrice");

                    if (i != index)
                    {
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblProdCode.Text;
                        drowTemp[1] = lblProdName.Text;
                        drowTemp[2] = Convert.ToDecimal(lblPrice.Text);
                        dt.Rows.Add(drowTemp);
                    }
                }
                gvProduct.DataSource = dt;
                gvProduct.DataBind();

                upProductTampil.Update();
            }
            else if (e.CommandName == "ED")
            {
                Label lblProdCode = (Label)gvProduct.Rows[index].FindControl("lblProdCode");
                Label lblProdName = (Label)gvProduct.Rows[index].FindControl("lblProdName");
                Label lblPrice = (Label)gvProduct.Rows[index].FindControl("lblPrice");
                txtProdCode.Text = lblProdCode.Text;
                txtProdCode.Enabled = false;
                txtProdName.Text = lblProdName.Text;
                txtPrice.Text = lblPrice.Text;
                upForm.Update();
            }
        }
    }
}

