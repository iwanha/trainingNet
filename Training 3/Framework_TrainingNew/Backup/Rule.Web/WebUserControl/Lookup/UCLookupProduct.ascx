<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLookupProduct.ascx.cs"
    Inherits="Rule.Web.WebUserControl.Lookup.UCLookupProduct" %>
<%@ Register Src="~/WebUserControl/GenericLookup/LookupBase.ascx" TagName="LookupBase"
    TagPrefix="uc1" %>
<uc1:LookupBase ID="uclProduct" runat="server" MapperName="ProductLookup" 
QueryServiceName="QryPagingTraining" LookupTitle="Product Lookup" />
