using Rule.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.Contoh
{
    public partial class RepeaterGvX : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InsertDDL();
            }
        }
        #region METHOD
        private DataTable createDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustType");
            dt.Columns.Add("Name");
            dt.Columns.Add("IDNo");
            return dt;
        }

        private void InsertDDL()
        {
            List<KeyValuePair<string, string>> listType = new List<KeyValuePair<string, string>>();
            listType.Add(new KeyValuePair<string, string>("Personal", "P"));
            listType.Add(new KeyValuePair<string, string>("Company", "C"));
            ddlCustType.DataSource = listType;
            ddlCustType.DataTextField = "Key";
            ddlCustType.DataValueField = "Value";
            ddlCustType.DataBind();
        }
        #endregion

        protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblGridCustType = ((Label)e.Row.FindControl("lblGridCustType"));
                if (lblGridCustType.Text.ToUpper() == "P" || lblGridCustType.Text.ToUpper() == "C")
                {
                    if (lblGridCustType.Text.ToUpper() == "P")
                    {
                        lblGridCustType.Text = "Personal";
                    }
                    else
                    {
                        lblGridCustType.Text = "Company";
                    }
                }
            }
            upRepeater.Update();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = createDataTable();

                for (int i = 0; i < gvGrid.Rows.Count; i++)
                {
                    Label lblCustType = (Label)gvGrid.Rows[i].FindControl("lblGridCustType");
                    Label lblName = (Label)gvGrid.Rows[i].FindControl("lblGridCustName");
                    Label lblIDNo = (Label)gvGrid.Rows[i].FindControl("lblGridCustIDNo");

                    DataRow drowTemp = dt.NewRow();
                    drowTemp["CustType"] = lblCustType.Text;
                    drowTemp[1] = lblName.Text;
                    drowTemp[2] = lblIDNo.Text;
                    dt.Rows.Add(drowTemp);
                }

                lblErrorMsg.Visible = false;
                DataRow drow1 = dt.NewRow();
                drow1[0] = ddlCustType.SelectedValue;
                drow1[1] = txtUsername.Text;
                drow1[2] = txtIDNo.Text;
                dt.Rows.Add(drow1);

                rptName.DataSource = dt;
                rptName.DataBind();

                gvGrid.DataSource = dt;
                gvGrid.DataBind();

                upAddUser.Update();
                upRepeater.Update();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = ex.Message + ex.InnerException.Message;
            }
        }
    }
}