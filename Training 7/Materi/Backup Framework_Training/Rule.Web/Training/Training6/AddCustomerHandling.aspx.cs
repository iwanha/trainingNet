using AdIns.Service;
using Rule.Web;
using Rule.Web.WebUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.API;
using Training.DataModel.TrainingModel;





namespace Training.Training6
{
    public partial class AddCustomerHandling : WebFormBase
    {
        protected global::Rule.Web.WebUserControl.UCReference ucServiceCategory, ucMediaOfService;
        protected global::Rule.Web.WebUserControl.UCInputNumber ucAdminFee;
        protected global::Rule.Web.WebUserControl.UCDatePicker ucCompletionDt;

        private Int64 customerHandlingId
        {
            get { return (Int64)ViewState["CustomerHandlingId"]; }
            set { ViewState["CustomerHandlingId"] = value; }
        }
        private SaveMode mode
        {
            get { return (SaveMode)ViewState["mode"]; }
            set { ViewState["mode"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    customerHandlingId = Convert.ToInt64(base.RedirectState["CustomerHandlingId"]);
                    
                    txtRegistrationNo.Enabled = false;
                    txtCustomerName.Enabled = false;
                    txtMobilePhoneNo.Enabled = false;
                    txtEmail.Enabled = false;

                    ICustomerHandling ich = (ICustomerHandling)UnityFactory.Resolve<ICustomerHandling>(); //Deklarasi API

                    CustomerHandling ch = ich.GetCustomerHandlingByCustomerHandlingId(customerHandlingId);
                    txtRegistrationNo.Text = ch.RegistrationNo;
                    txtCustomerName.Text = ch.CustomerName;
                    txtMobilePhoneNo.Text = ch.MobilePhoneNo;
                    txtEmail.Text = ch.Email;
                    ucServiceCategory.SelectedValue = ch.ServiceCategory;
                    ucMediaOfService.SelectedValue = ch.MediaOfService;
                    txtChronologic.Text = ch.Chronologic;
                    ucAdminFee.Text = ch.AdminFee.ToString();
                    if (ch.CompletionDt != null)
                    {
                        ucCompletionDt.DateValue = Convert.ToDateTime(ch.CompletionDt);
                    }

                    mode = SaveMode.Edit;
                }
                catch
                {
                    ucCompletionDt.Enabled = false;
                    mode = SaveMode.Add;
                }
                setScreen();
            }
        }
        protected enum SaveMode
        {
            Add,
            Edit,
        }

        protected void lb_toolbar_submit_Click(object sender, EventArgs e)
        {
            if (mode == SaveMode.Add)
            {
                ICustomerHandling custHandSvc = (ICustomerHandling)UnityFactory.Resolve<ICustomerHandling>();

                CustomerHandling ch = new CustomerHandling();
                string saveMode = string.Empty;

                string user = "Training";
                DateTime date = DateTime.Now;

                ch.RegistrationNo = txtRegistrationNo.Text;
                ch.CustomerName = txtCustomerName.Text;
                ch.MobilePhoneNo = txtMobilePhoneNo.Text;
                ch.Email = txtEmail.Text;
                ch.ServiceCategory = ucServiceCategory.SelectedValue;
                ch.MediaOfService = ucMediaOfService.SelectedValue;
                ch.Chronologic = txtChronologic.Text;
                ch.AdminFee = Convert.ToDecimal(ucAdminFee.Text);


                ch.ServiceStatus = "New";

                custHandSvc.AddEditData(ch, "Add");
            }
            else
            {
                ICustomerHandling custHandSvc = (ICustomerHandling)UnityFactory.Resolve<ICustomerHandling>();

                CustomerHandling ch = custHandSvc.GetCustomerHandlingByCustomerHandlingId(customerHandlingId);

                ch.RegistrationNo = txtRegistrationNo.Text;
                ch.CustomerName = txtCustomerName.Text;
                ch.MobilePhoneNo = txtMobilePhoneNo.Text;
                ch.Email = txtEmail.Text;
                ch.ServiceCategory = ucServiceCategory.SelectedValue;
                ch.MediaOfService = ucMediaOfService.SelectedValue;
                ch.Chronologic = txtChronologic.Text;
                ch.AdminFee = Convert.ToDecimal(ucAdminFee.Text);
                ch.ServiceStatus = "Done";
                ch.CompletionDt = Convert.ToDateTime(ucCompletionDt.DateValue);

                custHandSvc.AddEditData(ch, "Edit");

            }
            RedirectUrl("~/Training/Training6/PagingSearch.aspx");

        }

        protected void lb_toolbar_cancel_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/Training6/PagingSearch.aspx");
        }

        private void setScreen()
        {
            ICustomerHandling custHandSvc = (ICustomerHandling)UnityFactory.Resolve<ICustomerHandling>();

            #region Category
            List<RefMaster> listServiceCategory = custHandSvc.GetListRefMasterByMasterType("HANDLING_CATEGORY");
            ucServiceCategory.BindingObject(listServiceCategory, "Description", "MasterCode", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion
            #region MediaOfService
            List<RefMaster> listMediaOfService = custHandSvc.GetListRefMasterByMasterType("HANDLING_MEDIA");
            ucMediaOfService.BindingObject(listMediaOfService, "Description", "MasterCode", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion


        }
    }
}