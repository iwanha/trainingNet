<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagingSearch.aspx.cs" Inherits="Training.Training6.PagingSearch" %>

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
    <asp:ScriptManager ID="smApplication" runat="server" />
        <asp:UpdatePanel ID="upPath" UpdateMode="Conditional" runat="server" >
            <ContentTemplate>
                <div id="linkPath" >
                    <asp:Literal ID="ltl_Path" Text="Training/Training6/Search Paging" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="toolbar" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="toolbar">
                    <span id="pageTitle" >
                        <asp:Literal ID="ltl_PageTitle" Text="Customer Handling Search Paging" runat="server" />
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton ID="lb_Toolbar_Add" CssClass="lbMenu" CausesValidation="false"
                            OnCLick="lb_Toolbar_Add_Click" Text="Add" runat="server" />
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel ID="upSearch" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <div class="form" id="dSearchSection" runat="server">
                        <uc2:UcSearch id="ucSearch" title="Customer Handling Search Paging" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upGrid" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <div class="form" id="dGridSection" visible="false" runat="server" >
                        <uc1:ucsubsectioncontainer id="ucSubSectionSearch" toogleid="minSearch" affectedid="dGrid"
                            subsectiontitle="List of Product" runat="server" />
                        <div id="dGrid">
                            <uc4:UcGridHeader id="ucGridHeader" runat="server" />
                            <asp:GridView ID="gvCustomerHandling" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvCustomerHandling_RowCommand" OnRowDataBound="gvCustomerHandling_RowDataBound" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_CustomerHandling_RegistrationNo" CommandName="Sort" CommandArgument="RegistrationNo" CssClass="gridHeaderTitle" Text="Registration No" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CustomerHandling_RegistrationNo" Text='<%# Eval("RegistrationNo") %>' runat="server" readonly/>
                                            <asp:Label ID="lbl_CustomerHandling_CustomerHandlingId" Text='<%# Eval("CustomerHandlingId") %>' runat="server" visible="false"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_CustomerHandling_CustomerName" CommandName="Sort" CommandArgument="CustomerName" CssClass="gridHeaderTitle" Text="Customer Name" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CustomerHandling_CustomerName" Text='<%# Eval("CustomerName") %>' runat="server"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_CustomerHandling_ServiceCategory" CommandName="Sort" CommandArgument="ServiceCategory" CssClass="gridHeaderTitle" Text="Service Category" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CustomerHandling_ServiceCategory" Text='<%# Eval("ServiceCategory") %>' runat="server"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_CustomerHandling_AdminFee" CommandName="Sort" CommandArgument="AdminFee" CssClass="gridHeaderTitle" Text="Admin Fee Amount" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CustomerHandling_AdminFee" Text='<%# Eval("AdminFee") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_CustomerHandling_CompletionDt" CommandName="Sort" CommandArgument="CompletionDt" CssClass="gridHeaderTitle" Text="Completion Date" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CustomerHandling_CompletionDt" Text='<%# Eval("CompletionDt") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal ID="ltlEdit" Text="Edit" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imEdit" CommandName="EDIT" ToolTip="Edit" CausesValidation="false" ImageUrl="~/images/Edit.gif" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <uc3:UcGridFooter id="ucGridFooter" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
