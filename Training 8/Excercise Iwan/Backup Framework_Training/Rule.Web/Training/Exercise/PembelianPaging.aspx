<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PembelianPaging.aspx.cs" Inherits="Training.excercise.PembelianPaging" %>

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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Training7/PembelianPaging"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Pembelian Paging</label>
                    </span>
                    <%--<span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Add" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Add_Click1" Text="Add"></asp:LinkButton>
                    </span>--%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel runat="server" ID="upSearch" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form" id="dSearchSection" runat="server">
                        <uc2:UcSearch id="ucSearch" runat="server" title="List of Customer" />

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
                            <asp:GridView runat="server" ID="gvPembelian" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvPembelian_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Cust_CustNo" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="CustNo" Text="Customer No"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Cust_CustNo" Text='<%# Eval("CustNo") %>' CausesValidation="false" CommandName="ViewPembelian"></asp:LinkButton>
                                            <asp:Label runat="server" Visible="false" ID="lblCustId" Text='<%# Eval("CustId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Cust_CustName" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="CustName" Text="Customer Name"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCustName" Text='<%# Eval("CustName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_CustAddr_Address" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="Address" Text="Customer Address"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAddress" Text='<%# Eval("Address") %>'></asp:Label>
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
                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                                ToolTip="Delete Record" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <uc3:UCGridFooter id="ucGridFooter" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
