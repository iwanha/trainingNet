﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCReference.ascx.cs"
    Inherits="Rule.Web.WebUserControl.UCReference" %>
<asp:DropDownList runat="server" ID="ddlReference" OnSelectedIndexChanged="ddlReference_SelectedIndexChanged">
</asp:DropDownList>
<span class="mandatoryStyle">
    <asp:Literal ID="ltl_Form_Req_ddlReference" runat="server" Text="*" Visible="false" />
</span>
<asp:RequiredFieldValidator runat="server" ID="rfvDdlReference" Display="Dynamic" ForeColor="Red"
    ControlToValidate="ddlReference" Text="This field is required" InitialValue=""></asp:RequiredFieldValidator>

<asp:Literal runat="server" ID="ltlReference" Visible="false"></asp:Literal>
<asp:Literal runat="server" ID="ltlReferenceVal" Visible="false"></asp:Literal>

<%--<asp:HiddenField runat="server" ID="hdnReference" />--%>
