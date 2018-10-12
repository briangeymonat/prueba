<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Operario.aspx.cs" Inherits="Ejemplo.Web.Operario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 215px;
            width: 497px;
        }
        .auto-style2 {
            height: 215px;
            width: 314px;
        }
        .auto-style3 {
            width: 788px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Administración de operarios</h2>
    <br />
    <center>
        <table class="auto-style3">
            <tr>
                <td class="auto-style1">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCi" Text="CI:" runat="server" Visible="true"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCi" runat="server" Visible="true"></asp:TextBox>
                            </td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="La Cédula es obligatoria"
                                    ControlToValidate="txtCi"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Nombre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" MaxLength="50" runat="server" Width="122px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El nombre es obligatorio"
                                    ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Dirección:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDireccion" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="La direccion es obligatoria" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Teléfono:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefono" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El teléfono es obligatorio" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style4">
                                Tipo:
                            </td>
                            <td class="auto-style4">
                                <asp:DropDownList ID="DDLTipo" runat="server" Visible="true" Width="100%">
                                 </asp:DropDownList>
                            </td>
                            <td class="auto-style4">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Se debe especificar el tipo" ControlToValidate="DDLTipo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>   
                            <td colspan ="3" align="left">
                                <asp:Label ID="lblResultado" runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="3" align="left">
                                <asp:Button ID="btnAgregar" Text="Agregar" runat="server" OnClick="btnAgregar_Click" />
                                <asp:Button ID="btnActualizar" runat="server" Text="Modificar" Visible="false" OnClick="btnActualizar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style2">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="grdOperarios" Width="100%" runat="server"
                                    ViewStateMode="Enabled" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateDeleteButton="True" OnRowDeleting="grdOperarios_RowDeleting" AutoGenerateSelectButton="True"
                                    OnSelectedIndexChanging="grdOperarios_SelectedIndexChanging" EmptyDataText="No hay datos ingresados"
                                    ShowHeaderWhenEmpty="True" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
        </table>
    </center>
</asp:Content>