<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomerHist.aspx.cs" Inherits="Training.Exercise.ViewCustomerHist" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<%@ Register Src="~/WebUserControl/UCDatePicker.ascx" TagName="UCDatePicker" TagPrefix="uc2" %>


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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Exercise/ViewCustomerHist"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">View Customer Transaction History</label>
                    </span>
                    <span id="toolMenuContainer">

                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <uc1:ucsubsectioncontainer id="ucSubSectionAViewSupplier" toogleid="minViewSuppler" affectedid="dViewSupplier"
                subsectiontitle="View Customer" runat="server" />
            <div id="dViewSupplier">
                <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustNo" Text="Customer No"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCustNo"></asp:Label>
                                    <asp:label runat="server" Visible="false" ID="lblCustId" Text='<%# Eval("CustId") %>'>test</asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustName" Text="Customer Name"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCustName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustType" Text="Customer Type"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCustType"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Address" Text="Customer Address"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Rt" Text="Rt/Rw"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblRt"></asp:Label>
                                    
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Kelurahan" Text="Kelurahan"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblKelurahan"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Kecamatan" Text="Kecamatan"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblKecamatan"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_City" Text="City"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCity"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Zipcode" Text="Zipcode"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblZipcode"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtTranNo" Visible="false" />
                                    <asp:TextBox runat="server" ID="txtTranDt" Visible="false" />
                                    <asp:TextBox runat="server" ID="txtProductName" Visible="false" />
                                    <asp:TextBox runat="server" ID="txtQuantity" Visible="false" />
                                    <asp:TextBox runat="server" ID="txtPrice" Visible="false" />
                                    <asp:TextBox runat="server" ID="txtSubTotal" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                    <uc1:ucsubsectioncontainer id="Ucsubsectioncontainer1" toogleid="minViewCustomer" affectedid="dViewCustomer"
                subsectiontitle="Transaction History" runat="server" />
                
                <asp:UpdatePanel runat="server" ID="upFormTemp" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="Div1">
                            <asp:GridView runat="server" ID="gvCustHistTemp" AutoGenerateColumns="true" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvCustHistTemp_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlTranNoTemp" Text="Transaction No"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTranNoTemp" Text='<%# Eval("TranNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlTranDtTemp" Text="Transaction Date"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTranDtTemp" Text='<%# Eval("TranDt") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlProdNameTemp" Text="Product Name"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblProdNameTemp" Text='<%# Eval("ProductName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlQtyTemp" Text="Quantity"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblQtyTemp" Text='<%# Eval("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlPriceTemp" Text="Price"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPriceTemp" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlSubTotalTemp" Text="Sub Total"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSubTotalTemp" Text='<%# Eval("SubTotal") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                                ToolTip="Delete Record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </form>
</body>
</html>
