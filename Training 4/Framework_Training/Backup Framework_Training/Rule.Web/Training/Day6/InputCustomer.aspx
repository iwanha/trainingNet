<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputCustomer.aspx.cs" Inherits="Training.Day6.InputCustomer" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UcSubSectionContainer" TagPrefix="uc1" %>>

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
                    <asp:Literal ID="ltl_Path_InputCustomer" Text="Day6/Input Customer" runat="server" />

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
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">

                                </td>
                                <td width="80%" class="tdValue">

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
