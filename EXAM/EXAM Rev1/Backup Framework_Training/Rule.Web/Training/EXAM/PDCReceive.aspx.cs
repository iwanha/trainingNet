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
            get { return (Int64)ViewState["AgrmntId"]; }
            set { ViewState["AgrmntId"] = value; }
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
        private string currencyName
        {
            get { return (string)ViewState["currencyName"]; }
            set { ViewState["currencyName"] = value; }
        }
        private string customerName
        {
            get { return (string)ViewState["customerName"]; }
            set { ViewState["customerName"] = value; }
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
                try
                {
                    agrmntId = Convert.ToInt64(base.RedirectState["AgrmntId"]);
                    //branchId = Convert.ToInt64(base.RedirectState["branchId"]);

                    txtBranchName.Enabled = false;
                    txtAgrmntNo.Enabled = false;
                    txtInstAmt.Enabled = false;
                    txtCustomerName.Enabled = false;
                    txtCurrencyName.Enabled = false;
                    txtReceiveFrom.Enabled = true;

                    IExamCustomerService iecs = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
                    Agrmnt a = iecs.GetAgrmntsById(agrmntId);
                    Branch b = iecs.GetBranchById(branchId);
                    Customer c = iecs.GetCustomerById(customerId);
                    RefCurrency rc = iecs.GetCurrenciesById(currencyId);
                    txtAgrmntNo.Text = a.AgrmntNo;

                    txtBranchName.Text = b.BranchName;
                    //txtInstAmt.Text = Convert.ToDecimal(a.InstAmt); //  NOT WORK

                    txtCustomerName.Text = c.CustomerName;
                    txtCurrencyName.Text = rc.CurrencyName;
                    //txtReceiveFrom.Text = 

                    mode = SaveMode.Edit;
                    setEditScreen();
                }
                catch
                {
                    mode = SaveMode.Add;
                }
            }
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
            ucBank.BindingObject(lisRefBank, "BankCode", "BankName", true, UCReference.AdditionalSelectionType.SelectOne);
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
            ltl_Agrmnt_AgrmntId.Text = Convert.ToString(agrmntId); //Not Work
            ltl_Agrmnt_AgrmntNo.Text = agrmnt.AgrmntNo;
            ltl_Branch_BranchName.Text = branch.BranchName;
            ltl_Agrmnt_InstAmt.Text = Convert.ToString(agrmnt.InstAmt);
            txtBranchName.Text = branch.BranchName;
            txtIssueName.Text = customer.CustomerName;
        }
        #endregion
        #region Submit
        protected void lb_Toolbar_Submit_Click(object sender, EventArgs e)
        {
            //if (mode == SaveMode.Add)
            //{
            IExamCustomerService iecs = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
            string saveMode = string.Empty;

            string user = "Training";
            DateTime date = DateTime.Now;

            PdcHeader ph = new PdcHeader();
            PdcDetail pd = new PdcDetail();
            PdcReceipt pr = new PdcReceipt();
            PdcHistory phis = new PdcHistory();
            MasterSequence ms = new MasterSequence();

            ph.PdcNo = "PDC000" + txtPdcNo.Text;
            // Regex
            ph.PdcDueDate = ucPdcDueDate.DateValue;
            ph.PdcAmount = Convert.ToDecimal(ucPdcAmount.Text);
            //ph.PdcHeaderId = Convert.ToInt64(pdcHeaderId);
            //ph.IsCummulative = Convert.ToString(rblIsCummulative.SelectedValue);
            //ph.IsInkaso = rblIsInkaso.SelectedValue;

            pr.ReceiveDate = DateTime.Today;
            pr.ReceiveFrom = txtReceiveFrom.Text;
            pr.AtasNamaPdc = txtIssueName.Text;
            pr.EmployeeId = Convert.ToInt64(employeeId);
            //pr.PdcReceiptNo = "TTG-" + DateTime.Today.AddYears + DateTime.Today.AddMonths + ms.SeqNo;
            

            pd.PaymentAllocation = "INSTALLRCV";
            pd.Description = "Pembayaran Installment";
            pd.Amount = Convert.ToDecimal(ucPdcAmount.Text);

            phis.PdcStatus = "OP";
            phis.FisikStatus = "OH";
            phis.StatusDate = DateTime.Today;
            phis.PdcHistoryId = Convert.ToInt64(pdcHistoryId);

            iecs.AddPdcHeader(ph);
            iecs.AddPdcReceipt(pr);
            iecs.AddPdcDetail(pd);
            iecs.AddPdcHistory(phis);

            RedirectUrl("~/Training/EXAM/PDCReceive.aspx");
            //if (ph.PdcNo == null)
            //{
            //    for (int i = 0; i < ph.PdcNo; i++)
            //}
            //}
            //else
            //{
            //    IExamCustomerService ieCustSvc = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();

            //    Agrmnt a = ieCustSvc.GetAgrmntsById(agrmntId);
            //    Branch b = ieCustSvc.GetBranchById(branchId);
            //    Customer c = ieCustSvc.GetCustomerById(customerId);
            //    RefCurrency rc = ieCustSvc.GetCurrenciesById(refCurrencyId);
            //    PdcReceipt pr = ieCustSvc.GetPdcReceiptByReceiptId(pdcReceiptId);
            //    a.AgrmntNo = txtAgrmntNo.Text;
            //    a.InstAmt = Convert.ToDecimal(txtInstAmt.Text);

            //    b.BranchName = txtBranchName.Text;

            //    c.CustomerName = txtCustomerName.Text;
            //    rc.CurrencyName = txtCurrencyName.Text;
            //    pr.ReceiveFrom = txtReceiveFrom.Text;

            //    ieCustSvc.AddAgrmnt(a);
            //    ieCustSvc.AddPdcReceipt(pr);
            //}
        }

        //public string Substring(int startIndex, int length);

        #endregion
        //#region method
        //private void InsertDataTable()
        //{
        //    List<PdcHeader> listPdcHeader = new List<PdcHeader>();

        //    for (int i = 0; i < 5; i++)
        //    {
        //        PdcHeader pdcHeader = new PdcHeader();
        //        MasterSequence seq = new MasterSequence();
        //        pdcHeader.PdcNo = "PDC" + i;

        //        listPdcHeader.Add(pdcHeader);
        //    }
        //    gvPdcList.DataSource = listPdcHeader;
        //    gvPdcList.DataBind();
        //}
        //#endregion
        #region Cancel
        protected void lbCancel_Click(object sender, EventArgs e)
        {
            // Belum bisa menghapus grid
            RedirectUrl("~/Training/EXAM/AgreementPaging.aspx");
        }
        #endregion

        #region AddToTemp
        protected void lblAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = createDataTable();
            List<PdcHeader> listPdcHeader = new List<PdcHeader>();
            if (txtIssueName.Enabled == true)
            {
                for (int i = 0; i < gvPdcList.Rows.Count; i++)
                {
                    Label lblHoliday = (Label)gvPdcList.Rows[i].FindControl("lblHolidayTemp");  //   Not work
                    Label lblIssueName = (Label)gvPdcList.Rows[i].FindControl("lblIssueNameTemp");
                    //UCReference ucBank = (UCReference)gvPdcListTemp.Rows[i].FindControl("ucBank"); //   Not work
                    Label lblBankPdc = (Label)gvPdcList.Rows[i].FindControl("BankPdc");
                    Label lblPdcNo = (Label)gvPdcList.Rows[i].FindControl("lblPdcNoTemp");
                    Label lblPdcAmount = (Label)gvPdcList.Rows[i].FindControl("lblPdcAmountTemp");
                    Label lblPdcDueDate = (Label)gvPdcList.Rows[i].FindControl("lblPdcDueDateTemp");

                    Label lblIsInkaso = (Label)gvPdcList.Rows[i].FindControl("lblIsInkaso");    //   Not work
                    Label lblIsCummulative = (Label)gvPdcList.Rows[i].FindControl("lblIsCummulative");  //   Not work
                    Label lblPdcType = (Label)gvPdcList.Rows[i].FindControl("lblPdcType");  //   Not work
                    DataRow drowTemp = dt.NewRow();
                    drowTemp[0] = lblHoliday.Text;
                    drowTemp[1] = lblIssueName.Text;
                    drowTemp[2] = lblBankPdc.Text;
                    drowTemp[3] = lblPdcNo.Text;
                    drowTemp[4] = lblPdcAmount.Text;
                    drowTemp[5] = lblPdcDueDate.Text;
                    drowTemp[6] = lblIsInkaso.Text;
                    drowTemp[7] = lblIsCummulative.Text;
                    drowTemp[8] = lblPdcType.Text;
                    dt.Rows.Add(drowTemp);
                }
                DataRow drow = dt.NewRow();

                drow[0] = null;
                drow[1] = txtIssueName.Text;
                drow[2] = ucBank.SelectedValue;
                drow[3] = txtPdcNo.Text;
                drow[4] = Convert.ToDecimal(ucPdcAmount.Text);
                drow[5] = ucPdcDueDate.DateValue;
                drow[6] = rblIsInkaso.SelectedValue;
                drow[7] = rblIsCummulative.SelectedValue;
                drow[8] = rblPdcType.SelectedValue;
                dt.Rows.Add(drow);
            }
            txtIssueName.Enabled = true;
            gvPdcList.DataSource = dt;
            gvPdcList.DataBind();
            upform.Update();
        }
        #endregion
        //#region gvPdcListTemp_RowCommand
        //protected void gvPdcListTemp_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
        //    if (e.CommandName == "DEL")
        //    {
        //        DataTable dt = createDataTable();
        //        for (int i = 0; i < gvPdcListTemp.Rows.Count; i++)
        //        {
        //            Label lblHolidayTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblHolidayTemp"); //   Not work
        //            Label lblIssueNameTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblIssueNameTemp");
        //            Label lblBankPdcTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblBankPdcTemp");  //   Not work
        //            Label lblPdcNoTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcNoTemp");
        //            Label lblPdcAmountTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcAmountTemp");
        //            Label lblPdcDueDateTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcDueDateTemp");
        //            Label lblIsInkasoTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblIsInkasoTemp");    //   Not work
        //            Label lblIsCummulativeTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblIsCummulativeTemp");  //   Not work
        //            Label lblPdcTypeTemp = (Label)gvPdcListTemp.Rows[i].FindControl("lblPdcTypeTemp");  //   Not work
        //            if (i != index)
        //            {
        //                DataRow drowTemp = dt.NewRow();
        //                drowTemp[0] = lblHolidayTemp.Text;  //   Not work
        //                drowTemp[1] = lblIssueNameTemp.Text;
        //                drowTemp[2] = lblBankPdcTemp.Text;  //   Not work
        //                drowTemp[3] = lblPdcNoTemp.Text;
        //                drowTemp[4] = lblPdcAmountTemp.Text;
        //                drowTemp[5] = lblPdcDueDateTemp.Text;
        //                drowTemp[6] = lblIsInkasoTemp.Text; //   Not work
        //                drowTemp[7] = lblIsCummulativeTemp.Text;    //   Not work
        //                drowTemp[8] = lblPdcTypeTemp.Text;  //   Not work
        //            }
        //        }
        //        gvPdcListTemp.DataSource = dt;
        //        gvPdcListTemp.DataBind();
        //        upFormTemp.Update();
        //    }
        //    else if (e.CommandName == "ED")
        //    {
        //        Label lblHolidayTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblHolidayTemp");
        //        Label lblIssueNameTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblIssueNameTemp");
        //        Label lblBankPdcTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblBankPdcTemp");
        //        Label lblPdcNoTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblPdcNoTemp");
        //        Label lblPdcAmountTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblPdcAmountTemp");
        //        Label lblPdcDueDateTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblPdcDueDateTemp");
        //        Label lblIsInkasoTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblIsInkasoTemp");
        //        Label lblIsCummulativeTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblIsCummulativeTemp");
        //        Label lblPdcTypeTemp = (Label)gvPdcListTemp.Rows[index].FindControl("lblPdcTypeTemp");
        //        rblIsInkaso.Text = lblIsInkasoTemp.Text;
        //        rblIsCummulative.Text = lblIsCummulativeTemp.Text;
        //        rblPdcType.Text = lblPdcTypeTemp.Text;
        //        upFormTemp.Update();
        //    }
        //}
        //#endregion
        //#region gvPdcListTemp_RowDataBound
        //protected void gvPdcListTemp_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    IExamCustomerService customerService = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
        //    //Label lblHolidayTemp = (Label)e.Row.FindControl("lblHolidayTemp");
        //    //Label lblIssueNameTemp = (Label)e.Row.FindControl("lblIssueNameTemp");
        //    //Label lblBankPdcTemp = (Label)e.Row.FindControl("lblBankPdcTemp");
        //    //Label lblPdcNoTemp = (Label)e.Row.FindControl("lblPdcNoTemp");
        //    //Label lblPdcAmountTemp = (Label)e.Row.FindControl("lblPdcAmountTemp");
        //    //Label lblPdcDueDateTemp = (Label)e.Row.FindControl("lblPdcDueDateTemp");
        //    //Label lblIsInkasoTemp = (Label)e.Row.FindControl("lblIsInkasoTemp");
        //    //Label lblIsCummulativeTemp = (Label)e.Row.FindControl("lblIsCummulativeTemp");
        //    //Label lblPdcTypeTemp = (Label)e.Row.FindControl("lblPdcTypeTemp");
        //    UCReference ucBank = (UCReference)e.Row.FindControl("ucBank");

        //    //ucBank.BindingObject
        //}
        //#endregion

        protected void gvPdcList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)(((Control)e.CommandSource).Parent.Parent)).RowIndex;
            if (e.CommandName == "DEL")
            {
                List<PdcHeader> listPdcHeader = new List<PdcHeader>();
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

                    txtIssueName.Text = lblIssueName.Text;
                    ucBank.SelectedValue = lblBankPdc.Text;
                    txtPdcNo.Text = lblPdcNo.Text;
                    ucPdcAmount.Text = lblPdcAmount.Text;
                    ucPdcDueDate.DateValue = Convert.ToDateTime(lblPdcDueDate.Text);
                    rblIsInkaso.SelectedValue = lblIsInkaso.Text;
                    rblIsCummulative.SelectedValue = lblIsCummulative.Text;
                    rblPdcType.SelectedValue = lblPdcType.Text;
                    upform.Update();
                    if (i != index)
                    {
                        DataRow drowTemp = dt.NewRow();
                        drowTemp[0] = lblHoliday.Text;
                        drowTemp[1] = lblIssueName.Text;
                        drowTemp[2] = lblBankPdc.Text;
                        drowTemp[3] = lblPdcNo.Text;
                        drowTemp[4] = lblPdcAmount.Text;
                        drowTemp[5] = lblPdcDueDate.Text;
                        drowTemp[6] = lblIsInkaso.Text;
                        drowTemp[7] = lblIsInkaso.Text;
                        drowTemp[8] = lblPdcType.Text;
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
                RadioButtonList lblIsInkaso = (RadioButtonList)gvPdcList.Rows[index].FindControl("lblIsInkaso");
                RadioButtonList lblIsCummulative = (RadioButtonList)gvPdcList.Rows[index].FindControl("lblIsCummulative");
                RadioButtonList lblPdcType = (RadioButtonList)gvPdcList.Rows[index].FindControl("lblPdcType");
                txtIssueName.Text = lblIssueName.Text;
                ucBank.SelectedValue = lblBankPdc.Text;
                txtPdcNo.Text = lblPdcNo.Text;
                ucPdcAmount.Text = lblPdcAmount.Text;
                ucPdcDueDate.DateValue = Convert.ToDateTime(lblPdcDueDate.Text);
                rblIsInkaso.SelectedValue = lblIsInkaso.Text;
                rblIsCummulative.SelectedValue = lblIsCummulative.Text;
                rblPdcType.SelectedValue = lblPdcType.Text;
                upform.Update();
            }
        }

        protected void gvPdcList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    IExamCustomerService customerService = (IExamCustomerService)UnityFactory.Resolve<IExamCustomerService>();
            //    UCReference ucBank = (UCReference)e.Row.FindControl("ucBank");
            //    List<RefBank> listBankService = customerService.listOfRefBank();
            //    ucBank.BindingObject(listBankService, "BankCode", "BankName", false, UCReference.AdditionalSelectionType.SelectOne);
            //}
        }
    }
}