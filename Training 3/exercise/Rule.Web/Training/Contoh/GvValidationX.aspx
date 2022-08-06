<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GvValidationX.aspx.cs" Inherits="Training.Contoh.GvValidationX" %>
<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Form Handling</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="smApplication"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="upPath" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="linkPath">
                        <asp:Label runat="server" ID="lblPath" Text="Training/Day3/Gridview"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="toolbar">
                        <span>
                            <label id="pageTitle">GridView</label>
                        </span>
                        <span id="toolenuConteiner">

                        </span>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="content">
                <uc1:ucsubsectioncontainer id="ucSubSectionUser" toggleid="minUser" affectedid="dUser"
                    subsectiontitle = "Add User" runat = "server" />
                <div id="dUser">
                    <asp:UpdatePanel runat="server" ID="upAddUser" UpdateMode="Conditional">
                    <ContentTemplate>
                    <table class="formTable">
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlUsername" runat="server" Text="User Name"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlUmur" runat="server" Text="Umur"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtUmur" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUmur" runat="server" ControlToValidate="txtUmur"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlTinggiBadan" runat="server" Text="Tinggi Badan"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtTinggiBadan" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTinggiBadan" runat="server" ControlToValidate="txtTinggiBadan"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" ID="cvTinggiBadan" ErrorMessage="Harus berisikan angka"
                                    ControlToValidate="txtTinggiBadan" Type="Integer" Operator="DataTypeCheck" ForeColor="Red"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlEmail" runat="server" Text="Email"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="lblErrorMsg" Text="Username already exists" Visible ="false" ForeColor="Red" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
                <br />
                <br />
                
                <asp:LinkButton runat="server" ID="lbAdd" OnClick="lbAdd_Click" Text="Add To Data Table" CssClass="button" CausesValidation="true"></asp:LinkButton>
       
                <br />
                <br />

                <asp:UpdatePanel runat="server" ID="upUserTampil" UpdateMode="Conditional" Visible="true">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="gvUser" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvUser_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlUserName" Text="User Name"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUserName" Text='<%# Eval("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlUmur" Text="Umur"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUmur" Text='<%# Eval("Umur") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlTinggiBadan" Text="Tinggi Badan"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTinggiBadan" Text='<%# Eval("TinggiBadan") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlEmail" Text="Email"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEmail" Text='<%# Eval("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlEdit" Text="Edit"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblEdit" ImageUrl="~/Images/Edit.gif" CommandName="ED"
                                                ToolTip="Edit Record" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>