<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputCustomer.aspx.cs" Inherits="Training.InputCustomer" %>

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
                    <asp:Literal ID="ltl_Path_InputCustomer" Text="Input Customer" runat="server" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upToolbar" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="toolbar">
                    <span id="pageTitle">
                        <asp:Literal ID="ltl_Title_InputCust" Text="FORM INPUT CUSTOMER" runat="server"/>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton ID="lb_toolbar_submit" CssClass="lbMenu" Text="Submit" OnClick="lb_toolbar_submit_Click" runat="server" />
                        <asp:LinkButton ID="lb_toolbar_cancel" CssClass="lbMenu" Text="Cancel" OnClick="lb_toolbar_cancel_Click" runat="server" />
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div id="content">
            <asp:UpdatePanel ID="upFormCust" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <uc1:ucSubSectionContainer id="ucSubSectionCustData" toogleid="minCustData" affectedid="dCustData" subsectiontitle="Customer Main Data" runat="server"/>
                    <div id="dCustData">
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_CustNo" Text="Customer No" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtCustNo" CssClass="txtMedInputStyle" runat="server" />
                                    <label class="mandatoryStyle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvCustNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtCustNo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_CustName" Text="Customer Name" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtCustName" CssClass="txtMedInputStyle" runat="server" />
                                    <label class="mandatoryStyle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvCustName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtCustName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_IdType" Text="Identity Type" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCReference id="ucIdType" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal Text="Identity No" ID="ltl_Cust_IdNo" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtIdNo" CssClass="txtMedInputStyle" runat="server" />
                                    <label class="mandatoryStyle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvIdNo" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtIdNo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_BirthPlace" Text="Birth Place" runat="server" />
                                    /
                                      <asp:Literal ID="ltl_Cust_BirthDt" Text="Birth Date" runat="server" />
                                  
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtBirthPlace" CssClass="txtMedInputStyle" runat="server" />
                                    <label class="mandatoryStyle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvBirthPlace" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="This field is required" ControlToValidate="txtBirthPlace" runat="server" />
                                    /
                                   <uc3:UCDatePicker id="ucBirthDt" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_MaritalStatus" Text="Marital Status" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCReference id="ucMaritalStatus" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_Religion" Text="Religion" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCReference id="ucReligion" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_Nationality" Text="Nationality" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCReference id="ucNationality" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltl_Cust_MonthlyIncome" Text="Monthly Income" runat="server" />
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc4:UCInputNumber id="ucMonthlyIncome" runat="server" />
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
