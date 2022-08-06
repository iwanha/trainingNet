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

namespace Training
{
    public partial class AddCustomer : WebFormBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rblCustType.Items.Add(new ListItem("Personal", "P"));
                rblCustType.Items.Add(new ListItem("Company", "C"));
                rblCustType.SelectedIndex = 0;

                ddlAddressType.Items.Add(new ListItem("Legal", "Legal"));
                ddlAddressType.Items.Add(new ListItem("Residence", "Residence"));
                ddlAddressType.Items.Add(new ListItem("Office", "Office"));
                ddlAddressType.SelectedIndex = 0;

                rblIdentityType.Items.Add(new ListItem("KTP", "KTP"));
                rblIdentityType.Items.Add(new ListItem("NPWP", "NPWP"));

                upForm.Update();
            }
        }

        protected void lb_Toolbar_Save_Click(object sender, EventArgs e)
        {
            ICustService ics = (ICustService)UnityFactory.Resolve<ICustService>();

            string user = "Training";
            DateTime date = DateTime.Now;

            Cust cust = new Cust();
            CustAddr ca = new CustAddr();

            cust.CustNo = txtCustNo.Text;
            cust.CustType = rblCustType.SelectedValue;
            cust.CustName = txtCustName.Text;
            cust.IdentityType = rblIdentityType.SelectedValue;
            cust.IdentityNo = txtIdentityNo.Text;

            ca.AddressType = ddlAddressType.SelectedValue;
            ca.Address = txtAddress.Text;
            ca.Rt = txtRt.Text;
            ca.Rw = txtRw.Text;
            ca.Kelurahan = txtKelurahan.Text;
            ca.Kecamatan = txtKecamatan.Text;
            ca.City = txtCity.Text;
            ca.Zipcode = txtZipcode.Text;

            cust.CustAddr.Add(ca);

            ics.SaveCust(cust);

            RedirectUrl("~/Training/AddCustomer.aspx");
        }

        protected void lb_Toolbar_Edit_Click(object sender, EventArgs e)
        {
            ICustService ics = (ICustService)UnityFactory.Resolve<ICustService>();

            Cust cust = ics.GetCustByCustNo(txtCustNo.Text);
            CustAddr ca = ics.GetCustAddrByCustId(cust.CustId);

            cust.CustNo = txtCustNo.Text;
            cust.CustType = rblCustType.SelectedValue;
            cust.CustName = txtCustName.Text;
            cust.IdentityType = rblIdentityType.SelectedValue;
            cust.IdentityNo = txtIdentityNo.Text;

            ca.AddressType = ddlAddressType.SelectedValue;
            ca.Address = txtAddress.Text;
            ca.Rt = txtRt.Text;
            ca.Rw = txtRw.Text;
            ca.Kelurahan = txtKelurahan.Text;
            ca.Kecamatan = txtKecamatan.Text;
            ca.City = txtCity.Text;
            ca.Zipcode = txtZipcode.Text;

            ics.EditCust();

            RedirectUrl("~/Training/AddCustomer.aspx");
        }

        protected void lb_Toolbar_Delete_Click(object sender, EventArgs e)
        {
            ICustService ics = (ICustService)UnityFactory.Resolve<ICustService>();
            Cust cust = ics.GetCustByCustNo(txtCustNo.Text);

            ics.DeleteCust(cust.CustId);

            RedirectUrl("~/Training/AddCustomer.aspx");
        }
    }
}