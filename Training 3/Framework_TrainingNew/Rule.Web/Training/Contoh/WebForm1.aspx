<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Training.Contoh.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
  {
        
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
      // Display the company name in italics.
      e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
        
    }
    
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>GridView RowDataBound Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>GridView RowDataBound Example</h3>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSqlDataSource" 
        autogeneratecolumns="true"
        allowpaging="true"
        onrowdatabound="CustomersGridView_RowDataBound" 
        runat="server">
      </asp:gridview>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="CustomersSqlDataSource"  
        selectcommand="Select [CustomerID], [CompanyName], [Address], [City], [PostalCode], [Country] From [Customers]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>"
        runat="server">
      </asp:sqldatasource>
            
            
    </form>
  </body>
</html>