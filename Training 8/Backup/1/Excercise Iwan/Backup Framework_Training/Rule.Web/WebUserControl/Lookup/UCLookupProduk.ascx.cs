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
    public partial class UCLookupProduksi : System.Web.UI.UserControl
    {
        #region PROPERTIES
        private SearchControlParam scParam
        {
            get { return uclLookupProduk.UcSearch.ScParam; }
            set { uclLookupProduk.UcSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return uclLookupProduk.UcSearch.criteria; }
            set { uclLookupProduk.UcSearch.criteria = value; }
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
            get { return uclLookupProduk.Text; }
            set { uclLookupProduk.Text = value; }
        }
        public bool TextBoxEnable
        {
            get { return uclLookupProduk.txtInputObj.Enabled; }
            set { uclLookupProduk.txtInputObj.Enabled = value; }
        }
        public LookupBase LookupBase
        {
            get { return uclLookupProduk; }
        }
        public string ProdukCode
        {
            get { return uclLookupProduk["MasterCode"]; }
            set { uclLookupProduk["MasterCode"] = value; }
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
                new FixedSearchPropSpec("ltl_Pembelian_BrandName_Search","MasterCode"),
                new FixedSearchPropSpec("ltl_Pembelian_ModelName_Search","Description"),
            });
        }
        #endregion
    }
}