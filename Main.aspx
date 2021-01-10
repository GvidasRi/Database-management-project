<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" CodeBehind="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css?parameter=1">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script type="text/javascript">
     function runPostback() {
         document.forms["form1"].submit();
         document.getElementById("TextBox8").focus();
     }
     function getFocus(){
         var text = document.getElementById("TextBox8");
         if (text != null && text.value.length > 0) {
             if (text.createTextRange) {
                 var FieldRange = text.createTextRange();
                 FieldRange.moveStart('character', text.value.length); 
                 FieldRange.collapse();
            FieldRange.select(); } }
}

function SetDelay() {
    setTimeout("runPostback()", 100);
}
 </script>
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
      <li class="active"><a href="Main.aspx">Įrašai</a></li>
      <li><a href="Accounts.aspx">Paskyros</a></li>
      <li><a href="Logs.aspx">Veiklos istorija</a></li>
    </ul>
  </div>
</nav>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Naujas įrašas" Font-Bold="True" Font-Names="Arial Black"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Koreguoti įrašą" Font-Bold="True" Font-Names="Arial Black"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial Black" Text="Autoriaus informacija"></asp:Label>
        <br />
        <br />
        </div>
        Svarbumas
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">Aukštas</asp:ListItem>
            <asp:ListItem Value="2">Vidutinis</asp:ListItem>
            <asp:ListItem Value="3">Žemas</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Svarbumas
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="1">Aukštas</asp:ListItem>
            <asp:ListItem Value="2">Vidutinis</asp:ListItem>
            <asp:ListItem Value="3">Žemas</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Vardas
        <asp:TextBox ID="TextBox5" runat="server" Width="135px"></asp:TextBox>
        <br />
        Projektas
        <asp:TextBox ID="TextBox1" runat="server" Width="128px" Height="22px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Statusas&nbsp; <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem Value="1">Sutvarkyta</asp:ListItem>
            <asp:ListItem Value="2">Nesutvarkyta</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Pavardė
        <asp:TextBox ID="TextBox6" runat="server" Width="135px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Paieška <asp:TextBox ID="TextBox8" runat="server" OnTextChanged="TextBox8_TextChanged" onkeyup="SetDelay();" AutoPostBack="true"></asp:TextBox>
        <br />
        Problema
        <asp:TextBox ID="TextBox2" runat="server" Height="22px" Width="128px" MaxLength="150"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Projektas <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 0px" Width="128px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Privilegijos
        <asp:TextBox ID="TextBox7" runat="server" Width="136px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sukurti" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Problema <asp:TextBox ID="TextBox4" runat="server" Width="128px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="Atnaujinti" OnClick="Button2_Click" style="margin-left: 0px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Ištrinti" OnClick="Button3_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TicketID" HeaderText="Įrašo ID" ReadOnly="True" SortExpression="TicketID" />
                <asp:BoundField DataField="user" HeaderText="Autoriaus ID" ReadOnly="True" SortExpression="user" />
                <asp:BoundField DataField="statusas" HeaderText="Statusas" ReadOnly="True" SortExpression="statusas" />
                <asp:BoundField DataField="data" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Sukurimo data" ReadOnly="True" SortExpression="data" />
                <asp:BoundField DataField="priority" HeaderText="Svarbumas" ReadOnly="True" SortExpression="priority" />
                <asp:BoundField DataField="projektas" HeaderText="Projektas" ReadOnly="True" SortExpression="projektas" />
                <asp:BoundField DataField="problema" HeaderText="Problema" ReadOnly="True" SortExpression="problema" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </form>
</body>
</html>