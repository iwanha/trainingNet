<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLookupProduk.ascx.cs" Inherits="Rule.Web.WebUserControl.Lookup.UCLookupProduksi" %>
<%@ Register Src="~/WebUserControl/GenericLookup/LookupBase.ascx" TagName="LookupBase" TagPrefix="uc1" %>

<uc1:LookupBase ID="uclLookupProduk" runat="server" MapperName="Produk" QueryServiceName="QueryPagingLookupProduk" LookupTitle="Produk" />
