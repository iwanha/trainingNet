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
    public partial class GvValidationX : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private DataTable createDataTableUser()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName");
            dt.Columns.Add("Umur");
            dt.Columns.Add("TinggiBadan");
            dt.Columns.Add("Email");
            return dt;
        }

        #region TOOLBAR
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = createDataTableUser();
            if (txtUsername.Enabled == true)
            {
                for (int i = 0; i < gvUser.Rows.Count; i++)
                {
                    Label lblUserName = (Label)gvUser.Rows[i].FindControl("lblUserName");
                    Label lblUmur = (Label)gvUser.Rows[i].FindControl("lblUmur");
                    Label lblTinggiBadan = (Label)gvUser.Rows[i].FindControl("lblTinggiBadan");
                    Label lblEmail = (Label)gvUser.Rows[i].FindControl("lblEmail");

                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = lblUserName.Text;
                    drowTemp[1] = lblUmur.Text;
                    drowTemp[2] = lblTinggiBadan.Text;
                    drowTemp[3] = lblEmail.Text;
                    dt.Rows.Add(drowTemp);
                }
                DataRow drow = dt.NewRow();
                drow[0] = txtUsername.Text;
                drow[1] = txtUmur.Text;
                drow[2] = txtTinggiBadan.Text;
                drow[3] = txtEmail.Text;
                dt.Rows.Add(drow);
            }
            txtUsername.Enabled = true;
            gvUser.DataSource = dt;
            gvUser.DataBind();
            upUserTampil.Update();
        }
        #endregion

        #region GRID
        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                DataTable dt = createDataTableUser();
                for (int i = 0; i < gvUser.Rows.Count; i++)
                {
                    Label lblUserName = (Label)gvUser.Rows[i].FindControl("lblUserName");
                    Label lblUmur = (Label)gvUser.Rows[i].FindControl("lblUmur");
                    Label lblTinggiBadan = (Label)gvUser.Rows[i].FindControl("lblTinggiBadan");
                    Label lblEmail = (Label)gvUser.Rows[i].FindControl("lblEmail");
                    if (i != index)
                    {
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblUserName.Text;
                        drowTemp[1] = lblUmur.Text;
                        drowTemp[2] = lblTinggiBadan.Text;
                        drowTemp[3] = lblEmail.Text;
                        dt.Rows.Add(drowTemp);
                    }
                }
                gvUser.DataSource = dt;
                gvUser.DataBind();

                upUserTampil.Update();
            }
            else if (e.CommandName == "ED")
            {
                Label lblUserName = (Label)gvUser.Rows[index].FindControl("lblUserName");
                Label lblUmur = (Label)gvUser.Rows[index].FindControl("lblUmur");
                Label lblTinggiBadan = (Label)gvUser.Rows[index].FindControl("lblTinggiBadan");
                Label lblEmail = (Label)gvUser.Rows[index].FindControl("lblEmail");
                txtUsername.Text = lblUserName.Text;
                txtUsername.Enabled = false;
                txtUmur.Text = lblUmur.Text;
                txtTinggiBadan.Text = lblTinggiBadan.Text;
                txtEmail.Text = lblEmail.Text;
                upAddUser.Update();
            }
        }
        #endregion
    }
}