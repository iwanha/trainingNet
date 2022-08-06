using AdIns.Service;
using Rule.Web;
using Rule.Web.WebUserControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.API;
using Training.DataModel.TrainingModel;

namespace Training.EXAM
{
    public partial class PDCReceive : WebFormBase
    {
        
        protected global::Rule.Web.WebUserControl.Lookup.UCLookUpExamCustomer ucReceiveBy;
        protected global::Rule.Web.WebUserControl.UCDatePicker ucPdcDueDate;
        protected global::Rule.Web.WebUserControl.UCReference ucBank;
        protected global::Rule.Web.WebUserControl.UCInputNumber ucPdcAmount, ucNumOfPdc;

        #region Properties
        private enum SaveMode
        {
            Add,
            Edit
        }
        private SaveMode mode
        {
            get { return (SaveMode)ViewState["mode"]; }
            set { ViewState["mode"] = value; }
        }
        private Int64 agrmntId
        {
            get { return (Int64)ViewState["agrmntId"]; }
            set { ViewState["agrmntId"] = value; }
        }
        private Int64 agrmntNo
        {
            get { return (Int64)ViewState["agrmntNo"]; }
            set { ViewState["agrmntNo"] = value; }
        }
        private Int64 branchId
        {
            get { return (Int64)ViewState["branchId"]; }
            set { ViewState["branchId"] = value; }
        }
        private Int64 customerId
        {
            get { return (Int64)ViewState["customerId"]; }
            set { ViewState["customerId"] = value; }
        }
        private Int64 currencyId
        {
            get { return (Int64)ViewState["currencyId"]; }
            set { ViewState["currencyId"] = value; }
        }
        private Int64 masterSequenceId
        {
            get { return (Int64)ViewState["masterSequenceId"]; }
            set { ViewState["masterSequenceId"] = value; }
        }
        private Int64 pdcReceiptId
        {
            get { return (Int64)ViewState["pdcReceiptId"]; }
            set { ViewState["pdcReceiptId"] = value; }
        }
        private Int64 employeeId
        {
            get { return (Int64)ViewState["employeeId"]; }
            set { ViewState["employeeId"] = value; }
        }
        private Int64 pdcHeaderId
        {
            get { return (Int64)ViewState["pdcHeaderId"]; }
            set { ViewState["pdcHeaderId"] = value; }
        }
        private Int64 refBankId
        {
            get { return (Int64)ViewState["refBankId"]; }
            set { ViewState["refBankId"] = value; }
        }
        private Int64 pdcDetailId
        {
            get { return (Int64)ViewState["pdcDetailId"]; }
            set { ViewState["pdcDetailId"] = value; }
        }
        private Int64 pdcHistoryId
        {
            get { return (Int64)ViewState["pdcHistoryId"]; }
            set { ViewState["pdcHistoryId"] = value; }
        }
        private Int64 holidayId
        {
            get { return (Int64)ViewState["holidayId"]; }
            set { ViewState["holidayId"] = value; }
        }
        private Int64 refCurrencyId
        {
            get { return (Int64)ViewState["refCurrencyId"]; }
            set { ViewState["refCurrencyId"] = value; }
        }
        private Int64 currencyName
        {
            get { return (Int64)ViewState["currencyName"]; }
            set { ViewState["currencyName"] = value; }
        }
        #endregion
        #region DATA TABLE
        private DataTable createDataTable()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            dt.Columns.Add("Holiday");
            dt.Columns.Add("IssueName");
            dt.Columns.Add("BankPdc");
            dt.Columns.Add("PdcNo");
            dt.Columns.Add("PdcAmount");
            dt.Columns.Add("PdcDueDate");
            dt.Columns.Add("IsInkaso");
            dt.Columns.Add("IsCummulative");
            dt.Columns.Add("PdcType");
            return dt;
        }
        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    agrmntId = Convert.ToInt64(base.RedirectState["agrmntId"]);
                    //branchId = Convert.ToInt64(base.RedirectState["branchId"]);

