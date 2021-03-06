﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutoPieza.aspx.cs" Inherits="Ejemplo.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 169px;
            width: 757px;
        }
        .auto-style3 {
            width: 808px;
            margin-left: 0px;
        }
        .auto-style5 {
            width: 132px;
        }
        .auto-style6 {
            width: 149px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Administración de AUTOMOVIL y sus PIEZAS</h2> <br />
    <center>
         <table class="auto-style3">
             <tr>
                 <td class="auto-style1">
                     <table>
                         <tr>
                             <td align="left" class="auto-style6">
                                 <asp:Label ID="lblId_A" Text="Modelo de Automovil: " runat="server"  ></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="DDLAuto" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DDLAuto_SelectedIndexChanged">
                                 </asp:DropDownList>
                             </td>
                             <td class="auto-style5">
                                 <asp:Label ID="lblId_Pieza" Text="Pieza: " runat="server"  ></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="DDLPieza" runat="server">
                                 </asp:DropDownList>
                             </td>
                             <td class="auto-style5">
                                 <asp:Label ID="lblCantPieza" Text="Cantidad: " runat="server" ></asp:Label>
                             </td>
                             <td>
                                    <asp:Textbox ID="txtCantPieza" runat="server" ></asp:Textbox>
                             </td>
                             <td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="La cantidad es obligatoria" ControlToValidate="txtCantPieza"></asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <td class="auto-style6"></td>
                         <td></td>
                         <td class="auto-style5"></td>
                         <tr>
                         <td colspan ="4" align="left">
                                <asp:Label ID="lblResultado" runat="server"></asp:Label>
                            </td>
                         </tr>
                         <tr>
                             <td colspan="6" align="center">
                                 <asp:Button ID="btnAgregar" Text="Agregar" runat="server" OnClick="btnAgregar_Click" />
                             </td>
                         </tr>
                     </table>
                 </td>
                 
                 
             </tr>
             <tr>
                 <td>
                     <table>
                         <tr>
                             <td>
                                 <asp:GridView ID="grdPiezaAuto" Width="100%" runat="server"
                                    ViewStateMode="Enabled" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateDeleteButton="True" OnRowDeleting="grdPiezaAuto_RowDeleting"
                                    AutoGenerateColumns="true" EmptyDataText="No hay datos ingresados"
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
