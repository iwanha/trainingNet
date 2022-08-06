<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="Training.AddCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="smapplication"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="upPath" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div id="linkPath">
                        <asp:Label runat="server" ID="lblPath" Text="Training\AddCustomer" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div id="toolbar">
                        <span>
                            <label id="pageTitle">Customer</label>
                        </span>
                        <span id="toolMenuContainer">
                            <asp:LinkButton runat="server" ID="lb_Toolbar_Save" CssClass="lbMenu" Text="Save" CausesValidation="true"
                                OnClick="lb_Toolbar_Save_Click" />
                            <asp:LinkButton runat="server" ID="lb_Toolbar_Edit" CssClass="lbMenu" Text="Edit" CausesValidation="true"
                                OnClick="lb_Toolbar_Edit_Click" />
                            <asp:LinkButton runat="server" ID="lb_Toolbar_Delete" CssClass="lbMenu" Text="Delete" CausesValidation="true"
                                OnClick="lb_Toolbar_Delete_Click" />
                        </span>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
            <div id="Content">
                <asp:UpdatePanel runat="server" ID="upForm" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustNo" Text="Cust No" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtCustNo" MaxLength="20" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustType" Text="Cust Type" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:RadioButtonList runat="server" ID="rblCustType" RepeatDirection="Horizontal" RepeatLayout="Table" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustName" Text="Cust Name" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtCustName" MaxLength="100" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_IdentityType" Text="Identity Type" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:RadioButtonList runat="server" ID="rblIdentityType" RepeatDirection="Horizontal" RepeatLayout="Table" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_IdentityNo" Text="Identity No" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtIdentityNo" MaxLength="16" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_AddressType" Text="Address Type" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:DropDownList runat="server" ID="ddlAddressType" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Address" Text="Address" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtAddress" MaxLength="200" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Rt" Text="RT" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtRt" MaxLength="3" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Rw" Text="RW" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtRw" MaxLength="3" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Kelurahan" Text="Kelurahan" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtKelurahan" MaxLength="20" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Kecamatan" Text="Kecamatan" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtKecamatan" MaxLength="20" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_City" Text="City" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtCity" MaxLength="20" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Zipcode" Text="Zipcode" />
                                </td>
                                <td style="width: 50%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtZipcode" MaxLength="10" CssClass="txtMedInputStyle" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
