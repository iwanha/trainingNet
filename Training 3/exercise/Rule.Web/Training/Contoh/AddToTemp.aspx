<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToTemp.aspx.cs" Inherits="Training.Contoh.AddToTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gridview</title>
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
                <asp:UpdatePanel runat="server" ID="upForm" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="dGridView">
                            <asp:GridView runat="server" ID="gvCustomer" AutoGenerateColumns="false" GridLines="None" 
                                CssClass="mGrid" AlternatingRowStyle-CssClass="Alt">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="cbAll" CssClass="gridHeaderTitle" CommandName="checkAll"
                                                OnCheckedChanged="cbCheck_change" AutoPostBack="true" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="cbCheck" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlCustName" Text="Customer Name"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCustName" Text='<%# Eval("Nama") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlJaKel" Text="Jenis Kelamin"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblJenisKelamin" Text='<%# Eval("JenisKelamin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlTanggalLahir" Text="Tanggal Lahir"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTanggalLahir" Text='<%# Eval("TanggalLahir") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlTempatLahir" Text="Tempat Lahir"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTempatLahir" Text='<%# Eval("TempatLahir") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlAlamat" Text="Alamat"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAlamat" Text='<%# Eval("Alamat") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <div id="dAddToTemp" runat="server" align="right">
                    <asp:LinkButton runat="server" ID="lblAddToTemp" Text="Add To Temp" CssClass="button" OnClick="lbAddToTemp_Click"
                        CausesValidation="false"></asp:LinkButton>
                </div>
                <br />
                <br />

                 <asp:UpdatePanel runat="server" ID="upFormTemp" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="Div1">
                            <asp:GridView runat="server" ID="gvCustTemp" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvCustTemp_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlCustNameTemp" Text="Customer Name"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCustNameTemp" Text='<%# Eval("Nama") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlJaKelTemp" Text="Jenis Kelamin"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblJenisKelaminTemp" Text='<%# Eval("JenisKelamin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlTanggalLahirTemp" Text="Tanggal Lahir"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTanggalLahirTemp" Text='<%# Eval("TanggalLahir") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlTempatLahirTemp" Text="Tempat Lahir"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTempatLahirTemp" Text='<%# Eval("TempatLahir") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlAlamatTemp" Text="Alamat"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAlamatTemp" Text='<%# Eval("Alamat") %>'></asp:Label>
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

            </div>
    </form>
</body>
</html>
