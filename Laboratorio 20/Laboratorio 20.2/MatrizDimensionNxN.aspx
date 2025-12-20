<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatrizDimensionNxN.aspx.cs" Inherits="Laboratorio_20._2.MatrizDimensionNxN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblN" runat="server" Text="Ingrese la dimensión N de la matriz NxN: "></asp:Label>
        <p>
        <asp:TextBox ID="txtN" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerar" runat="server" Text="Generar matriz" OnClick="btnGenerar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </p>

        <p>
        <asp:Literal ID="litTabla" runat="server"></asp:Literal>

        </p>

    </form>
</body>
</html>
