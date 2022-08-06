<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterGvX.aspx.cs" Inherits="Training.Contoh.RepeaterGvX" %>

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
                        <asp:Label runat="server" ID="lblPath" Text="Training/Day3/Repeater"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="toolbar">
                        <span>
                            <label id="pageTitle">Repeater</label>
                        </span>
                        <span id="toolenuConteiner">

                        </span>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="content">
                  <div id="dUser">
                    <asp:UpdatePanel runat="server" ID="upAddUser" UpdateMode="Conditional">
                    <ContentTemplate>
                    <table class="formTable">
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlUsername" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlIDNo" runat="server" Text="Nomor NPWP/KTP"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtIDNo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvIdNo" runat="server" ControlToValidate="txtIDNo"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlCustType" runat="server" Text="Customer Type"></asp:Literal>
                            </td>
                            <td style="width: 50%">
                                <asp:DropDownList runat="server" ID="ddlCustType" ></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="lblErrorMsg" Text="NPWP or KTP already exists" Visible ="false" ForeColor="Red" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
                <br />
                <br />
                <br />
                <asp:LinkButton runat="server" ID="lbAdd" OnClick="lbAdd_Click" Text="Save" CssClass="button" CausesValidation="true"></asp:LinkButton>
                <br />
                <br />
                 <br />
                <asp:UpdatePanel runat="server" ID="upRepeater" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc1:ucsubsectioncontainer id="ucSubSectionRepeater" toggleid="minRepeater" affectedid="dRepeater"
                            subsectiontitle = "Repeater GridView" runat = "server" />
                        <div id="dRepeater">
                            <asp:Repeater ID="rptName" runat="server">
                                <ItemTemplate>
                                    <table class="formTable">
                                        <tr>
                                            <td width="20%" class="tdDesc">
                                                <asp:Literal ID="ltlCustName" runat="server" Text="Customer Name"></asp:Literal>
                                            </td>
                                            <td width="80%" class="tdValue">
                                                <asp:Label runat="server" ID="lblCustType" Visible="false" Text='<%# Eval("CustType") %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblName" Text='<%# Eval("Name") %>'></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td width="20%" class="tdDesc">
                                                <asp:Literal ID="ltlCustKTP" runat="server" Text="No KTP/NPWP"></asp:Literal>
                                            </td>
                                            <td width="80%" class="tdValue">
                                                <asp:Label runat="server" ID="lblIDNo" Text='<%# Eval("IDNo") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <br />
                        <br />
                        <div id="dGrid">
                        <asp:GridView runat="server" ID="gvGrid" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="Alt" OnRowDataBound="gvGrid_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltl_GridCustType" Text="Customer Type"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGridCustType" Text='<%# Eval("CustType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltl_GridCustName" Text="Customer Name"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGridCustName" Text='<%# Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltl_GridCustIDNo" Text="Customer ID No"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGridCustIDNo" Text='<%# Eval("IDNo") %>'></asp:Label>
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
