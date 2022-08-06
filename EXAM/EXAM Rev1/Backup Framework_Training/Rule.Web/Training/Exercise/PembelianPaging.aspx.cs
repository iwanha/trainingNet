using AdIns.Service;
using AdIns.Service.QueryService;
using AdIns.Util;
using AdIns.Util.Query;
using Rule.Common;
using Rule.Web;
using Rule.Web.WebUserControl;
using Rule.Web.WebUserControl.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.API;
using Training.DataModel.TrainingModel;

namespace Training.excercise
{
    public partial class PembelianPaging : WebFormBase
    {
        #region PAGE CONTROL
        protected global::Rule.Web.WebUserControl.Search.UCSearch ucSearch;
        protected global::Rule.Web.WebUserControl.UCGridHeader ucGridHeader;
        protected global::Rule.Web.WebUserControl.UCGridFooter ucGridFooter;
        #endregion
        #region PROPERTIES
        private int pagesize
        {
            get { return ucGridFooter.PageSize; }
            set { ucGridFooter.PageSize = value; }
        }
        private Int32 currentPage
        {
            get { return ucGridFooter.currentPage; }
            set { ucGridFooter.currentPage = value; }
        }
        private bool isCount
        {
            get { return ucGridFooter.IsCount; }
            set { ucGridFooter.IsCount = value; }
        }
        private Dictionary<string, string> orderBy
        {
            get { return (Dictionary<string, string>)ViewState["orderBy"]; }
            set { ViewState["orderBy"] = value; }
        }
        private SearchControlParam scParam
        {
            get { return ucSearch.ScParam; }
            set { ucSearch.ScParam = value; }
        }
        private Criteria criteria
        {
            get { return ucSearch.Criteria; }
            set { ucSearch.Criteria = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initSearch();
            }
            ucGridFooter.DataBinder += new UCGridFooter.DelegateDataBind(ucGridFooter_Click);
            ucGridHeader.DataBinder += new UCGridHeader.DelegateDataBind(ucGridHeader_Click);
            ucSearch.DataBinder += new UCSearch.DelegateDataBind(search_Click);
        }

        #region PAGE
        protected void ucGridFooter_Click(FooterEventType evenType, int currentPage)
        {
            searchClick(currentPage);
        }
        protected void ucGridHeader_Click(HeaderEventType evenType)
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
        }
        #endregion
        #region SEARCH
        private void searchClick(int currentPage, bool isData = true)
        {
            QueryService qsOrgSvc = UnityFactory.Resolve<QueryService>();
            PagingResult pagingResult = new PagingResult();
            PagingSpec pagingSpec = new PagingSpec();
            QueryParameter parameter = new QueryParameter();

            pagingSpec.IncludeCount = isCount;
            pagingSpec.IncludeData = isData;
            pagingSpec.PageNo = currentPage;
            pagingSpec.RowPerPage = pagesize;
            if (orderBy == null)
            {
                parameter.AddOrderBy("CustNo", true);
            }
            else
            {
                parameter.AddOrderBy(orderBy.Keys.FirstOrDefault(), bool.Parse(orderBy.Values.FirstOrDefault()));
            }

            parameter.EntitiesTypeName = ConfinsEntitiesType.TRN;
            parameter.Criteria = criteria;
            pagingResult = qsOrgSvc.QueryPaging("QueryPagingCust", pagingSpec, parameter);

            if (isCount)
            {
                ucGridFooter.SetTotalRecrod(pagingResult.Count);
            }

            if (isData)
            {
                gvPembelian.DataSource = pagingResult.Data;
                gvPembelian.DataBind();
                ItalicizeHeaderRow(gvPembelian);
            }
            upGrid.Update();
        }
        private void search_Click()
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
            dGridSection.Visible = true;
        }
        private void initSearch()
        {
            IRefMasterService irms = (IRefMasterService)UnityFactory.Resolve<IRefMasterService>();
            scParam = new SearchControlParam();
            List<RefMaster> listRefMaster = irms.listOfRefMaster("PRODUK");
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[]{
                new FixedSearchPropSpec("ltl_Cust_CustNo_Search","CustNo"),
                //new FixedSearchPropSpec("ltl_Cust_CustId_Search","CustId"),
                new FixedSearchPropSpec("ltl_Cust_CustName_Search","CustName"),
                new FixedSearchPropSpec("ltl_Cust_CustType","CustType", listRefMaster, "Description","MasterCode",typeof(string),
                    false,UCReference.AdditionalSelectionType.All)
            });
        }
        #endregion
        #region GRID
        protected void gvPembelian_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IPembelianService iss = (IPembelianService)UnityFactory.Resolve<IPembelianService>();
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "Sort")
            {
                string isAcc = "true";
                if (orderBy != null && orderBy.Keys.FirstOrDefault() == e.CommandArgument.ToString())
                {
                    isAcc = orderBy.Values.FirstOrDefault() == "true" ? "false" : "true";
                }
                orderBy = new Dictionary<string, string>();
                orderBy.Add(e.CommandArgument.ToString(), isAcc);
                searchClick(currentPage);
            }
            else if (e.CommandName == "EDIT")
            {
                string custId = ((Label)gvPembelian.Rows[index].FindControl("lblCustId")).Text;
                base.RedirectUrl("~/Training/Exercise/AddPembelian.aspx", PageRedirectionState.InitAdd("custId", custId));
            }
            //else if (e.CommandName == "DEL")
            //{
            //    string custId = ((Label)gvPembelian.Rows[index].FindControl("lblCustId")).Text;
            //    iss.DeleteCust(Convert.ToInt64(custId));
            //    string popupUrl = this.ResolveUrl("~/Training/Exercise/PembelianPaging.aspx");
            //}
            else if (e.CommandName == "ViewPembelian")
            {
                string custId = ((Label)gvPembelian.Rows[index].FindControl("lblCustId")).Text;   //  Get Suppl Id
                string popupUrl = this.ResolveUrl("~/Training/Exercise/ViewCustomerHist.aspx?custId=" + custId); //  buat bikin pop up Url nya doang
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "showAuctionNamePopupWindows", "showPopupWindows('" + popupUrl + "');", true); // assign action ke button

            }
        }
        #endregion
        #region TOOLBAR
        //protected void lb_Toolbar_Add_Click1(object sender, EventArgs e)
        //{

        //}
        #endregion

    }
}