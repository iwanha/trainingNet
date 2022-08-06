<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPaging.aspx.cs" Inherits="Training.ExerciseMbaDessy.StudentPaging" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UcSubSectionContainer" TagPrefix="uc1" %>>
<%@ Register Src="~/WebUserControl/Search/UCSearch.ascx" TagName="UcSearch" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCGridFooter.ascx" TagName="UcGridFooter" TagPrefix="uc3" %>
<%@ Register Src="~/WebUserControl/UCGridHeader.ascx" TagName="UcGridHeader" TagPrefix="uc4" %>
<%--<%@ Register Src="~/WebUserControl/UCReference.ascx" TagName="UCReference" TagPrefix="uc5" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smApplication" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upPath" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div id="linkPath">
                    <asp:Label runat="server" ID="lblPath" Text="Training/ExerciseBuDessy/StudentPagging"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Search</label>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Add" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Add_Click" Text="Add"></asp:LinkButton>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <asp:UpdatePanel runat="server" ID="upSearch" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form" id="dSearchSection" runat="server">
                        <uc2:UcSearch id="ucSearch" runat="server" title="List Supplier" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form" id="dGridSection" runat="server" visible="false">
                        
                        <div id="dGrid">
                            <uc4:UcGridHeader id="ucGridHeader" runat="server" />
                            <asp:GridView runat="server" ID="gvStudent" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvStudent_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Student_StudentNo" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="StudentNo" Text="Student No"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Student_StudentNo" Text='<%# Eval("StudentNo") %>' CausesValidation="false" CommandName="ViewSuppl"></asp:LinkButton>
                                            <asp:Label runat="server" Visible="false" ID="lblStudentId" Text='<%# Eval("StudentId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Student_StudentName" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="StudentName" Text="Student Name"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblStudentName" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Student_Faculty" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="Faculty" Text="Faculty"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblFaculty" Text='<%# Eval("Faculty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Student_Major" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="Major" Text="Major"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMajor" Text='<%# Eval("MajorName") %>'></asp:Label>
                                            <%--<uc5:UCReference runat="server" id="ucMajor" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton runat="server" ID="lb_Student_AverageScore" CSS="gridHeaderTitle"
                                                CommandName="Sort" CommandArgument="AverageScore" Text="AverageScore"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAverageScore" Text='<%# Eval("Score") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlEdit" Text="Edit"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblEdit" ImageUrl="~/Images/Edit.gif" CommandName="EDIT"
                                                ToolTip="Edit Record" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                                ToolTip="Delete Record" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlDelete" Text="Delete"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lblDelete" ImageUrl="~/Images/Delete.gif" CommandName="DEL"
                                                ToolTip="Delete Record" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
