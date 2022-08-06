using Rule.Web;
using System;
using System.Collections;
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
        //protected void Page_Load(Object sender, EventArgs e)
        //{
        //    //if (!PostBack)
        //    //{
        //    //    InsertDDL();
        //    //}
        //}
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dtGvValidation = new List<GvValidationX>();
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
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("KtpNo");
            //dt.Columns.Add("TinggiBadan");
            dt.Columns.Add("Alamat");
            dt.Columns.Add("Email");
            dt.Columns.Add("Gender");
            return dt;
        }


        #region TOOLBAR
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = createDataTableUser();
            if (txtEmployeeName.Enabled == true)
            {
                for (int i = 0; i < gvUser.Rows.Count; i++)
                {
                    Label lblEmployeeName = (Label)gvUser.Rows[i].FindControl("lblEmployeeName");
                    Label lblKtpNo = (Label)gvUser.Rows[i].FindControl("lblKtpNo");
                    //Label lblTinggiBadan = (Label)gvUser.Rows[i].FindControl("lblTinggiBadan");
                    Label lblAlamat = (Label)gvUser.Rows[i].FindControl("lblAlamat");
                    Label lblEmail = (Label)gvUser.Rows[i].FindControl("lblEmail");
                    Label lblGender = (Label)gvUser.Rows[i].FindControl("lblGender");

                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = lblEmployeeName.Text;
                    drowTemp[1] = lblKtpNo.Text;
                    //drowTemp[2] = lblTinggiBadan.Text;
                    drowTemp[3] = lblAlamat.Text;
                    drowTemp[4] = lblEmail.Text;
                    drowTemp[5] = lblGender.Text;
                    dt.Rows.Add(drowTemp);
                }
                DataRow drow = dt.NewRow();
                drow[0] = txtEmployeeName.Text;
                drow[1] = txtKtpNo.Text;
                //drow[2] = txtTinggiBadan.Text;
                drow[3] = txtAlamat.Text;
                drow[4] = txtEmail.Text;
                drow[5] = ddlGender.SelectedValue;
                dt.Rows.Add(drow);
            }
            txtEmployeeName.Enabled = true;
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
                    Label lblEmployeeName = (Label)gvUser.Rows[i].FindControl("lblEmployeeName");
                    Label lblKtpNo = (Label)gvUser.Rows[i].FindControl("lblKtpNo");
                    //Label lblTinggiBadan = (Label)gvUser.Rows[i].FindControl("lblTinggiBadan");
                    Label lblAlamat = (Label)gvUser.Rows[i].FindControl("lblAlamat");
                    Label lblEmail = (Label)gvUser.Rows[i].FindControl("lblEmail");
                    Label lblGender = (Label)gvUser.Rows[i].FindControl("lblGender");
                    
                    if (i != index)
                    {
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblEmployeeName.Text;
                        drowTemp[1] = lblKtpNo.Text;
                        //drowTemp[2] = lblTinggiBadan.Text;
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
                Label lblEmployeeName = (Label)gvUser.Rows[index].FindControl("lblEmployeeName");
                Label lblKtpNo = (Label)gvUser.Rows[index].FindControl("lblKtpNo");
                //Label lblTinggiBadan = (Label)gvUser.Rows[index].FindControl("lblTinggiBadan");
                Label lblAlamat = (Label)gvUser.Rows[index].FindControl("lblAlamat");
                Label lblEmail = (Label)gvUser.Rows[index].FindControl("lblEmail");
                Label lblGender = (Label)gvUser.Rows[index].FindControl("lblGender");
                txtEmployeeName.Text = lblEmployeeName.Text;
                txtEmployeeName.Enabled = false;
                txtKtpNo.Text = lblKtpNo.Text;
                //txtTinggiBadan.Text = lblTinggiBadan.Text;
                txtAlamat.Text = lblAlamat.Text;
                txtEmail.Text = lblEmail.Text;
                ddlGender.SelectedValue = lblGender.Text;
                upAddUser.Update();
            }
        }
        #endregion
    }
}