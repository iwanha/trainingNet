using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdIns.Util.Query;
using Rule.Web.WebUserControl.Search;
using Rule.Web.WebUserControl.GenericLookup;

namespace Rule.Web.WebUserControl.Lookup
{
    public partial class UCLookupProduct : System.Web.UI.UserControl
    {
        #region "PROPERTIES"
        private SearchControlParam scParam
        {
            get { return uclProduct.UcSearch.ScParam; }
            set { uclProduct.UcSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return uclProduct.UcSearch.criteria; }
            set { uclProduct.UcSearch.criteria = value; }
        }
        #endregion

        #region "PUBLIC PROPERTIES"
        public string ProductId
        {
            get { return uclProduct["ProductId"]; }
            set { uclProduct["ProductId"] = value; }
        }

        public string ProductType
        {
            get { return uclProduct["ProductType"]; }
            set { uclProduct["ProductType"] = value; }
        }

        public string ProductName
        {
            get { return uclProduct.Text; }
            set { uclProduct.Text = value; }
        }


        public LookupBase LookupBase
        {
            get { return uclProduct; }
        }

        #endregion

        #region "SEARCH"
        private void initSearchBy()
        {
            scParam = new SearchControlParam();

            #region "INIT FIXED SEARCH VALUE"
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[] {
                new FixedSearchPropSpec("Product Type","ProductType"),
                new FixedSearchPropSpec("Product Name","ProductName")
            });
            #endregion
        }

        #endregion

        #region "PAGE LOAD"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                initSearchBy();
                criteria = new Criteria();

            }

            LookupBase.EnableTextChanged();
            LookupBase.txtInputObj.TextChanged += new EventHandler(LookupBase.txtInput_TextChanged);
        }
        #endregion

        #region METHOD

        public void setAdditionalCriteria(Criteria crit)
        {
            uclProduct.AdditionalCriteria = crit;
        }

        public void SetEditable(bool isEnabledTxtObj = true, bool isEnableImbObj = true)
        {
            uclProduct.txtInputObj.Enabled = isEnabledTxtObj;
            uclProduct.imbObj.Enabled = isEnableImbObj;
        }
        #endregion
    }
}