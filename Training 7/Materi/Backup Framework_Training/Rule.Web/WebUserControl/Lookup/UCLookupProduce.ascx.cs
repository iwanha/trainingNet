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
    public partial class UCLookupProduce : System.Web.UI.UserControl
    {
        #region PROPERTIES
        private SearchControlParam scParam
        {
            get { return uclLookupProduce.UcSearch.ScParam; }
            set { uclLookupProduce.UcSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return uclLookupProduce.UcSearch.criteria; }
            set { uclLookupProduce.UcSearch.criteria = value; }
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
            get { return uclLookupProduce.Text; }
            set { uclLookupProduce.Text = value; }
        }
        public bool TextBoxEnable
        {
            get { return uclLookupProduce.txtInputObj.Enabled; }
            set { uclLookupProduce.txtInputObj.Enabled = value; }
        }
        public LookupBase LookupBase
        {
            get { return uclLookupProduce; }
        }
        public string ProduceCode
        {
            get { return uclLookupProduce["MasterCode"]; }
            set { uclLookupProduce["MasterCode"] = value; }
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
                new FixedSearchPropSpec("ltl_Suppl_ProduceCode_Search","MasterCode"),
                new FixedSearchPropSpec("ltl_Suppl_ProduceName_Search","Description"),
            });
        }
        #endregion
    }
}