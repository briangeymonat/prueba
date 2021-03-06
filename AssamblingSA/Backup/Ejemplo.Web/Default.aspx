﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Ejemplo.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Administración de categorías
    </h2>
    <br />
    <center>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblIdentificador" Text="Identificador:" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Nombre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El nombre es obligatorio"
                                    ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left">
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
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="grdCategorias" Width="100%" runat="server" AutoGenerateColumns="true"
                                    ViewStateMode="Enabled" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateDeleteButton="true" OnRowDeleting="grdCategorias_RowDeleting" AutoGenerateSelectButton="true"
                                    OnSelectedIndexChanging="grdCategorias_SelectedIndexChanging" EmptyDataText="No hay datos ingresados"
                                    ShowHeaderWhenEmpty="True">
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
