<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="rsv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        Slapyvardis<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 38px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Langas negali būti tuščias"></asp:RequiredFieldValidator>
        <p>
            Slaptažodis<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 39px" Width="117px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Langas negali būti tuščias"></asp:RequiredFieldValidator>
        </p>
        Pakartokite slaptažodį<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 11px" Width="118px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Slaptažodžiai nesutampa"></asp:RequiredFieldValidator>
        <p>
            Vardas<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 27px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Langas negali būti tuščias"></asp:RequiredFieldValidator>
        </p>
        Pavardė<asp:TextBox ID="TextBox5" runat="server" style="margin-left: 17px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Langas negali būti tuščias"></asp:RequiredFieldValidator>
        <div>
<rsv:CaptchaControl ID="captcha1" runat="server" CaptchaHeight="60" CaptchaLength="5"
CaptchaWidth="300" CaptchaLineNoise="None" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
ForeColor="#66ff33" BackColor="White" CaptchaChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789"
FontColor="#ff0000" />
</div>
        <p>
            &nbsp;</p>
        <p>
            Įveskite nuotraukoje esantį tekstą</p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox6" runat="server" style="margin-left: 28px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="Neteisingai įvestas kodas"></asp:RequiredFieldValidator>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 45px" Text="Patvirtinti" />
        </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClick="LinkButton1_Click" ValidateRequestMode="Disabled">Grįžti į prisijungimą</asp:LinkButton>
    </form>
</body>
</html>
