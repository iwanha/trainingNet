<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLookupProduce.ascx.cs" Inherits="Rule.Web.WebUserControl.Lookup.UCLookupProduce" %>
<%@ Register Src="~/WebUserControl/GenericLookup/LookupBase.ascx" TagName="LookupBase" TagPrefix="uc1" %>

<uc1:LookupBase ID="uclLookupProduce" runat="server" MapperName="Produce" QueryServiceName="QueryPagingLookupProduce" LookupTitle="Produce" />