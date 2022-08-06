<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLookUpExamCustomer.ascx.cs" Inherits="Rule.Web.WebUserControl.Lookup.UCLookUpExamCustomer" %>
<%@ Register Src="~/WebUserControl/GenericLookup/LookupBase.ascx" TagName="LookupBase" TagPrefix="uc1" %>

<uc1:LookupBase ID="uclLookupExamCustomer" runat="server" MapperName="ExamCustomer" QueryServiceName="QryLookupReceiveFrom" LookupTitle="ExamCustomer" />