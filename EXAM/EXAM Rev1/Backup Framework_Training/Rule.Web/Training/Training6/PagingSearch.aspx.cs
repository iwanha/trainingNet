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

namespace Training.Training6
{
    public partial class PagingSearch : WebFormBase
    {
        protected global::Rule.Web.WebUserControl.Search.UCSearch ucSearch;
        protected global::Rule.Web.WebUserControl.UCGridHeader ucGridHeader;
        protected global::Rule.Web.WebUserControl.UCGridFooter ucGridFooter;
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
                initSearchBy();
            }
            ucGridFooter.DataBinder += new UCGridFooter.DelegateDataBind(ucGridFooter_Click);
            ucGridHeader.DataBinder += new UCGridHeader.DelegateDataBind(ucGridHeader_Click);
            ucSearch.DataBinder += new UCSearch.DelegateDataBind(search_Click);
        }

        protected void lb_Toolbar_Add_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/Training6/AddCustomerHandling.aspx");
        }

        protected void gvCustomerHandling_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
                Int64 customerHandlingId = Convert.ToInt64(((Label)gvCustomerHandling.Rows[index].FindControl("lbl_CustomerHandling_CustomerHandlingId")).Text);
                RedirectUrl("~/Training/Training6/AddCustomerHandling.aspx", PageRedirectionState.InitAdd("CustomerHandlingId", customerHandlingId));
            }
            
        }

        protected void gvCustomerHandling_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal lblAdminFee = Convert.ToDecimal(((Label)e.Row.FindControl("lbl_CustomerHandling_AdminFee")).Text);
                ((Label)e.Row.FindControl("lbl_CustomerHandling_AdminFee")).Text = DcmFormatter.FormatToString(lblAdminFee);
            }
        
        }

        private void initSearchBy()
        {
            ICustomerHandling custHandSvc = (ICustomerHandling)UnityFactory.Resolve<ICustomerHandling>();

            List<RefMaster> listServiceCategory = custHandSvc.GetListRefMasterByMasterType("HANDLING_CATEGORY");

            scParam = new SearchControlParam();
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[] {
                new FixedSearchPropSpec("Admin Fee >=", "AdminFee", typeof(Decimal), false, SearchPropSpec.SearchCondition.gte),
                new FixedSearchPropSpec("Admin Fee <=", "AdminFee", typeof(Decimal), false, SearchPropSpec.SearchCondition.lte),
                new FixedSearchPropSpec("Registration No","RegistrationNo", typeof(string)),
                new FixedSearchPropSpec("Customer Name","CustomerName", typeof(string)),
                new FixedSearchPropSpec("Service Category","ServiceCategory", listServiceCategory, "Description","MasterCode", typeof(string), false, UCReference.AdditionalSelectionType.All)
            });

        }

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
                parameter.AddOrderBy("CustomerName", true);
            }
            else
            {
                parameter.AddOrderBy(orderBy.Keys.FirstOrDefault(), bool.Parse(orderBy.Values.FirstOrDefault()));
            }

            parameter.EntitiesTypeName = ConfinsEntitiesType.TRN;
            parameter.Criteria = criteria;
            pagingResult = qsOrgSvc.QueryPaging("QryPagingCustHandling", pagingSpec, parameter);

            if (isCount)
            {
                ucGridFooter.SetTotalRecrod(pagingResult.Count);
            }

            if (isData)
            {
                gvCustomerHandling.DataSource = pagingResult.Data;
                gvCustomerHandling.DataBind();
                ItalicizeHeaderRow(gvCustomerHandling);
            }

            upGrid.Update();
        
        }

        private void search_Click()
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
            dGridSection.Visible = true;
        }

        protected void ucGridHeader_Click(HeaderEventType evenType)
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
        }

        protected void ucGridFooter_Click(FooterEventType evenType, int currentPage)
        {
            searchClick(currentPage);
        }
    }
}