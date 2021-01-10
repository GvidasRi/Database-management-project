<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logs.aspx.cs" Inherits="Logs" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css?parameter=1">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
.container {
  width: 100%;
  height: 700px;
  padding: 10px;
}

.one {
  width: 42%;
  height: 700px;
  overflow: scroll;
  float: left;
}

.two {
  margin-left: 15%;
  height: 200px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
    </div>
    <ul class="nav navbar-nav">
      <li><a href="Pagrindinis.aspx">Pagrindinis</a></li>
      <li><a href="Main.aspx">Įrašai</a></li>
      <li><a href="Accounts.aspx">Paskyros</a></li>
      <li class="active"><a href="Logs.aspx">Veiklos istorija</a></li>
    </ul>
  </div>
</nav>
    
    </div>
        <section class="container">
  <div class="one">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True">
                <ItemStyle Width="50px" />
                </asp:CommandField>
                <asp:BoundField DataField="LogID" HeaderText="Įrašo ID" ReadOnly="True" SortExpression="LogID" >
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="userid" HeaderText="Naudotojo ID" ReadOnly="True" SortExpression="userid" >
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="date" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Data" ReadOnly="True" SortExpression="date" >
                <ItemStyle Font-Bold="True" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="vardas" HeaderText="Vardas" ReadOnly="True" SortExpression="vardas" >
                <HeaderStyle Width="50px" />
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="action" HeaderText="Veiksmas" ReadOnly="True" SortExpression="action" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
  </div>
  <div class="two">
      <h5>
          <asp:Button ID="Button1" runat="server" Height="41px" Text="Atnaujinti įrašus" Width="121px" OnClick="Button1_Click" />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button2" runat="server" Height="42px" Text="Eksportuoti į excel" Width="131px" OnClick="Button2_Click" />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" Text="Ištrinti visus įrašus" Width="131px" OnClientClick="return confirm('Ar tikrai norite ištrinti visus įrašus?')"/>
      </h5>
      <p>
          &nbsp;</p>
      <p>
          &nbsp;</p>
      <p>
          &nbsp;</p>
      <p>
          &nbsp;</p>
      <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Autoriaus informacija"></asp:Label>
      </h3>
      <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Vardas <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="132px"></asp:TextBox></h3>
      <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Privilegijų lygis <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="132px"></asp:TextBox></h3>
      <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Veiksmas <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="234px" Font-Size="Small"></asp:TextBox></h3>
      <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="132px"></asp:TextBox></h3>
      <p>&nbsp;</p>
      
      
  </div>
</section>
    </form>
</body>
</html>
