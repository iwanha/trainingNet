<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomerHist.aspx.cs" Inherits="Training.Exercise.ViewCustomerHist" %>

<%@ Register Src="~/WebUserControl/UCSubSectionContainer.ascx" TagName="UCSubSectionContainer" TagPrefix="uc1" %>

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
                    <asp:Label runat="server" ID="lblPath" Text="Training/Exercise/ViewCustomerHist"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upToolbar" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="toolbar">
                    <span>
                        <label id="pageTitle">View Customer Transaction History</label>
                    </span>
                    <span id="toolMenuContainer">

                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="content">
            <uc1:ucsubsectioncontainer id="ucSubSectionAViewSupplier" toogleid="minViewSuppler" affectedid="dViewSupplier"
                subsectiontitle="View Customer" runat="server" />
            <div id="dViewSupplier">
                <asp:UpdatePanel runat="server" ID="upGrid" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="formTable">
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustNo" Text="Customer No"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCustNo"></asp:Label>
                                    <asp:label runat="server" Visible="false" ID="lblCustId" Text='<%# Eval("CustId") %>'>test</asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustName" Text="Customer Name"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCustName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_Cust_CustType" Text="Customer Type"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCustType"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Address" Text="Customer Address"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Rt" Text="Rt/Rw"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblRt"></asp:Label>
                                    
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Kelurahan" Text="Kelurahan"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblKelurahan"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Kecamatan" Text="Kecamatan"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblKecamatan"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_City" Text="City"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblCity"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td width="20%" class="tdDesc">
                                    <asp:Literal runat="server" ID="ltl_CustAddr_Zipcode" Text="Zipcode"></asp:Literal>
                                </td>
                                <td width="80%" class="tdValue">
                                    <asp:Label runat="server" ID="lblZipcode"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                    <uc1:ucsubsectioncontainer id="Ucsubsectioncontainer1" toogleid="minViewSuppler" affectedid="dViewSupplier"
                subsectiontitle="Transaction History" runat="server" />
                
            </div>
        </div>
    </form>
</body>
</html>
