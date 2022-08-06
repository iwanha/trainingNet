using Rule.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.Ujian
{
    public partial class Ujian : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dtGvValidation = new List<Ujian>();
                #region Binding DropDownnList
                IList listDropDownBtn = new List<KeyValuePair<string, string>>();
                listDropDownBtn.Add(new KeyValuePair<string, string>("Pria", "P"));
                listDropDownBtn.Add(new KeyValuePair<string, string>("Wanita", "W"));

                ddlGender.DataSource = listDropDownBtn;
                ddlGender.DataTextField = "Key";
                ddlGender.DataValueField = "Value";
                ddlGender.DataBind();
                #endregion
            }
        }

        private DataTable createDataTableUser()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName");
            dt.Columns.Add("Umur");
            dt.Columns.Add("TinggiBadan");
            dt.Columns.Add("Alamat");
            dt.Columns.Add("Email");
            dt.Columns.Add("Gender");
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
                    Label lblAlamat = (Label)gvUser.Rows[i].FindControl("lblAlamat");
                    Label lblEmail = (Label)gvUser.Rows[i].FindControl("lblEmail");
                    Label lblGender = (Label)gvUser.Rows[i].FindControl("lblGender");

                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = lblUserName.Text;
                    drowTemp[1] = lblUmur.Text;
                    drowTemp[2] = lblTinggiBadan.Text;
                    drowTemp[3] = lblAlamat.Text;
                    drowTemp[4] = lblEmail.Text;
                    drowTemp[5] = lblGender.Text;
                    dt.Rows.Add(drowTemp);
                }
                DataRow drow = dt.NewRow();
                drow[0] = txtUsername.Text;
                drow[1] = txtUmur.Text;
                drow[2] = txtTinggiBadan.Text;
                drow[3] = txtAlamat.Text;
                drow[4] = txtEmail.Text;
                drow[5] = ddlGender.SelectedValue;
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
                    Label lblAlamat = (Label)gvUser.Rows[i].FindControl("lblAlamat");
                    Label lblEmail = (Label)gvUser.Rows[i].FindControl("lblEmail");
                    Label lblGender = (Label)gvUser.Rows[i].FindControl("lblGender");

                    if (i != index)
                    {
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblUserName.Text;
                        drowTemp[1] = lblUmur.Text;
                        drowTemp[2] = lblTinggiBadan.Text;
                        drowTemp[3] = lblAlamat.Text;
                        drowTemp[4] = lblEmail.Text;
                        drowTemp[5] = lblGender.Text;
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
                Label lblAlamat = (Label)gvUser.Rows[index].FindControl("lblAlamat");
                Label lblEmail = (Label)gvUser.Rows[index].FindControl("lblEmail");
                Label lblGender = (Label)gvUser.Rows[index].FindControl("lblGender");
                txtUsername.Text = lblUserName.Text;
                txtUsername.Enabled = false;
                txtUmur.Text = lblUmur.Text;
                txtTinggiBadan.Text = lblTinggiBadan.Text;
                txtAlamat.Text = lblAlamat.Text;
                txtEmail.Text = lblEmail.Text;
                ddlGender.SelectedValue = lblGender.Text;
                upAddUser.Update();
            }
        }
        #endregion
    }
}