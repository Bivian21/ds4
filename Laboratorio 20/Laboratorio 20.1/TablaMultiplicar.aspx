<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TablaMultiplicar.aspx.cs" Inherits="Laboratorio_20._1.TablaMultiplicar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNumero" runat="server" Text="Ingrese un Número"></asp:Label>
        </div>
        <p>
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnTabla" runat="server" OnClick="btnTabla_Click" Text="Crear Tabla" />
            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
        </p>
        <asp:ListBox ID="lstTabla" runat="server" Height="218px" Width="200px"></asp:ListBox>
    </form>
</body>
</html>
