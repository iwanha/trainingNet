<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLookupMajor.ascx.cs" Inherits="Rule.Web.WebUserControl.Lookup.UCLookupMajor" %>
<%@ Register Src="~/WebUserControl/GenericLookup/LookupBase.ascx" TagName="LookupBase" TagPrefix="uc1" %>
<uc1:LookupBase ID="uclLookupMajor" runat="server" MapperName="Major" QueryServiceName="QueryPagingLookupMajor" LookupTitle="Major" />