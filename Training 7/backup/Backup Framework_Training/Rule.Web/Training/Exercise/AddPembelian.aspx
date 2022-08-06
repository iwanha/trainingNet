<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPembelian.aspx.cs" Inherits="Training.excercise.AddPembelian" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<%@ Register Src="~/WebUserControl/Lookup/UCLookupBrand.ascx" TagName="UCLookUpBrand" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCDatePicker.ascx" TagName="UCDatePicker" TagPrefix="uc3" %>


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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Day9/AddPembelian"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Add Pembelian</label>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Submit" CssClass="lbMenu" CausesValidation="true" OnClick="lb_Toolbar_Submit_Click" Text="Submit"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Cancel" CssClass="lbMenu" CausesValidation="false" OnClick="lb_Toolbar_Cancel_Click" Text="Cancel"></asp:LinkButton>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <uc1:ucsubsectioncontainer id="ucSubSectionAddPembelian" toggleid="minAddEditPembelian" affectedid="dAddEditPembelian"
            subsectiontitle="Add Pembelian" runat="server" />
        <div id="dAddEditPembelian">
            <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <table class="formTable">
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal runat="server" ID="ltl_Pembelian_ProdTrxNo" Text="Transaction No"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox runat="server" ID="txtProdTrxNo" CssClass="txtMedInputStyle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvProdTrxNo" runat="server" ControlToValidate="txtProdTrxNo" ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal runat="server" ID="ltl_Pembelian_ProdTrxDt" Text="Transaction Date"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <uc3:UCDatePicker runat="server" id="ucTranDt" />
                                <asp:TextBox runat="server" ID="txtProdTrxDt" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal runat="server" ID="ltl_Pembelian_ProductHId" Text="Product"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <uc2:UCLookUpBrand runat="server" id="ucBrand" />
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal runat="server" ID="ltl_Pembelian_Qty" Text="Quantity"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox runat="server" ID="txtQty" CssClass="txtMedInputStyle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQty" runat="server" ControlToValidate="txtQty" ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        
                        
                            <td>
                                <asp:TextBox runat="server" ID="txtProductH" Visible="false"></asp:TextBox>
                                
                            </td>
                        
                            
                            <td>
                                <asp:TextBox runat="server" ID="txtProductD" Visible="false"></asp:TextBox>
                                </td>
                        
                            
                            <td>
                                <asp:TextBox runat="server" ID="txtProdTrxD" Visible="false"></asp:TextBox>
                                </td>
                       
                            
                            <td>
                                <asp:TextBox runat="server" ID="txtTotal" Visible="false"></asp:TextBox>
                                </td>
                       
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <uc1:ucsubsectioncontainer id="ucSubSectionProduct" toogleid="minViewProduct" affectedid="dViewProduct"
                subsectiontitle="List of Product" runat="server" />
        </div>
        <br />
        <br />
        <div id="dAddToTemp" runat="server" align="right">
            <asp:LinkButton runat="server" ID="lblAddToTemp" Text="Add To Temp" CssClass="button" OnClick="lblAddToTemp_Click"
                CausesValidation="false"></asp:LinkButton>
        </div>
        <br />
        <br />

        <asp:UpdatePanel runat="server" ID="upFormTemp" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="Div1">
                    <asp:GridView runat="server" ID="gvProductTemp" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                        AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvProductTemp_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Literal runat="server" ID="ltlProductHTemp" Text="Product Name"></asp:Literal>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblProductHTemp" Text='<%# Eval("ProductName") %>'></asp:Label>
                                    <asp:TextBox runat="server" Visible="false" ID="txtProductH"></asp:TextBox>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:Literal runat="server" ID="ltlProductDTemp" Text="Price"></asp:Literal>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    
                                    <asp:Label runat="server" ID="lblProductDTemp" Text='<%# Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:Literal runat="server" ID="ltlProdTrxDTemp" Text="Quantity"></asp:Literal>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Visible="false" ID="txtProdTrxD"></asp:TextBox>
                                    
                                    <asp:Label runat="server" ID="lblProdTrxDTemp" Text='<%# Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:Literal runat="server" ID="ltlTotalTemp" Text="Total"></asp:Literal>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Visible="false" ID="txtTotal"></asp:TextBox>
                                    
                                    <asp:Label runat="server" ID="lblTotalTemp" Text='<%# Eval("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                <HeaderTemplate>
                                    <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                        ToolTip="Delete Record" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
