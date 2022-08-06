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
    public partial class UCLookupBrand : System.Web.UI.UserControl
    {

        #region PROPERTIES
        private SearchControlParam scParam
        {
            get { return uclLookupBrand.UcSearch.ScParam; }
            set { uclLookupBrand.UcSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return uclLookupBrand.UcSearch.criteria; }
            set { uclLookupBrand.UcSearch.criteria = value; }
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
            get { return uclLookupBrand.Text; }
            set { uclLookupBrand.Text = value; }
        }
        public bool TextBoxEnable
        {
            get { return uclLookupBrand.txtInputObj.Enabled; }
            set { uclLookupBrand.txtInputObj.Enabled = value; }
        }
        public LookupBase LookupBase
        {
            get { return uclLookupBrand; }
        }
        public string Brand
        {
            get { return uclLookupBrand["Brand"]; }
            set { uclLookupBrand["Brand"] = value; }
        }
        //public decimal Price
        //{
        //    get { return uclLookupBrand["Price"]; }
        //    set { uclLookupBrand["Price"] = value; }
        //}
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
                new FixedSearchPropSpec("Brand Name","Brand"),
                //new FixedSearchPropSpec("Price","Price")
            });
        }
        #endregion
    }

}