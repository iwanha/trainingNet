<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustPaging.aspx.cs" Inherits="Training.CustPaging" %>

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
        <asp:ScriptManager ID="smapplication" runat="server" />
        <asp:UpdatePanel ID="upPath" UpdateMode="Conditional" runat="server" >
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Literal ID="ltl_Path" Text="Training/Customer Paging" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upToolbar" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="toolbar">
                    <span id="pageTitle">
                        <asp:Literal ID="ltl_PageTitle" Text="Customer Paging" runat="server" />
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton ID="lb_Toolbar_Add" CssClass="lbMenu" CausesValidation="false"
                            OnClick="lb_Toolbar_Add_Click" Text="Add" runat="server" />
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel ID="upSearch" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <div class="form" id="dSearchSection" runat="server">
                        <uc2:UcSearch id="ucSearch" title="Customer Paging" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="upGrid" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <div class="form" id="dGridSection" visible="false" runat="server" >
                        <uc1:ucsubsectioncontainer id="ucSubsectionSearch" toogleid="minSearch" affectedid="dGrid"
                            subsectiontitle="List of Customer" runat="server" />
                        <div id="dGrid">
                            <%--Refresh Grid/grid header--%>
                            <uc4:UcGridHeader id="ucGridHeader" runat="server" />
                            <%--cara updatenya pake onrowdatabound--%>
                            <asp:GridView ID="gvCust" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvCust_RowCommand" OnRowDataBound="gvCust_RowDataBound" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_Cust_CustNo" CommandName="Sort" CommandArgument="CustNo" CssClass="gridHeaderTitle" Text="Customer No" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cust_CustNo" Text='<%# Eval("CustNo") %>' />
                                           <asp:Label ID="lbl_Cust_CustId" Text='<%# Eval("CustId") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_Cust_CustName" CommandName="Sort" CommandArgument="CustName" CssClass="gridHeaderTitle" Text="Customer Name" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            <asp:Label ID="lbl_Cust_CustName" Text='<%# Eval("CustName") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_Cust_BirthDt" CommandName="Sort" CommandArgument="BirthDt" Text="Birth Date" CssClass="gridHeaderTitle" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cust_BirthDt" Text='<%# Eval("BirthDt") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_Cust_MaritalStatus" CommandName="Sort" CommandArgument="MaritalStat" CssClass="GridHeaderTitle" Text="Marital Status" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cust_MaritalStat" Text='<%# Eval("MaritalStat") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lb_Cust_MonthlyIncome" CommandName="Sort" CommandArgument="MonthlyIncome" CssClass="gridHeaderTitle" Text="Monthly Income" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cust_MonthlyIncome" Text='<%# Eval("MonthlyIncome") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal ID="ltlEdit" Text="Edit" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imbEdit" CommandName="EDIT" ToolTip="Edit" CausesValidation="false" ImageUrl="~/images/Edit.gif" runat="server" />
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
