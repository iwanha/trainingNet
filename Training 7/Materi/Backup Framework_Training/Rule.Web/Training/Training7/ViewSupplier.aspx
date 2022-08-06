<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSupplier.aspx.cs" Inherits="Training.Training7.ViewSupplier" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>

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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Training7/ViewSupplier"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">View Supplier</label>
                    </span>
                    <span id="toolMenuContainer">

                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <uc1:ucsubsectioncontainer id="ucSubSectionAViewSupplier" toogleid="minViewSuppler" affectedid="dViewSupplier"
                subsectiontitle="View Supplier" runat="server" />
            <div id="dViewSupplier">
                <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplNo" Text="Suppl No"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblSupplNo"></asp:Label>
                                    <asp:label runat="server" Visible="false" ID="lblSupplId" Text='<%# Eval("SupplId") %>'>test</asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplName" Text="Suppl Name"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblSupplName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_JobTitle" Text="Produce"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblProduce"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Suppl_SupplAddress" Text="Suppl Address"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblSupplAddress"></asp:Label>
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
