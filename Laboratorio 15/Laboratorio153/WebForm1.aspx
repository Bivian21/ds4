<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio153.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Label runat ="server" Font-Bold="True" Width="197px"> Introduzca un Texto </asp:Label>
            <br />
            <br />
           <asp:TextBox ID="TextBox1" runat ="server"></asp:TextBox>
           <asp:Button ID="Unnamed3" runat ="server" Text="Enviar Saludo" OnClick="Unnamed3_Click"/>

        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