                    mode = SaveMode.Edit;
                    setEditScreen();
                }
                catch
                {
                    mode = SaveMode.Add;
                }
            }
            #region Binding RadioButtonList
            IList listRadioBtn = new List<KeyValuePair<string, string>>();
            IList listRadioBtnk = new List<KeyValuePair<string, string>>();
            IList listRadioBtnl = new List<KeyValuePair<string, string>>();

            listRadioBtn.Add(new KeyValuePair<string, string>("Yes", "Yes"));
            listRadioBtn.Add(new KeyValuePair<string, string>("No", "No"));


            rblIsInkaso.DataSource = listRadioBtn;
            rblIsInkaso.DataTextField = "Key";
            rblIsInkaso.DataValueField = "Value";
            rblIsInkaso.DataBind();

            listRadioBtnl.Add(new KeyValuePair<string, string>("Yes", "Yes"));
            listRadioBtnl.Add(new KeyValuePair<string, string>("No", "No"));

            rblIsCummulative.DataSource = listRadioBtnl;
            rblIsCummulative.DataTextField = "Key";
            rblIsCummulative.DataValueField = "Value";
            rblIsCummulative.DataBind();

            listRadioBtnk.Add(new KeyValuePair<string, string>("Chegue", "Chegue"));
            listRadioBtnk.Add(new KeyValuePair<string, string>("Giro", "Giro"));

            rblPdcType.DataSource = listRadioBtnk;
            rblPdcType.DataTextField = "Key";
            rblPdcType.DataValueField = "Value";
            rblPdcType.DataBind();
            #endregion
            setScreen();
            
            ucReceiveBy.LookupBase.EnableTextChanged();
            ucReceiveBy.LookupBase.txtInputObj.TextChanged += new EventHandler(ucReceiveBy.LookupBase.txtInput_TextChanged);
        }
        #endregion
        #region setScreen
        private void setScreen()
        {
            IExamCustomerService customerService = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();

            #region Bank
            List<RefBank> lisRefBank = customerService.listOfRefBank();
            ucBank.BindingObject(lisRefBank, "BankName", "BankCode", true, UCReference.AdditionalSelectionType.SelectOne);
            #endregion
            
        }
        #endregion
        #region setEditScreen
        private void setEditScreen()
        {
            IExamCustomerService iecs = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
            Agrmnt agrmnt = iecs.GetAgrmntsById(agrmntId);
            Branch branch = iecs.GetBranchById(branchId);
            Customer customer = new Customer();
            //ltl_Agrmnt_AgrmntId.Text = Convert.ToInt64(agrmntId); //Not Work
            ltl_Agrmnt_AgrmntNo.Text = agrmnt.AgrmntNo;
            ltl_Branch_BranchName.Text = branch.BranchName;
            ltl_Agrmnt_InstAmt.Text = Convert.ToString(agrmnt.InstAmt);
            

        }
        #endregion
        #region Submit
        protected void lb_Toolbar_Submit_Click(object sender, EventArgs e)
        {
            IExamCustomerService iecs = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();

            if (mode == SaveMode.Add)
            {
                PdcHeader ph = new PdcHeader();
                PdcDetail pd = new PdcDetail();
                PdcReceipt pr = new PdcReceipt();
                PdcHistory phis = new PdcHistory();
                string user = "Training";
                DateTime date = DateTime.Now;
                pr.AtasNamaPdc = txtIssueName.Text;
                ph.PdcNo = txtPdcNo.Text;
                ph.PdcDueDate = Convert.ToDateTime(ucPdcDueDate.Text);






                //for (int i = 0; i < gvPdcListTemp.Rows.Count; i++)
                //{
                //    string users = user;
                //    DateTime dates = date;

                //}
                //iecs.AddAgrmnt(agrmnt);
                //}
                //else if (mode == SaveMode.Edit)
                //{
                //    Agrmnt agrmnt = iecs.GetAgrmntsById(agrmntId);
                //    Branch branch = new Branch();
                //    string saveMode = string.Empty;
                //    string User = "Training";
                //    DateTime date = DateTime.Now;


                //    for (int i = 0; i < gvPdcListTemp.Rows.Count; i++)
                //    {

                //    }
                //    iecs.EditAgrmnt();
                //}
            }
            //iecs.EditPdcHeader(ph);

            RedirectUrl("~/Training/EXAM/AgreementPaging.aspx");
        }
        #endregion
        #region Cancel
        protected void lbCancel_Click(object sender, EventArgs e)
        {
            RedirectUrl("~/Training/EXAM/AgreementPaging.aspx");
        }
        #endregion
        #region AddToTemp
        protected void lblAddToTemp_Click(object sender, EventArgs e)
        {
            try
            {
                List<RefBank> listBank = new List<RefBank>();
                List<PdcReceipt> Listpr = new List<PdcReceipt>();

                List<RefBank> listBankTemp = new List<RefBank>();
                List<PdcReceipt> ListprTemp = new List<PdcReceipt>();

                for (int i = 0; i < gvPdcList.Rows.Count; i++)
                {

                }
            }
        }
        #endregion
        #region gvPdcListTemp_RowCommand
        protected void gvPdcListTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                DataTable dt = createDataTable();
                List<RefBank> listBank = new List<RefBank>();
                List<PdcReceipt> Listpr = new List<PdcReceipt>();

                List<RefBank> listBankTemp = new List<RefBank>();
                List<PdcReceipt> ListprTemp = new List<PdcReceipt>();

                Label lblIssueNameDelete = (Label)gvPdcListTemp.Rows[index].FindControl("lblIssueNameDelete");
                for (int i = 0; i < gvPdcListTemp.Rows.Count; i++)
                {
                    RefBank bank = new RefBank();
                    PdcReceipt pr = new PdcReceipt();
                    //Label lblHolidayTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblHolidayTemp"); //   Not work
                    Label lblIssueNameTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblIssueNameTemp");
                    Label lblBankPdcTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblBankPdcTemp");  //   Not work
                    //Label lblPdcNoTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcNoTemp");
                    //Label lblPdcAmountTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcAmountTemp");
                    //Label lblPdcDueDateTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcDueDateTemp");
                    //Label lblIsInkasoTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblIsInkasoTemp");    //   Not work
                    //Label lblIsCummulativeTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblIsCummulativeTemp");  //   Not work
                    //Label lblPdcTypeTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcTypeTemp");  //   Not work
                    pr.AtasNamaPdc = lblIssueNameTemp.Text;
                    bank.BankName = lblBankPdcTemp.Text;

                    listBank.Add(bank);
                    Listpr.Add(pr);
                }
                for (int j = 0; j < gvPdcListTemp.Rows.Count; j++)
                {
                    
                    Label lblIssueNameTemp = (Label)gvPdcListTemp.Rows[j].FindControl("lblIssueNameTemp");
                    Label lblBankPdcTemp = (Label)gvPdcListTemp.Rows[j].FindControl("lblBankPdcTemp");

                    RefBank bank = new RefBank();
                    PdcReceipt pr = new PdcReceipt();
                    if(lblIssueNameDelete.Text != lblIssueNameTemp.Text)
                    {
                        pr.AtasNamaPdc = lblIssueNameTemp.Text;
                        bank.BankName = lblBankPdcTemp.Text;
                        listBankTemp.Add(bank);
                        ListprTemp.Add(pr);
                    }
                    else
                    {
                        pr.AtasNamaPdc = lblIssueNameTemp.Text;
                        bank.BankName = lblBankPdcTemp.Text;
                        listBank.Add(bank);
                        Listpr.Add(pr);
                    }
                }
                gvPdcList.DataSource = listBank;
                gvPdcList.DataBind();
                gvPdcList.DataSource = listBankTemp;
                gvPdcList.DataBind();
                gvPdcList.DataSource = Listpr;
                gvPdcList.DataBind();
                gvPdcList.DataSource = ListprTemp;
                gvPdcList.DataBind();
                
                upFormTemp.Update();
            }
        }
        #endregion
        #region gvPdcListTemp_RowDataBound
        protected void gvPdcListTemp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            IExamCustomerService customerService = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
            //Label lblHolidayTemp = (Label)e.Row.FindControl("lblHolidayTemp");
            //Label lblIssueNameTemp = (Label)e.Row.FindControl("lblIssueNameTemp");
            //Label lblBankPdcTemp = (Label)e.Row.FindControl("lblBankPdcTemp");
            //Label lblPdcNoTemp = (Label)e.Row.FindControl("lblPdcNoTemp");
            //Label lblPdcAmountTemp = (Label)e.Row.FindControl("lblPdcAmountTemp");
            //Label lblPdcDueDateTemp = (Label)e.Row.FindControl("lblPdcDueDateTemp");
            //Label lblIsInkasoTemp = (Label)e.Row.FindControl("lblIsInkasoTemp");
            //Label lblIsCummulativeTemp = (Label)e.Row.FindControl("lblIsCummulativeTemp");
            //Label lblPdcTypeTemp = (Label)e.Row.FindControl("lblPdcTypeTemp");
            UCReference ucBank = (UCReference)e.Row.FindControl("ucBank");


            //ucBank.BindingObject
        }
        #endregion

        protected void gvPdcList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                DataTable dt = createDataTable();
                for (int i = 0; i < gvPdcList.Rows.Count; i++)
                {
                    Label lblHoliday = (Label)gvPdcList.Rows[i].FindControl("lblHoliday");
                    Label lblIssueName = (Label)gvPdcList.Rows[i].FindControl("lblIssueName");
                    Label lblBankPdc = (Label)gvPdcList.Rows[i].FindControl("lblBankPdc");
                    Label lblPdcNo = (Label)gvPdcList.Rows[i].FindControl("lblPdcNo");
                    Label lblPdcAmount = (Label)gvPdcList.Rows[i].FindControl("lblPdcAmount");
                    Label lblPdcDueDate = (Label)gvPdcList.Rows[i].FindControl("lblPdcDueDate");
                    Label lblIsInkaso = (Label)gvPdcList.Rows[i].FindControl("lblIsInkaso");
                    Label lblIsCummulative = (Label)gvPdcList.Rows[i].FindControl("lblIsCummulative");
                    Label lblPdcType = (Label)gvPdcList.Rows[i].FindControl("lblPdcType");
                    if (i != index)
                    {
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblHoliday.Text;
                        drowTemp[1] = lblIssueName.Text;
                        drowTemp[2] = ucBank.SelectedValue;
                        drowTemp[3] = Convert.ToInt64(lblPdcNo.Text);
                        drowTemp[4] = Convert.ToDecimal(ucPdcAmount.Text);
                        drowTemp[5] = ucPdcDueDate.DateValue;
                        drowTemp[6] = rblIsInkaso.SelectedValue;
                        drowTemp[7] = rblIsCummulative.SelectedValue;
                        drowTemp[8] = rblPdcType.SelectedValue;
                        dt.Rows.Add(drowTemp);

                    }

                }
                gvPdcList.DataSource = dt;
                gvPdcList.DataBind();

                upform.Update();
            }
            else if (e.CommandName == "ED")
            {
                Label lblHoliday = (Label)gvPdcList.Rows[index].FindControl("lblHoliday");
                Label lblIssueName = (Label)gvPdcList.Rows[index].FindControl("lblIssueName");
                Label lblBankPdc = (Label)gvPdcList.Rows[index].FindControl("lblBankPdc");
                Label lblPdcNo = (Label)gvPdcList.Rows[index].FindControl("lblPdcNo");
                Label lblPdcAmount = (Label)gvPdcList.Rows[index].FindControl("lblPdcAmount");
                Label lblPdcDueDate = (Label)gvPdcList.Rows[index].FindControl("lblPdcDueDate");
                Label lblIsInkaso = (Label)gvPdcList.Rows[index].FindControl("lblIsInkaso");
                Label lblIsCummulative = (Label)gvPdcList.Rows[index].FindControl("lblIsCummulative");
                Label lblPdcType = (Label)gvPdcList.Rows[index].FindControl("lblPdcType");
                txtIssueName.Text = lblIssueName.Text;
                txtBranchName.Text = ucBank.SelectedValue;
                upform.Update();
            }
        }

        protected void gvPdcList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}