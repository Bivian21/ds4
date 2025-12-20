<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server">Ingrese los numeros a Sumar</asp:Label>
        </div>
        <p>
            <asp:TextBox ID="txtNumero1" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtNumero2" runat="server"></asp:TextBox>
            </p>
        <p>
            <asp:Button ID="btnSumar" runat="server" Text="Sumar" OnClick="btnSumar_Click" />
            </p>
        <p>
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
