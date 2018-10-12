<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ejemplo.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
        Login
    </h2>
    <br />
    <center>
        <table id="tableLogin" runat="server" visible="true">
            <tr>
                <td>
                    Usuario:
                </td>
                <td>
                    <asp:TextBox  ID="usuario" runat="server"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Contraseña:
                </td>
                <td>
                    <asp:TextBox  ID="pass" runat="server" TextMode="Password"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblresultado" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInicio" Text="Iniciar Sesion" runat="server" OnClick="btnInicio_Click" />
                </td>
            </tr>
        </table>
    </center>
    
    </div>
    </form>
</body>
</html>
