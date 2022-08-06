<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomerHandling.aspx.cs" Inherits="Training.Training6.AddCustomerHandling" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UcSubSectionContainer" TagPrefix="uc1" %>>
<%@ Register Src="~/WebUserControl/UCReference.ascx" TagName="UCReference" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCDatePicker.ascx" TagName="UCDatePicker" TagPrefix="uc3" %>
<%@ Register Src="~/WebUserControl/UCInputNumber.ascx" TagName="UCInputNumber" TagPrefix="uc4" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smOrg" runat="server" />
        <asp:UpdatePanel ID="upPath" UpdateMode="Conditional" runat="server" >
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Literal ID="ltl_Path_CustomerHandling" Text="Customer Handling" runat="server" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upToolbar" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="toolbar">
                    <span id="pageTitle">
                        <asp:Literal ID="ltl_Title_CustomerHandling" Text="FORM CUSTOMER HANDLING" runat="server" />
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton ID="lb_toolbar_submit" CssClass="lbMenu" Text="Submit" OnClick="lb_toolbar_submit_Click" runat="server" />
                        <asp:LinkButton ID="lb_toolbar_cancel" CssClass="lbMenu" Text="Cancel" OnClick="lb_toolbar_cancel_Click" runat="server" CausesValidation="false" />
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel ID="upFormCust" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <uc1:ucSubSectionCOntainer id="ucSubSectionCustService" toogleid="minCustService" affectedid="dCustSvc" subsectiontitle="Form Input Customer Service" runat="server" />
                    <div id="dCustSvc">
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_RegistrationNo" Text="Registration No" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtRegistrationNo" CssClass="txtMedInputStyle" runat="server" />
                                    <Label class="mandatoryStyle">*</Label>
                                    <asp:RequiredFieldValidator ID="rfvRegistrationNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtRegistrationNo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_CustomerName" Text="CustomerName" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtCustomerName" CssClass="txtMedInputStyle" runat="server" />
                                    <label class="mandatoryStyle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvCustomerName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtCustomerName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_MobilePhoneNo" Text="Mobile Phone No" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtMobilePhoneNo" CssClass="txtMedInputStyle" runat="server" />
                                    <label class="mandatoryStyle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvMobilePhoneNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtMobilePhoneNo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_Email" Text="Email" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtEmail" CssClass="txtMedInputStyle" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtEmail" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_ServiceCategory" Text="Category" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCReference id="ucServiceCategory" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_MediaOfService" Text="Media Of Service" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCReference id="ucMediaOfService" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_Chronologic" Text="Chronologic" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtChronologic" MaxLength="4000" TextMode="MultiLine" />
                                    <label class="mandatoryStyle">*</label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_AdminFee" Text="Admin Fee Amount" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc4:UCInputNumber id="ucAdminFee" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_CustomerHandling_CompletionDt" Text="Completion Date" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc3:UCDatePicker id="ucCompletionDt" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
