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

namespace Training
{
    public partial class CustPaging : WebFormBase
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

        }

        protected void gvCust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;

            if (e.CommandName == "Sort")
            {
                string isAcc = "true";
                if (orderBy != null && orderBy.Keys.FirstOrDefault() == e.CommandArgument.ToString())
                {
                    isAcc = orderBy.Values.FirstOrDefault() == "true" ? "false" : "true";
                }

                orderBy = new Dictionary<string,string>();
                orderBy.Add(e.CommandArgument.ToString(), isAcc);
                searchClick(currentPage);
            }
        }

        protected void gvCust_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal lblMonthlyIncome = Convert.ToDecimal(((Label)e.Row.FindControl("lbl_Cust_MonthlyIncome")).Text);
                ((Label)e.Row.FindControl("lbl_Cust_MonthlyIncome")).Text = DcmFormatter.FormatToString(lblMonthlyIncome);
                
                DateTime lblBirthDt = Convert.ToDateTime(((Label)e.Row.FindControl("lbl_Cust_BirthDt")).Text);
                ((Label)e.Row.FindControl("lbl_Cust_BirthDt")).Text = DtFormatter.FormatToString(lblBirthDt);
            }
        }

        private void initSearchBy()
        {
            ICustomerService custSvc = (ICustomerService)UnityFactory.Resolve<ICustomerService>();

            List<RefMaster> listMaritalStat = custSvc.GetListRefMasterByMasterType("MARITAL_STAT");

            //  filteran di search nya
            scParam = new SearchControlParam();
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[] {
                new FixedSearchPropSpec("Birth Date >=", "BirthDt", typeof(DateTime), false, SearchPropSpec.SearchCondition.gte),   // referensi kaya BirthDt ada di Eval aspx, fale/true = mandatory, SearchCondition = kondisi
                new FixedSearchPropSpec("Birth Date <=", "BirthDt", typeof(DateTime), false, SearchPropSpec.SearchCondition.lte),
                new FixedSearchPropSpec("Monthly Income >=", "MonthlyIncome", typeof(Decimal), false, SearchPropSpec.SearchCondition.gte),
                new FixedSearchPropSpec("Monthly Income <=", "MonthlyIncome", typeof(Decimal), false, SearchPropSpec.SearchCondition.lte),
                new FixedSearchPropSpec("Customer No", "CustomerNo", typeof(string)),
                new FixedSearchPropSpec("Customer Name", "Customer Name", typeof(string)), 
                new FixedSearchPropSpec("Marital Status", "MaritalStat", listMaritalStat, "Description", "MasterCode", typeof(string), false, UCReference.AdditionalSelectionType.All)
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

            if (orderBy == null) // parameter default di header tabel bawah
            {
                parameter.AddOrderBy("CustName", true);
            }
            else
            {
                parameter.AddOrderBy(orderBy.Keys.FirstOrDefault(), bool.Parse(orderBy.Values.FirstOrDefault()));
            }

            parameter.EntitiesTypeName = ConfinsEntitiesType.TRN;
            parameter.Criteria = criteria;
            pagingResult = qsOrgSvc.QueryPaging("QryPagingCust", pagingSpec, parameter);

            if (isCount)
            {
                ucGridFooter.SetTotalRecrod(pagingResult.Count);
            }

            if (isData)
            {
                gvCust.DataSource = pagingResult.Data;
                gvCust.DataBind();
                ItalicizeHeaderRow(gvCust);
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