<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSuppl.aspx.cs" Inherits="Training.Training7.AddSuppl" %>
<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<%@ Register Src="~/WebUserControl/Lookup/UCLookUpProduce.ascx" TagName="UCLookUpProduce" TagPrefix="uc2" %>


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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Training7/AddSuppl"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Add Supplier</label>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Submit" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Submit_Click" Text="Submit"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Cancel" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Cancel_Click" Text="Cancel"></asp:LinkButton>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <uc1:ucsubsectioncontainer id="ucSubSectionAddSuppl" toggleid="minAddEditSuppl" affectedid="dAddEditSuppl"
                subsectiontitle="Add Edit Supplier" runat="server" />
            <div id="dAddEditSuppl">
                <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplNo" Text="Suppl No"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplNo" CssClass="txtMedInputStyle"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSupplNo" runat="server" ControlToValidate="txtSupplNo"
                                        ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplName" Text="Suppl Name"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplName" CssClass="txtMedInputStyle"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSupplName" runat="server" ControlToValidate="txtSupplName"
                                        ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_Produce" Text="Produce"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <uc2:UCLookUpProduce runat="server" id="ucProduce"></uc2:UCLookUpProduce>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplAddress" Text="Suppl Address"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplAddress" CssClass="txtNotesStyle" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplRt" Text="Suppl Rt"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplRt" CssClass="txtShortInputStyle" MaxLength="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplRw" Text="Suppl Rw"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplRw" CssClass="txtShortInputStyle" MaxLength="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplKelurahan" Text="Suppl Kelurahan"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplKelurahan" CssClass="txtMedInputStyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplKecamatan" Text="Suppl Kecamatan"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplKecamatan" CssClass="txtMedInputStyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplCity" Text="Suppl City"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplCity" CssClass="txtMedInputStyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplZipcode" Text="SupplZipcode"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtSupplZipcode" CssClass="txtShortInputStyle" MaxLength="5"></asp:TextBox>
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
