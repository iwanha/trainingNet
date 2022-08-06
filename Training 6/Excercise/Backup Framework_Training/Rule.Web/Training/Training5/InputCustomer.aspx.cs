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

namespace Training
{
    public partial class InputCustomer : WebFormBase
    {
        protected global::Rule.Web.WebUserControl.UCReference ucIdType,ucMaritalStatus,ucReligion,ucNationality;
        protected global::Rule.Web.WebUserControl.UCDatePicker ucBirthDt;

        protected global::Rule.Web.WebUserControl.UCInputNumber ucMonthlyIncome;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setScreen();
            }
        }

        protected void lb_toolbar_submit_Click(object sender, EventArgs e)
        {
            ICustomerService custSvc = (ICustomerService)UnityFactory.Resolve<ICustomerService>();

            Cust cu = new Cust(); //Deklar
            string saveMode = string.Empty;

            cu.CustNo = txtCustNo.Text;
            cu.CustName = txtCustName.Text;
            cu.IdentityType = ucIdType.SelectedValue;     //Berhubungan dengan sql // selalu gunakan value
            cu.IdentityNo = txtIdNo.Text;
            cu.BirthPlace = txtBirthPlace.Text;
            cu.BirthDt = ucBirthDt.DateValue;  // hanya datevalue
            cu.MaritalStatus = ucMaritalStatus.SelectedValue;
            cu.Religion = ucReligion.SelectedValue;
            cu.Nationality = ucNationality.SelectedValue;
            cu.MonthlyIncome = Convert.ToDecimal(ucMonthlyIncome.Text);     //Convert to decimal
            cu.CustType = "P";

            custSvc.AddEditData(cu, "Add");

            RedirectUrl("~/Training/Training5/InputCustomer.aspx");

        }

        protected void lb_toolbar_cancel_Click(object sender, EventArgs e)
        {

        }

        private void setScreen()
        {
            ICustomerService custSvc = (ICustomerService)UnityFactory.Resolve<ICustomerService>();

            #region ID Type
            List<RefMaster> listIDType = custSvc.GetListRefMasterByMasterType("ID_TYPE");
            ucIdType.BindingObject(listIDType, "Description", "MasterCode", true, UCReference.AdditionalSelectionType.SelectOne);  //  parameter pertama ditampilin di UI, parameter kedua untuk di background dari SQL//  true = mandatory(wajib diisi) false = tidak mandatory (tidak diisi)
            #endregion

            #region Marital Status
            List<RefMaster> listMaritalStatus = custSvc.GetListRefMasterByMasterType("MARITAL_STAT");
            ucMaritalStatus.BindingObject(listMaritalStatus, "Description", "MasterCode", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion

            #region Religion
            List<RefMaster> listReligion = custSvc.GetListRefMasterByMasterType("RELIGION");
            ucReligion.BindingObject(listReligion, "Description", "MasterCode", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion

            List<KeyValuePair<string, string>> listNationality = new List<KeyValuePair<string, string>>();  //  KeyValuePair = sejenis dictionary
            listNationality.Add(new KeyValuePair<string, string>("Warga Negara Indonesia", "WNI"));  //  parameter kiri untuk
            listNationality.Add(new KeyValuePair<string, string>("Warga Negara Asing", "WNA"));

            ucNationality.BindingObject(listNationality, "key", "value", true, UCReference.AdditionalSelectionType.SelectOne);
        }
    }
}