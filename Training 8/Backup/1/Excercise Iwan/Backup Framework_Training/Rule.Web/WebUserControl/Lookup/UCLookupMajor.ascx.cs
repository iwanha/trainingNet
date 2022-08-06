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
    public partial class UCLookupMajor : System.Web.UI.UserControl
    {
        #region PROPERTIES
        private SearchControlParam scParam
        {
            get { return uclLookupMajor.UcSearch.ScParam; }
            set { uclLookupMajor.UcSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return uclLookupMajor.UcSearch.criteria; }
            set { uclLookupMajor.UcSearch.criteria = value; }
        }
        private string checkPageLoad
        {
            get { return (string)ViewState["CheckPageLoad"]; }
            set { ViewState["CheckPageLoad"] = value; }
        }
        #endregion
        #region PUBLIC PROPERTIES
        public string Text
        {
            get { return uclLookupMajor.Text; }
            set { uclLookupMajor.Text = value; }
        }
        public bool TextBoxEnable
        {
            get { return uclLookupMajor.txtInputObj.Enabled; }
            set { uclLookupMajor.txtInputObj.Enabled = value; }
        }
        public LookupBase LookupBase
        {
            get { return uclLookupMajor; }
        }
        public string MajorCode
        {
            get { return uclLookupMajor["MajorCode"]; }
            set { uclLookupMajor["MajorCode"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initSearchBy();
            }
        }
        #region SEARCH
        //  munculnya di bagian atas Lookup Produce(diatas grid view
        private void initSearchBy()
        {
            scParam = new SearchControlParam();
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[]{
                new FixedSearchPropSpec("Faculty","Faculty"),
                new FixedSearchPropSpec("Major Code","MajorCode"),
                new FixedSearchPropSpec("Major Name","MajorName")
            });
        }
        #endregion
    }
}