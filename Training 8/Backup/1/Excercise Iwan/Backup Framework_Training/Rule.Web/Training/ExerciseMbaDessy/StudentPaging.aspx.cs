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

namespace Training.ExerciseMbaDessy
{
    public partial class StudentPaging : WebFormBase
    {
        protected global::Rule.Web.WebUserControl.Search.UCSearch ucSearch;
        protected global::Rule.Web.WebUserControl.UCGridHeader ucGridHeader;
        protected global::Rule.Web.WebUserControl.UCGridFooter ucGridFooter;
        protected global::Rule.Web.WebUserControl.UCReference ucCourse;

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
            IRefMajorService iss = (IRefMajorService)UnityFactory.Resolve<IRefMajorService>();
            scParam = new SearchControlParam();
            List<RefMajor> listRefMajor = iss.listOfRefMajor("Teknik");
            scParam.AddFixedSearchPropSpec(new FixedSearchPropSpec[]{
                new FixedSearchPropSpec("Student No","StudentNo"),
            new FixedSearchPropSpec("Student Name","StudentName"),
                new FixedSearchPropSpec("Major","RefMajorId", listRefMajor, "MajorName","RefMajorId", typeof(string), 
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
                parameter.AddOrderBy("StudentNo", true);
            }
            else
            {
                parameter.AddOrderBy(orderBy.Keys.FirstOrDefault(), bool.Parse(orderBy.Values.FirstOrDefault()));
            }

            parameter.EntitiesTypeName = ConfinsEntitiesType.TRN;
            parameter.Criteria = criteria;
            pagingResult = qsOrgSvc.QueryPaging("QueryPagingLookupMajor", pagingSpec, parameter);

            if (isCount)
            {
                ucGridFooter.SetTotalRecrod(pagingResult.Count);
            }

            if (isData)
            {
                gvStudent.DataSource = pagingResult.Data;
                gvStudent.DataBind();
                ItalicizeHeaderRow(gvStudent);
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
        protected void lb_Toolbar_Add_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/ExerciseBuDessy/AddStudent.aspx");
        }

        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IStudentService iss = (IStudentService)UnityFactory.Resolve<IStudentService>();
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
                string studentId = ((Label)gvStudent.Rows[index].FindControl("lblStudentId")).Text;
                base.RedirectUrl("~/Training/ExerciseBuDessy/AddStudent.aspx", PageRedirectionState.InitAdd("studentId", studentId));
            }
            else if (e.CommandName == "DEL")
            {
                string studentId = ((Label)gvStudent.Rows[index].FindControl("lblStudentId")).Text;
                iss.DeleteStudent(Convert.ToInt64(studentId));
                string popupUrl = this.ResolveUrl("~/Training/ExerciseBuDessy/StudentPaging.aspx");
            

            }
        }
    }
}