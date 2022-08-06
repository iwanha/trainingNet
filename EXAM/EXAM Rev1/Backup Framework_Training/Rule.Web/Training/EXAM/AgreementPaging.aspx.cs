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

namespace Training.EXAM
{
    public partial class AgreementPaging : WebFormBase
    {
        protected global::Rule.Web.WebUserControl.Search.UCSearch ucSearch;
        protected global::Rule.Web.WebUserControl.UCGridFooter ucGridFooter; //blm ada didesigner
        protected global::Rule.Web.WebUserControl.UCGridHeader ucGridHeader;

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

        #region Page
        protected void ucGridFooter_Click(FooterEventType eventType, int currentPage)
        {
            searchClick(currentPage);
        }
        protected void ucGridHeader_Click(HeaderEventType evenType)
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
        }
        #endregion

        #region Search
        private void initSearch()
        {
            IExamCustomerService iecs = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
            scParam = new SearchControlParam();
            List<Agrmnt> listAgrmnt = iecs.listOfAgrmnt();
            List<Customer> listCust = iecs.listOfCust();
            List<RefCurrency> listCurrency = iecs.listOfCurrency();
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[]{
                new FixedSearchPropSpec("Application No","AppNo"),
                new FixedSearchPropSpec("Agreement No","AgrmntNo"),
                new FixedSearchPropSpec("Customer Name","CustomerName"),
                new FixedSearchPropSpec("Customer Address","Address"),
                new FixedSearchPropSpec("Application Step", "AppStep",listAgrmnt,"AppStep","AppStep",typeof(string), false, UCReference.AdditionalSelectionType.All),
                new FixedSearchPropSpec("Contract Status", "ContractStat",listAgrmnt,"ContractStat","ContractStat",typeof(string), false, UCReference.AdditionalSelectionType.All),
                new FixedSearchPropSpec("Installment Amount", "InstAmt", typeof(Decimal), false, SearchPropSpec.SearchCondition.gte),
                new FixedSearchPropSpec("Installment Amount", "InstAmt", typeof(Decimal), false, SearchPropSpec.SearchCondition.lte),
                new FixedSearchPropSpec("Currency", "CurrencyCode",listCurrency,"CurrencyName","CurrencyCode",typeof(string), false, UCReference.AdditionalSelectionType.All)
            });
        }
        #endregion

        #region searchClick
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
                parameter.AddOrderBy("AgrmntNo", true);
            }
            else
            {
                parameter.AddOrderBy(orderBy.Keys.FirstOrDefault(), bool.Parse(orderBy.Values.FirstOrDefault()));
            }

            parameter.EntitiesTypeName = ConfinsEntitiesType.TRN;
            parameter.Criteria = criteria;
            pagingResult = qsOrgSvc.QueryPaging("QryPagingExamCustomer", pagingSpec, parameter);

            if (isCount)
            {
                ucGridFooter.SetTotalRecrod(pagingResult.Count);
            }

            if (isData)
            {
                gvAgreementPaging.DataSource = pagingResult.Data;
                gvAgreementPaging.DataBind();
                ItalicizeHeaderRow(gvAgreementPaging);
            }

            upGrid.Update();
        }
        #endregion

        #region search Click
        private void search_Click()
        {
            ucGridFooter.ResetPage();
            searchClick(currentPage);
            dGridSection.Visible = true;
        }
        #endregion


        
        protected void gvAgreementPaging_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IExamCustomerService iecs = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
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

            if (e.CommandName == "ED")
            {
                //string AgrmntId = ((Label)gvAgreementPaging.Rows[index].FindControl("lblAgrmntId")).Text;
                Int64 agrmntId = Convert.ToInt64(((Label)gvAgreementPaging.Rows[index].FindControl("lblAgrmntId")).Text);
                RedirectUrl("~/Training/EXAM/PDCReceive.aspx", PageRedirectionState.InitAdd("AgrmntId", agrmntId));
            }
        }

        
        protected void gvAgreementPaging_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal lblInstAmt = Convert.ToDecimal(((Label)e.Row.FindControl("lbl_Paging_InstAmt")).Text);
                ((Label)e.Row.FindControl("lbl_Paging_InstAmt")).Text = DcmFormatter.FormatToString(lblInstAmt);
            }
        }
        
    }
}