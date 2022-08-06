<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Training.AddProduct" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="smApplication"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="upPath" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div id="linkPath">
                        <asp:Label runat="server" ID="lblPath" Text="Training\AddProduct" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div id="toolbar">
                        <span>
                            <label id="pageTitle">List of Product</label>
                        </span>
                        <span id="toolMenuContainer">
                            <asp:LinkButton runat="server" ID="lb_Toolbar_Add" CssClass="lbMenu" Text="Add" CausesValidation="true"
                                OnClick="lb_Toolbar_Add_Click" />
                        </span>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
            <div id="Content">
                <uc1:ucsubsectioncontainer id="ucSubSectionAddProduct" toggleid="minAddProduct" affectedid="dAddProduct"
                    subsectiontitle="Add Product" runat="server" />
                <div id="dAddProduct">
                    <asp:UpdatePanel runat="server" ID="upForm" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td style="width: 50%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_Prod_ProdCode" Text="Product Code" />
                                    </td>
                                    <td style="width: 50%" class="tdValue">
                                        <asp:TextBox runat="server" ID="txtProdCode" MaxLength="20" CssClass="txtMedInputStyle" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_Prod_ProdName" Text="Product Name" />
                                    </td>
                                    <td style="width: 50%" class="tdValue">
                                        <asp:TextBox runat="server" ID="txtProdName" MaxLength="100" CssClass="txtMedInputStyle" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" class="tdDesc">
                                        <asp:Literal runat="server" ID="ltl_Prod_Price" Text="Price" />
                                    </td>
                                    <td style="width: 50%" class="tdValue">
                                        <asp:TextBox runat="server" ID="txtPrice" MaxLength="20" CssClass="txtMedInputStyle" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br />
            <br />
            <%--Grid dengan checkbox--%>
            <asp:UpdatePanel runat="server" ID="upProductTampil" UpdateMode="Conditional" Visible="true">
                <ContentTemplate>
                    
                    <div id="Div1">
                        <uc1:ucsubsectioncontainer id="ucSubSectionListofProduct" toggleid="minListofProduct" affectedid="dListofProduct"
                            subsectiontitle="List of Product" runat="server" />
                        <div id="dListofProduct">
                            <asp:GridView runat="server" ID="gvProduct" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvProduct_RowCommand">
                                
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="cbAll" CssClass="gridHeaderTitle" CommandName="checkAll"
                                                OnCheckedChanged="cbAll_CheckedChanged" AutoPostBack="true" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="cbCheck" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlProdCode" Text="Product Code"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblProdCode" Text='<%# Eval("ProdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlProdName" Text="Product Name"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblProdName" Text='<%# Eval("ProdName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlPrice" Text="Product Price"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPrice" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlEdit" Text="Edit"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblEdit" ImageUrl="~/Images/Edit.gif" CommandName="ED"
                                                ToolTip="Edit Record" CausesValidation="false"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
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
                        </div>
                    </div>
                        
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <div id="dAddToTemp" runat="server" align="right">
                <asp:LinkButton runat="server" ID="lbAddToTemp" Text="Add To Temp" CssClass="button" OnClick="lbAddToTemp_Click"
                    CauseValidation="false"></asp:LinkButton>
            </div>
            <br />
            <br />
            <%--Grid Tanpa CheckBox--%>
            <asp:UpdatePanel runat="server" ID="upFormTemp" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="Div2">
                        <asp:GridView runat="server" ID="gvProdTemp" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvProdTemp_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlProdCodeTemp" Text="Product Code"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProdCodeTemp" Text='<%# Eval("ProductCode") %>'></asp:Label>
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
                                        <asp:Literal runat="server" ID="ltlPriceTemp" Text="Price"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProdPriceTemp" Text='<%# Eval("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
