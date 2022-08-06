<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgreementPaging.aspx.cs" Inherits="Training.EXAM.AgreementPaging" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<%@ Register Src="~/WebUserControl/Search/UCSearch.ascx" TagName="UcSearch" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCGridFooter.ascx" TagName="UcGridFooter" TagPrefix="uc3" %>
<%@ Register Src="~/WebUserControl/UCGridHeader.ascx" TagName="UcGridHeader" TagPrefix="uc4" %>
<%--<%@ Register Src="~/WebUserControl/UCReference.ascx" TagName="UCReference" TagPrefix="uc5"  %>--%>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smApplication" runat="server" />
        <asp:UpdatePanel ID="upPath" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Label ID="lblPath" Text="Training/EXAM/AgreementPaging" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upToolbar" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label runat="server" id="pageTitle">AgreementPaging</label>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel runat="server" ID="upSearch" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form" id="dSearchSection" runat="server">
                        <uc2:ucSearch id="ucSearch" runat="server" title="Agreement" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional">
                <ContentTemplate>
                    <div runat="server" class="form" id="dGridSection" visible="false">
                        <div id="dGridAgreementPaging">
                            <uc4:UCGridHeader id="ucGridHeader" runat="server" />
                            <asp:GridView runat="server" ID="gvAgreementPaging" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid" AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvAgreementPaging_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_AppNo" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="AppNo" Text="Application No"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbAppNo" Text='<%# Eval("AppNo") %>' CausesValidation="false" CommandName="ViewAgreement"></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_AgrmntNo" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="AgrmntNo" Text="Agreement No"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_AgrmntNo" Text='<%# Eval("AgrmntNo") %>'></asp:Label>
                                            <asp:Label runat="server" Visible="false" ID="lblAgrmntId" Text='<%# Eval("AgrmntId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_CustomerName" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="CustomerName" Text="Name"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_CustomerName" Text='<%# Eval("CustomerName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_Address" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="Address" Text="Address"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_Address" Text='<%# Eval("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_AppStep" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="AppStep" Text="Step"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_AppStep" Text='<%# Eval("AppStep") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_ContractStat" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="ContractStat" Text="Status"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_ContractStat" Text='<%# Eval("ContractStat") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_InstAmt" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="InstAmt" Text="Installment"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_InstAmt" Text='<%# Eval("InstAmt") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_CurrencyName" CSS="gridHeaderTitle" CommandName="Sort" CommandArgument="CurrencyName" Text="Currency"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl_Paging_CurrencyName" Text='<%# Eval("CurrencyName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Paging_Receive" CSS="gridHeaderTitle" CommandArgument="Receive" Text="Action"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbReceive" Text="Receive" CausesValidation="false" CommandName="ViewPdcReceive"></asp:LinkButton>

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
