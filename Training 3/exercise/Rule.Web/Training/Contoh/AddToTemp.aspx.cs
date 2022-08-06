using Rule.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.DataModel;

namespace Training.Contoh
{
    public partial class AddToTemp : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InsertDataTable();
            }
        }
        #region METHOD
        private void InsertDataTable()
        {
            List<Cust> listCust = new List<Cust>();

            for (int i = 0; i < 5; i++)
            {
                Cust cust = new Cust();
                cust.Nama = "Agus" + i;
                cust.JenisKelamin = "Laki Laki";
                cust.TanggalLahir = "22-01-1992";
                cust.TempatLahir = "Jakarta";
                cust.Alamat = "Jalan Kebun Jeruk Raya No 80";
                listCust.Add(cust);
            }

            gvCustomer.DataSource = listCust;
            gvCustomer.DataBind();
        }
        #endregion
        #region GRID
        protected void cbCheck_change(object sender, EventArgs e)
        {
            CheckBox cbAll = (CheckBox)gvCustomer.HeaderRow.FindControl("cbAll");
            if (cbAll.Checked)
            {
                for (int i = 0; i < gvCustomer.Rows.Count; i++)
                {
                    CheckBox cbCheck = (CheckBox)gvCustomer.Rows[i].FindControl("cbCheck");
                    cbCheck.Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < gvCustomer.Rows.Count; i++)
                {
                    CheckBox cbCheck = (CheckBox)gvCustomer.Rows[i].FindControl("cbCheck");
                    cbCheck.Checked = false;
                }
            }
        }

        protected void gvCustTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                List<Cust> listCust = new List<Cust>();
                List<Cust> listCustTemp = new List<Cust>();

                Label lblCustNameDelete = (Label)gvCustTemp.Rows[index].FindControl("lblCustNameTemp");

                for (int i = 0; i < gvCustomer.Rows.Count; i++)
                {
                    Cust cust = new Cust();

                    Label lblCustName = (Label)gvCustomer.Rows[i].FindControl("lblCustName");
                    Label lblJenisKelamin = (Label)gvCustomer.Rows[i].FindControl("lblJenisKelamin");
                    Label lblTanggalLahir = (Label)gvCustomer.Rows[i].FindControl("lblTanggalLahir");
                    Label lblTempatLahir = (Label)gvCustomer.Rows[i].FindControl("lblTempatLahir");
                    Label lblAlamat = (Label)gvCustomer.Rows[i].FindControl("lblAlamat");
                   
                    cust.Nama = lblCustName.Text;
                    cust.JenisKelamin = lblJenisKelamin.Text;
                    cust.TanggalLahir = lblTanggalLahir.Text;
                    cust.TempatLahir = lblTempatLahir.Text;
                    cust.Alamat = lblAlamat.Text;
                    listCust.Add(cust);
                }

                for (int j = 0; j < gvCustTemp.Rows.Count; j++)
                {
                    Label lblCustNameTemp = (Label)gvCustTemp.Rows[j].FindControl("lblCustNameTemp");
                    Label lblJenisKelaminTemp = (Label)gvCustTemp.Rows[j].FindControl("lblJenisKelaminTemp");
                    Label lblTanggalLahirTemp = (Label)gvCustTemp.Rows[j].FindControl("lblTanggalLahirTemp");
                    Label lblTempatLahirTemp = (Label)gvCustTemp.Rows[j].FindControl("lblTempatLahirTemp");
                    Label lblAlamatTemp = (Label)gvCustTemp.Rows[j].FindControl("lblAlamatTemp");

                    Cust cust = new Cust();
                    if (lblCustNameDelete.Text != lblCustNameTemp.Text)
                    {
                        cust.Nama = lblCustNameTemp.Text;
                        cust.JenisKelamin = lblJenisKelaminTemp.Text;
                        cust.TanggalLahir = lblTanggalLahirTemp.Text;
                        cust.TempatLahir = lblTempatLahirTemp.Text;
                        cust.Alamat = lblAlamatTemp.Text;
                        listCustTemp.Add(cust);
                    }
                    else
                    {
                        cust.Nama = lblCustNameTemp.Text;
                        cust.JenisKelamin = lblJenisKelaminTemp.Text;
                        cust.TanggalLahir = lblTanggalLahirTemp.Text;
                        cust.TempatLahir = lblTempatLahirTemp.Text;
                        cust.Alamat = lblAlamatTemp.Text;
                        listCust.Add(cust);
                    }
                }
                gvCustomer.DataSource = listCust;
                gvCustomer.DataBind();
                gvCustTemp.DataSource = listCustTemp;
                gvCustTemp.DataBind();
                upForm.Update();
                upFormTemp.Update();
            }
        }
        #endregion
        #region TOOLBAR
        protected void lbAddToTemp_Click(object sender, EventArgs e)
        {
            try
            {
                List<Cust> listCust = new List<Cust>();
                List<Cust> listCustTemp = new List<Cust>();

                for (int i = 0; i < gvCustomer.Rows.Count; i++)
                {
                    CheckBox cbCheck = (CheckBox)gvCustomer.Rows[i].FindControl("cbCheck");
                    Label lblCustName = (Label)gvCustomer.Rows[i].FindControl("lblCustName");
                    Label lblJenisKelamin = (Label)gvCustomer.Rows[i].FindControl("lblJenisKelamin");
                    Label lblTanggalLahir = (Label)gvCustomer.Rows[i].FindControl("lblTanggalLahir");
                    Label lblTempatLahir = (Label)gvCustomer.Rows[i].FindControl("lblTempatLahir");
                    Label lblAlamat = (Label)gvCustomer.Rows[i].FindControl("lblAlamat");

                    Cust cust = new Cust();
                    if (cbCheck.Checked)//untuk cek apakah checkbox di cheklist pada grid (true apabila di check)
                    {
                        cust.Nama = lblCustName.Text;
                        cust.JenisKelamin = lblJenisKelamin.Text;
                        cust.TanggalLahir = lblTanggalLahir.Text;
                        cust.TempatLahir = lblTempatLahir.Text;
                        cust.Alamat = lblAlamat.Text;
                        listCustTemp.Add(cust);
                    }
                    else
                    {
                        cust.Nama = lblCustName.Text;
                        cust.JenisKelamin = lblJenisKelamin.Text;
                        cust.TanggalLahir = lblTanggalLahir.Text;
                        cust.TempatLahir = lblTempatLahir.Text;
                        cust.Alamat = lblAlamat.Text;
                        listCust.Add(cust);
                    }
                }
                for (int i = 0; i < gvCustTemp.Rows.Count; i++)
                {
                    Cust cust = new Cust();
                    Label lblCustNameTemp = (Label)gvCustTemp.Rows[i].FindControl("lblCustNameTemp");
                    Label lblJenisKelaminTemp = (Label)gvCustTemp.Rows[i].FindControl("lblJenisKelaminTemp");
                    Label lblTanggalLahirTemp = (Label)gvCustTemp.Rows[i].FindControl("lblTanggalLahirTemp");
                    Label lblTempatLahirTemp = (Label)gvCustTemp.Rows[i].FindControl("lblTempatLahirTemp");
                    Label lblAlamatTemp = (Label)gvCustTemp.Rows[i].FindControl("lblAlamatTemp");

                    cust.Nama = lblCustNameTemp.Text;
                    cust.JenisKelamin = lblJenisKelaminTemp.Text;
                    cust.TanggalLahir = lblTanggalLahirTemp.Text;
                    cust.TempatLahir = lblTempatLahirTemp.Text;
                    cust.Alamat = lblAlamatTemp.Text;
                    listCustTemp.Add(cust);
                }
                gvCustomer.DataSource = listCust;
                gvCustomer.DataBind();
                gvCustTemp.DataSource = listCustTemp;
                gvCustTemp.DataBind();
                upForm.Update();
                upFormTemp.Update();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        #endregion
    }
}