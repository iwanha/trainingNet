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

namespace Training.Training7
{
    public partial class SupplPaging : WebFormBase
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
        private void initSearch()
        {
            IRefMasterService irms = (IRefMasterService)UnityFactory.Resolve<IRefMasterService>();
            scParam = new SearchControlParam();
            List<RefMaster> listRefMaster = irms.listOfRefMaster("PRODUCE");
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[]{
                new FixedSearchPropSpec("ltl_Suppl_SupplNo_Search","SupplNo"),
                new FixedSearchPropSpec("ltl_Suppl_SupplName_Search","SupplName"),
                new FixedSearchPropSpec("ltl_Suppl_SupplAddress_Search","SupplAddress"),
                new FixedSearchPropSpec("ltl_Suppl_Produce_Search","Produce", listRefMaster, "Description","MasterCode",typeof(string),
                    false,UCReference.AdditionalSelectionType.All)
            });
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
                parameter.AddOrderBy("SupplNo", true);
            }
            else
            {
                parameter.AddOrderBy(orderBy.Keys.FirstOrDefault(), bool.Parse(orderBy.Values.FirstOrDefault()));
            }

            parameter.EntitiesTypeName = ConfinsEntitiesType.TRN;
            parameter.Criteria = criteria;
            pagingResult = qsOrgSvc.QueryPaging("QueryPagingSuppl", pagingSpec, parameter);

            if (isCount)
            {
                ucGridFooter.SetTotalRecrod(pagingResult.Count);
            }

            if (isData)
            {
                gvSuppl.DataSource = pagingResult.Data;
                gvSuppl.DataBind();
                ItalicizeHeaderRow(gvSuppl);
            }
            upGrid.Update();
        }

        private void search_Click()
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
            dGridSection.Visible = true;
        }
#endregion
        #region TOOLbAR
        protected void lb_Toolbar_Add_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/Training7/AddSuppl.aspx");
        }
        #endregion
        #region GRID
        protected void gvSuppl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ISupplService iss = (ISupplService)UnityFactory.Resolve<ISupplService>();
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
                string supplId = ((Label)gvSuppl.Rows[index].FindControl("lblSupplId")).Text;
                base.RedirectUrl("~/Training/Training7/AddSuppl.aspx", PageRedirectionState.InitAdd("supplId", supplId));
            }
            else if (e.CommandName == "DEL")
            {
                string supplId = ((Label)gvSuppl.Rows[index].FindControl("lblSupplId")).Text;
                iss.DeleteSuppl(Convert.ToInt64(supplId));
                string popupUrl = this.ResolveUrl("~/Training/Training7/SupplPaging.aspx");
            }
            else if (e.CommandName == "ViewSuppl")
            {
                string supplId = ((Label)gvSuppl.Rows[index].FindControl("lblSupplId")).Text;   //  Get Suppl Id
                string popupUrl = this.ResolveUrl("~/Training/Training7/ViewSupplier.aspx?supplId=" + supplId); //  buat bikin pop up Url nya doang
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "showAuctionNamePopupWindows", "showPopupWindows('" + popupUrl + "');", true); // assign action ke button

            }
        }
        #endregion
         
    }
}