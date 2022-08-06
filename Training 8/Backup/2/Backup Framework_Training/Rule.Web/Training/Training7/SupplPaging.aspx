<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplPaging.aspx.cs" Inherits="Training.Training7.SupplPaging" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UcSubSectionContainer" TagPrefix="uc1" %>>
<%@ Register Src="~/WebUserControl/Search/UCSearch.ascx" TagName="UcSearch" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCGridFooter.ascx" TagName="UcGridFooter" TagPrefix="uc3" %>
<%@ Register Src="~/WebUserControl/UCGridHeader.ascx" TagName="UcGridHeader" TagPrefix="uc4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smApplication" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upPath" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Label runat="server" ID="lblPath" Text="Training/Training7/SupplPaging"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Supplier Paging</label>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Add" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Add_Click" Text="Add"></asp:LinkButton>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel runat="server" ID="upSearch" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form" id="dSearchSection" runat="server">
                        <uc2:UcSearch id="ucSearch" runat="server" title="List Supplier" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form" id="dGridSection" runat="server" visible="false">
                        <uc1:ucsubsectioncontainer id="ucSubSection" toogleid="minSearch" affectedid="dGrid"
                            subsectiontitle="List of Suplier" runat="server" />
                        <div id="dGrid">
                            <uc4:UcGridHeader id="ucGridHeader" runat="server" />
                            <asp:GridView runat="server" ID="gvSuppl" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvSuppl_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Suppl_SupplNo" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="SupplNo" Text="Supplier No"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Suppl_SupplNo" Text='<%# Eval("SupplNo") %>' CausesValidation="false" CommandName="ViewSuppl"></asp:LinkButton>
                                            <asp:Label runat="server" Visible="false" ID="lblSupplId" Text='<%# Eval("SupplId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Suppl_SupplName" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="SupplName" Text="Supplier Name"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSupplName" Text='<%# Eval("SupplName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Suppl_SupplAddress" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="SupplAddress" Text="Supplier Address"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSupplAddress" Text='<%# Eval("SupplAddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Suppl_Produce" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="Produce" Text="Produce"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Suppl_Produce" Text='<%# Eval("Produce") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlEdit" Text="Edit"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblEdit" ImageUrl="~/Images/Edit.gif" CommandName="EDIT"
                                                ToolTip="Edit Record" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                            <uc3:UCGridFooter id="ucGridFooter" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
