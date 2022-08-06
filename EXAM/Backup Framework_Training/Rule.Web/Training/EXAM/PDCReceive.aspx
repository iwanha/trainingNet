<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PDCReceive.aspx.cs" Inherits="Training.EXAM.PDCReceive" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<%@ Register Src="~/WebUserControl/Lookup/UCLookUpExamCustomer.ascx" TagName="UCLookUpExamCustomer" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCReference.ascx" TagName="UCReference" TagPrefix="uc3" %>
<%@ Register Src="~/WebUserControl/UCInputNumber.ascx" TagName="UCInputNumber" TagPrefix="uc4" %>
<%@ Register Src="~/WebUserControl/UCDatePicker.ascx" TagName="UCDatePicker" TagPrefix="uc5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="smApplication"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upPath" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Label runat="server" ID="lblPath" Text="Training/EXAM/PDCReceive"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Add Student</label>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Submit" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Submit_Click" Text="Submit"></asp:LinkButton>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <uc1:ucsubsectioncontainer id="ucSubSectionPDCReceive" toggleid="minSubmitPDCReceive" affectedid="dSubmitPDCReceive"
                subsectiontitle="PDC Receive" runat="server" />
            <div id="dSubmitPDCReceive">
                <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <table class="formTable">
                            <%--PDC Detail--%>
                            <tr>
                                <td width="25%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Branch_BranchName" Text="Agreement Branch"></asp:Literal>
                                </td>
                                <td width="25%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtBranchName" Visible="false" CssClass="txtMedInputStyle"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtBranchId" Visible="false"></asp:TextBox>
                                </td>
                                <td width="25%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Branch_CurrencyName" Text="Currency"></asp:Literal>
                                </td>
                                <td width="25%" class="tdValue"></td>
                            </tr>

                            <tr>
                                <td width="25%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Agrmnt_AgrmntNo" Text="Agreement No"></asp:Literal>
                                    <asp:Literal runat="server" ID="ltl_Agrmnt_AgrmntId" Visible="false"></asp:Literal>
                                </td>
                                <td width="25%" class="tdValue"></td>
                                <td width="25%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Customer_CustomerName" Text="Customer Name"></asp:Literal>
                                </td>
                                <td width="25%" class="tdValue"></td>
                            </tr>



                            <tr>
                                <td width="25%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Agrmnt_InstAmt" Text="Installment Amount"></asp:Literal>
                                </td>
                                <td width="25%" class="tdValue"></td>
                                <td width="25%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_PdcReceipt_ReceiveFrom" Text="Receive From"></asp:Literal>
                                </td>
                                <td width="25%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtReceiveFrom" MaxLength="100"></asp:TextBox>
                                    <label class="mandatoryStyle">*</label>
                                </td>
                            </tr>


                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <uc1:ucsubsectioncontainer id="ucSubSectionPdcDetail" toggleid="minSubmitPDCDetail" affectedid="dSubmitPDCDetail"
                    subsectiontitle="PDC Detail" runat="server" />
                <div id="dSubmitPDCDetail">
                    <asp:UpdatePanel runat="server" ID="bottomGrid" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <table class="formTable">
                                <tr>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_PdcNo" Text="PDC No"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <asp:TextBox runat="server" ID="txtPdcNo" MaxLength="20"></asp:TextBox>
                                        <label class="mandatoryStyle">*</label>
                                        <asp:RequiredFieldValidator ID="rfvPdcNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtPdcNo" runat="server" />

                                    </td>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_PdcAmount" Text="PDC Amount"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <uc4:UCInputNumber runat="server" id="ucPdcAmount" />
                                        <label class="mandatoryStyle">*</label>

                                    </td>
                                </tr>



                                <tr>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_IssueName" Text="PDC Issue Name"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <asp:TextBox runat="server" ID="txtIssueName"></asp:TextBox>
                                        <label class="mandatoryStyle">*</label>
                                        <asp:RequiredFieldValidator ID="rfvIssueName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtIssueName" runat="server" />
                                    </td>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_Employee_EmployeeId" Text="Receive By"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <uc2:UCLookUpExamCustomer runat="server" id="ucReceiveBy" />
                                        <label class="mandatoryStyle">*</label>

                                    </td>
                                </tr>

                                <tr>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_RefBank_BankName" Text="Bank Name"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <uc3:UCReference runat="server" id="ucBank" />
                                    </td>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_IsInkaso" Text="Inkaso Flag"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <asp:RadioButtonList runat="server" ID="rblIsInkaso" RepeatDirection="Horizontal" RepeatLayout="Table"></asp:RadioButtonList>

                                    </td>
                                </tr>



                                <tr>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcReceipt_NumOfPdc" Text="Number of PDC"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <asp:TextBox runat="server" ID="txtNumberOfPdc"></asp:TextBox>
                                        pcs
                                    <asp:RequiredFieldValidator ID="rfvNumOfPdc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtNumberOfPdc" runat="server" />

                                    </td>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_IsCummulative" Text="Cummulative Flag"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <asp:RadioButtonList runat="server" ID="rblIsCummulative" RepeatDirection="Horizontal" RepeatLayout="Table"></asp:RadioButtonList>
                                    </td>
                                </tr>



                                <tr>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_PdcDueDate" Text="PDC Due Date"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">

                                        <uc5:UCDatePicker runat="server" id="ucPdcDueDate" />
                                    </td>
                                    <td width="25%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_PdcHeader_PdcType" Text="PDC Type"></asp:Literal>
                                    </td>
                                    <td width="25%" class="tdValue">
                                        <asp:RadioButtonList runat="server" ID="rblPdcType" RepeatDirection="Horizontal" RepeatLayout="Table"></asp:RadioButtonList>
                                    </td>


                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <br />
                    <div id="dAddToTemp" runat="server" align="right">
                        <asp:LinkButton runat="server" ID="lblAddToTemp" Text="Add" CssClass="button" OnClick="lblAddToTemp_Click"
                            CausesValidation="false"></asp:LinkButton>

                        <asp:LinkButton runat="server" ID="lbCancel" Text="Cancel" CssClass="button" OnClick="lbCancel_Click"
                            CausesValidation="false"></asp:LinkButton>
                    </div>
                    <br />
                    <br />
                    <asp:UpdatePanel runat="server" ID="upform" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="Div1">
                                <asp:GridView runat="server" ID="gvPdcList" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                    AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvPdcList_RowCommand" OnRowDataBound="gvPdcList_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlHoliday" Text="Holiday"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblHoliday" Text='<%# Eval("Holiday") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlIssueName" Text="Issue Name"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblIssueName" Text='<%# Eval("IssueName") %>'></asp:Label>
                                                <%--<uc4:UCReference id="ucCourse" runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlBankPdc" Text="BankPdc"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblBankPdc" Text='<%# Eval("BankPdc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcNo" Text="PDC No"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPdcNo" Text='<%# Eval("PdcNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcAmount" Text="PDC Amount"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPdcAmount" Text='<%# Eval("PdcAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcDueDate" Text="PDC Due Date"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <asp:Label runat="server" ID="lblPdcDueDate" Text='<%# Eval("PdcDueDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlIsInkaso" Text="Inkaso"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblIsInkaso" Text='<%# Eval("IsInkaso") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlIsCummulative" Text="Cumm"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblIsCummulative" Text='<%# Eval("IsCummulative") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcType" Text="PDC Type"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPdcType" Text='<%# Eval("PdcType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                                    ToolTip="Delete Record" CausesValidation="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <br />

                    <asp:UpdatePanel runat="server" ID="upFormTemp" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="Div2">
                                <asp:GridView runat="server" ID="gvPdcListTemp" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                    AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvPdcListTemp_RowCommand" OnRowDataBound="gvPdcListTemp_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlHolidayTemp" Text="Holiday"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblHolidayTemp" Text='<%# Eval("Holiday") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlIssueNameTemp" Text="Issue Name"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblIssueNameTemp" Text='<%# Eval("IssueName") %>'></asp:Label>
                                                <%--<uc4:UCReference id="ucCourse" runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlBankPdcTemp" Text="BankPdc"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblBankPdcTemp" Text='<%# Eval("BankPdc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcNoTemp" Text="PDC No"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPdcNoTemp" Text='<%# Eval("PdcNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcAmountTemp" Text="PDC Amount"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPdcAmountTemp" Text='<%# Eval("PdcAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcDueDateTemp" Text="PDC Due Date"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <asp:Label runat="server" ID="lblPdcDueDateTemp" Text='<%# Eval("PdcDueDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlIsInkasoTemp" Text="Inkaso"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblIsInkasoTemp" Text='<%# Eval("IsInkaso") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlIsCummulativeTemp" Text="Cumm"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblIsCummulativeTemp" Text='<%# Eval("IsCummulative") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlPdcTypeTemp" Text="PDC Type"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPdcTypeTemp" Text='<%# Eval("PdcType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                            <HeaderTemplate>
                                                <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                                    ToolTip="Delete Record" CausesValidation="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
    </form>
</body>
</html>
