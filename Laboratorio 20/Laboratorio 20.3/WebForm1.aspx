<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_20._3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Aplicación CRUD - Gestión de Productos</h1>
    <form id="form1" runat="server">
        <div>
            <!-- Barra de herramientas -->
            <div>
                <asp:Button ID="btnNuevo" runat="server" Text="Agregar" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Enabled="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Enabled="false" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="false" />
                
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar por id:"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>

            <!-- Campos del formulario -->
            <div style="display:flex; gap:20px;">
                <div style="display:flex; flex-direction:column;">
                    <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
                    <asp:TextBox ID="txtId" runat="server" Enabled="false"></asp:TextBox>
                    
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                    <asp:TextBox ID="txtPrecio" runat="server" Enabled="false"></asp:TextBox>
                </div>
                
                <div style="display:flex; flex-direction:column;">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Enabled="false"></asp:TextBox>
                    
                    <asp:Label ID="lblStock" runat="server" Text="Stock"></asp:Label>
                    <asp:TextBox ID="txtStock" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <!-- Botón Salir, No util-->

            <div>
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
            </div>
        </div>
    </form>
</body>
</html>
