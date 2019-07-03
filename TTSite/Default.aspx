<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TDIN Book Store</title>
    <style type="text/css">
      .auto-style1 {
        width: 100%;
      }
      .auto-style3 {
            width: 140px;
            font-family: Arial;
            height: 74px;   
        }
        .auto-style6 {
            height: 74px;
        }
        .auto-style7 {
            margin-left: 40px;
        }
    </style>
</head>
<body style="background-color: #ffffff">
  <form id="form1" runat="server">
    <div>
    
      <h1>Book Store</h1>
      <table class="auto-style1">
        <tr>
          <td class="auto-style3">Your Email</td>
          <td class="auto-style6">
              <asp:TextBox ID="emailTextBox" runat="server" Width="248px"></asp:TextBox>
          </td>
        </tr>
      </table>
      <p>
        <asp:Button ID="switchTableButton" runat="server" OnClick="OnSwitchTableButtonClick" Text="Check Your Orders" />
      </p>
        <p>
            <asp:Label ID="userShowMessages" runat="server" Visible="False"></asp:Label>
      </p>
      <p class="auto-style7">
        &nbsp;&nbsp;
        <asp:GridView ID="BooksAndAvalabilityGridView" runat="server" Height="289px" Width="1067px" BackColor="White" BorderColor="#CCCCCC" DataKeyNames="Book Id" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnIncrementQuantity" runat="server" CommandArgument='<%#Eval("Book Id")%>' OnCommand="IncrementBookTitleQuantity" Text="+">
                        </asp:Button>
                        <asp:Button ID="btnDecrementQuantity" runat="server" CommandArgument='<%#Eval("Book Id")%>' OnCommand="DecrementBookTitleQuantity" Text="-">
                        </asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
          </asp:GridView>
          <asp:GridView ID="ClientOrdersGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
              <FooterStyle BackColor="White" ForeColor="#000066" />
              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
              <RowStyle ForeColor="#000066" />
              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F1F1F1" />
              <SortedAscendingHeaderStyle BackColor="#007DBB" />
              <SortedDescendingCellStyle BackColor="#CAC9C9" />
              <SortedDescendingHeaderStyle BackColor="#00547E" />
          </asp:GridView>
      </p>

    </div>
      <p>
            <asp:Button ID="submitOrderButton" runat="server" Text="Submit Order" OnClick="OnSubmitOrderButtonClick" />
          </p>
  </form>
</body>
</html>