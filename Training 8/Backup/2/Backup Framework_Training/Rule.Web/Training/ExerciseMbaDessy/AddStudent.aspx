<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Training.ExerciseMbaDessy.AddStudent" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>
<%@ Register Src="~/WebUserControl/Lookup/UCLookupMajor.ascx" TagName="UCLookUpMajor" TagPrefix="uc2" %>
<%@ Register Src="~/WebUserControl/UCDatePicker.ascx" TagName="UCDatePicker" TagPrefix="uc3" %>
<%@ Register Src="~/WebUserControl/UCInputNumber.ascx" TagName="UCInputNumber" TagPrefix="uc4" %>
<%@ Register Src="~/WebUserControl/UCReference.ascx" TagName="UCReference" TagPrefix="uc5" %>



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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Training7/AddStudent"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">Add Student</label>
                    </span>
                    <span id="toolMenuContainer">
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Save" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Save_Click" Text="Save"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lb_Toolbar_Cancel" CssClass="lbMenu" CausesValidation="true"
                            OnClick="lb_Toolbar_Cancel_Click" Text="Cancel"></asp:LinkButton>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <uc1:ucsubsectioncontainer id="ucSubSectionAddStudent" toggleid="minAddEditStudent" affectedid="dAddEditStudent"
                subsectiontitle="Student Info" runat="server" />
            <div id="dAddEditStudent">
                <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Student_StudentNo" Text="Student No"></asp:Literal>
                                    <asp:Literal runat="server" ID="ltl_Student_StudentId" Visible="false"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtStudentNo" CssClass="txtMedInputStyle"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtStudentId" Visible="false"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Student_StudentName" Text="Student Name"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtStudentName" CssClass="txtMedInputStyle"></asp:TextBox>
                                    <label class="mandatoryStle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ControlToValidate="txtStudentName"
                                        ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Student_Address" Text="Address"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtAddress" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                                    <label class="mandatoryStle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                        ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Student_BirthPlace" Text="Birth Place"></asp:Literal>
                                    /
                                    <asp:Literal runat="server" ID="ltl_Student_BirthDt" Text="Birth Date"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtBirthPlace" CssClass="txtMedInputStyle"></asp:TextBox>
                                    <label class="mandatoryStle">*</label>
                                    <asp:RequiredFieldValidator ID="rfvBirthPlace" runat="server" ControlToValidate="txtBirthPlace"
                                        ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                                    /
                                    <uc3:UCDatePicker runat="server" id="ucBirthDt" />
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Student_Major" Text="Major"></asp:Literal>
                                    <asp:Literal runat="server" ID="ltl_Student_MajorId" Visible="false"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:TextBox runat="server" ID="txtMajor" CssClass="txtMedInputStyle" Visible="false"></asp:TextBox>
                                    <label class="mandatoryStle">*</label>
                                    <uc2:UCLookUpMajor runat="server" id="ucLookup" />
                                    <asp:RequiredFieldValidator ID="rfvMajor" runat="server" ControlToValidate="txtMajor"
                                        ErrorMessage="Please fill this field" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <%--                            MENUJU INVISIBLE GRID DAN MELAMPAUINYA !!!!!--%>
                            <asp:TextBox runat="server" ID="txtCourseCode" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtCourse" Visible="false"></asp:TextBox>
                            <uc5:UCReference runat="server" id="ucCourseCode" Visible="false" />
                            <uc5:UCReference runat="server" id="ucCourse" Visible="false"/>
                            <asp:TextBox runat="server" ID="txtRefMajorId" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtScore" Visible="false"></asp:TextBox>
                            


                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <%--<uc1:ucsubsectioncontainer id="ucSubSectionScore" toogleid="minViewScore" affectedid="dViewScore"
                    subsectiontitle="Score Info" runat="server" />
                <br />
                <br />--%>
                <%--<asp:UpdatePanel runat="server" ID="upStudent" UpdateMode="Conditional" Visible="false">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="gvScore" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvScore_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlCourseCode" Text="Course Code"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCourseCode" Text='<%# Eval("CourseCode") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlCourseName" Text="Course"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCourseName" Text='<%# Eval("CourseName") %>'></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCourseName" Enabled="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltlStudentScore" Text="Score"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblStudentScore" Text='<%# Eval("StudentScore") %>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>

                <%--<div id="dAddToTemp" runat="server" align="center">
                    <asp:LinkButton runat="server" ID="lblAddToTemp" Text="Add" CssClass="button" OnClick="lblAddToTemp_Click"
                        CausesValidation="false"></asp:LinkButton>
                </div>
                <br />
                <br />

                <asp:UpdatePanel runat="server" ID="upFormTemp" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="Div1">
                            <asp:GridView runat="server" ID="gvScoreTemp" AutoGenerateColumns="false" GridLines="None" CssClass="mGrid"
                                AlternatingRowStyle-CssClass="Alt" OnRowCommand="gvScoreTemp_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlCourseCodeTemp" Text="Course Code"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCourseCodeTemp" Text='<%# Eval("CourseCode") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlCourseNameTemp" Text="Course"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCourseNameTemp" Text='<%# Eval("CourseName") %>'></asp:Label>
                                            <asp:TextBox runat="server" ID="txtCourseNameTemp" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Literal runat="server" ID="ltlScoreTemp" Text="Score"></asp:Literal>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblScoreTemp" Text='<%# Eval("Score") %>'></asp:Label>
                                            <uc4:UCInputNumber runat="server" id="ucInputScore" />
                                            <asp:TextBox runat="server" ID="txtScoreTemp" Enabled="false"></asp:TextBox>
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
                </asp:UpdatePanel>--%>
            </div>
            <br />
            <br />
            <br />
            <asp:LinkButton runat="server" ID="lbAdd" OnClick="lbAdd_Click" Text="Add" CssClass="button" CausesValidation="true" align="center"></asp:LinkButton>
            <br />
            <br />
            <br />
            <asp:UpdatePanel runat="server" ID="upRepeater" UpdateMode="Conditional">
                <ContentTemplate>
                    <uc1:ucsubsectioncontainer id="ucSubSectionRepeater" toggleid="minRepeater" affectedid="dRepeater"
                        subsectiontitle="Score Info" runat="server" />
                    <div id="dRepeater">
                        <asp:Repeater ID="rptName" runat="server">
                            <ItemTemplate>
                                <table class="formTable">
                                    <tr>
                                        <td width="20%" class="tdDesc">
                                            <asp:Literal ID="ltlCourseCode" runat="server" Text="CourseCode"></asp:Literal>
                                        </td>
                                        <td width="80%" class="tdValue">
                                            <asp:Label runat="server" ID="lblCourseCode" Text='<%# Eval("CourseCode") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRefCourseId" Visible="false" Text='<%# Eval("RefCourseId") %>'></asp:Label>
                                            

                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="tdDesc">
                                            <asp:Literal ID="ltlCourseName" runat="server" Text="Score"></asp:Literal>
                                        </td>
                                        <td width="80%" class="tdValue">
                                            <asp:Label runat="server" ID="lblCourseName" Text='<%# Eval("CourseName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="20%" class="tdDesc">
                                            <asp:Literal ID="ltlScore" runat="server" Text="Score"></asp:Literal>
                                        </td>
                                        <td width="80%" class="tdValue">
                                            <asp:Label runat="server" ID="lblScore" Text='<%# Eval("Score") %>'></asp:Label>
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
                                        <asp:Literal runat="server" ID="ltl_GridCourseCode" Text="Course Code"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <asp:Label runat="server" ID="lblGridCourseCode" Text='<%# Eval("CourseCode") %>'></asp:Label>
                                        <%--<uc5:UCReference runat="server" id="ucCourseCode" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltl_GridCourseName" Text="Course Name"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGridCourseName" Text='<%# Eval("CourseName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Literal runat="server" ID="ltl_GridScore" Text="Score"></asp:Literal>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGridScore" Text='<%# Eval("Score") %>'></asp:Label>
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
        </div>
    </form>
</body>
</html>
