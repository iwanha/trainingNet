<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="GvValidationX.aspx.cs" Inherits="Training.Contoh.GvValidationX" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Form Handling</title>
</head>
<body>
    <form id="dPath" runat="server">
        <asp:ScriptManager runat="server" ID="smApplication"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upPath" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Label runat="server" ID="lblPath" Text="Training/Day3/Ujian"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Ujian</label>
                    </span>
                    <span id="toolenuConteiner"></span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--        --------------------------------------------------BRANCH SECTION (REPEATER)---------------------------------------------------%>
        <div>

            <%--<table class="formTable--%>">--%>


                <%--BRANCH CODE--%>
                <%--<tr>
                                            <td width="20%" class="tdDesc">
                                                <asp:Literal ID="ltlBranchCode" runat="server" Text="Branch Code"></asp:Literal>
                                            </td>
                                            <td width="80%" class="tdValue">
                                                <asp:Label runat="server" ID="lblBranchCode" Visible="false"></asp:Label>
                                                    <asp:Label runat="server" ID="lblBranchCode" Text="txtBranchCode" ></asp:Label>
                                            </td>
                                            
                                      </tr>--%>
                <%--BRANCH PHONE--%>
                <tr>
                    <td width="20%" class="tdDesc">
                        <asp:Literal ID="ltlBranchPhone" runat="server" Text="Branch Phone"></asp:Literal>
                    </td>
                    <td width="80%" class="tdValue">
                        <asp:TextBox ID="txtBranchPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvrBranchPhone" runat="server" ControlToValidate="txtBranchPhone"
                            ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>


                <%--BRANCH EMAIL--%>

                <tr>
                    <td width="20%" class="tdDesc">
                        <asp:Literal ID="ltlBrachEmail" runat="server" Text="Brach Email"></asp:Literal>
                    </td>
                    <td width="80%" class="tdValue">
                        <asp:TextBox ID="txtBrachEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrachEmail"
                            ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ErrorMessage="Format Email Salah"
                            ControlToValidate="txtBrachEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            </ItemTemplate>
                        </asp:Repeater>
        </div>
        </contenttemplate>
            </asp:UpdatePanel>
        </div>

        <%----------------------------------------------------EMPLOYEE SECTION (GRID VIEW)---------------------------------------------------%>

        <uc1:ucsubsectioncontainer id="ucSubSectionUser" toggleid="minUser" affectedid="dUser"
            subsectiontitle="Employee" runat="server" />
        <div id="dUser">
            <asp:UpdatePanel runat="server" ID="upAddUser" UpdateMode="Conditional">
                <ContentTemplate>
                    <table class="formTable">

                        <%--EMPLOYE NAME (GRIDVIEW)--%>

                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlEmployeeName" runat="server" Text="Employee Name"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>

                            </td>
                        </tr>

                        <%--GENDER (GRID VIEW)--%>

                        <tr>
                            <td class="tdDesc" width="20%">
                                <asp:Literal ID="ltlGender" runat="server">Gender</asp:Literal></td>
                            <td class="tdValue" width="80%">
                                <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList></td>
                        </tr>

                        <%--KTP No.--%>


                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlKtpNo" runat="server" Text="KTP No."></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtKtpNo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvKtpNo" runat="server" ControlToValidate="txtKtpNo"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvKtpNo" runat="server" ControlToValidate="txtKtpNo" MinimumValue="20" MaximumValue="50" ErrorMessage="Minimum 20 kata!" ForeColor="Red"> </asp:RangeValidator>
                            </td>
                        </tr>

                        <%--ALAMAT--%>

                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="LtlAlamat" runat="server" Text="Employee Address"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtAlamat" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAlamat" runat="server" ControlToValidate="txtAlamat"
                                    ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <%--EMAIL--%>

                        <tr>
                            <td width="20%" class="tdDesc">
                                <asp:Literal ID="ltlEmail" runat="server" Text="Email"></asp:Literal>
                            </td>
                            <td width="80%" class="tdValue">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ID="revEmail" ErrorMessage="Format Email Salah"
                                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td>
                        </tr>

                    </table>
                    <asp:Label runat="server" ID="lblErrorMsg" Text="Username already exists" Visible="false" ForeColor="Red" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />

        <asp:LinkButton runat="server" ID="lbAdd" OnClick="lbAdd_Click" Text="Add" CssClass="button" CausesValidation="true"></asp:LinkButton>

        <br />
        <br />

        <asp:UpdatePanel runat="server" ID="upUserTampil" UpdateMode="Conditional" Visible="true">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvUser" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                    AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvUser_RowCommand">
                    <Columns>

                        <%--EMPLOYEE NAME GRID VIEW--%>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="ltlEmployeeName" Text="Employee Name"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmployeeName" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <%--GENDER GRID VIEW--%>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="ltlGender" Text="Gender"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblGender" Text='<%# Eval("Gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--KTP No. GRID VIEW--%>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="ltlKtpNo" Text="KTP No."></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblKtpNo" Text='<%# Eval("KtpNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--ALAMAT GRID VIEW--%>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal runat="server" ID="ltlAlamat" Text="Employee Address"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAlamat" Text='<%# Eval("Alamat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--EMAIL GRID VIEW--%>

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

        <%--<asp:UpdatePanel runat="server" ID="upPath" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Label runat="server" ID="lblPath" Text="Training/Day3/Ujian"></asp:Label>
                    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Branch</label>
                    </span>
                    <span id="toolenuContainer">

                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%--<div id="content">
            <div id="dUser">
                <asp:UpdatePanel runat="server" ID="upAddUser" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal ID="ltlBranchCode" runat="server" Text"BranchCode"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox ID="txtBranchCode" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvBranchCode" runat="server" ControlToValidate="txtBranchCode"
                                        ErrorMessage="Wajib Di Isi" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>

                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </form>
</body>
</html>
