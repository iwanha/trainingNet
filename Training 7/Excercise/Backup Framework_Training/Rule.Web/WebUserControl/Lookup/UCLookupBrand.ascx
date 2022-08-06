<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLookupBrand.ascx.cs" Inherits="Rule.Web.WebUserControl.Lookup.UCLookupBrand" %>
<%@ Register Src="~/WebUserControl/GenericLookup/LookupBase.ascx" TagName="LookupBase" TagPrefix="uc1" %>

<uc1:LookupBase ID="uclLookupBrand" runat="server" MapperName="uclLookupBrand" QueryServiceName="QueryPagingLookupBrand" LookupTitle="Brand Lookup" />
