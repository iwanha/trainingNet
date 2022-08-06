using AdIns.Util.Query;
using Rule.Web.WebUserControl.GenericLookup;
using Rule.Web.WebUserControl.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rule.Web.WebUserControl.Lookup
{
    public partial class UCLookUpExamCustomer : System.Web.UI.UserControl
    {
        #region Properties
        private SearchControlParam scParam
        {
            get { return uclLookupExamCustomer.UcSearch.ScParam; }
            set { uclLookupExamCustomer.UcSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return uclLookupExamCustomer.UcSearch.criteria; }
            set { uclLookupExamCustomer.UcSearch.criteria = value; }
        }
        private string checkPageLoad
        {
            get { return (string)ViewState["CheckPageLoad"]; }
            set { ViewState["CheckPageLoad"] = value; }
        }
        #endregion
        #region Public Properties
        public string Text
        {
            get { return uclLookupExamCustomer.Text; }
            set { uclLookupExamCustomer.Text = value; }
        }
        public bool TextBoxEnable
        {
            get { return uclLookupExamCustomer.txtInputObj.Enabled; }
            set { uclLookupExamCustomer.txtInputObj.Enabled = value; }
        }
        public LookupBase LookupBase
        {
            get { return uclLookupExamCustomer; }
        }
        //public string RefBankId
        //{
        //    get { return uclLookupExamCustomer["RefBankId"]; }
        //    set { uclLookupExamCustomer["RefBankId"] = value; }
        //}
        //public string BankCode
        //{
        //    get { return uclLookupExamCustomer["BankCode"]; }
        //    set { uclLookupExamCustomer["BankCode"] = value; }
        //}
        public string BankName
        {
            get { return uclLookupExamCustomer["BankName"]; }
            set { uclLookupExamCustomer["BankName"] = value; }
        }
        public string EmployeeName
        {
            get { return uclLookupExamCustomer["EmployeeName"]; }
            set { uclLookupExamCustomer["EmployeeName"] = value; }
        }
        public string Position
        {
            get { return uclLookupExamCustomer["Position"]; }
            set { uclLookupExamCustomer["Position"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initSearchBy();
            }
        }
        #region Search
        private void initSearchBy()
        {
            scParam = new SearchControlParam();
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[] {
                new FixedSearchPropSpec("Employee Name", "EmployeeName"),
                new FixedSearchPropSpec("Position", "Position")
            });
        }
        #endregion
    }
}