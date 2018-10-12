<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fabricacion_Automovil.aspx.cs" Inherits="Ejemplo.Web.Fabricacion_Automovil" %>
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Administración de FABRICACION DE AUTOMOVILES</h2>
    <br />
    <center>
        <table class="auto-style3">
            <tr>
                <td class="auto-style1">
                    <table> 
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblModelo" Text="Modelo:" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLModelo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLModelo_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El Modelo es obligatorio" ControlToValidate="DDLModelo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                          <tr>
                            <td align="left">
                                <asp:Label ID="Label1" Text="Costo total:" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCosto" runat="server"></asp:Label>
                            </td>
                            <td>
                                
                            </td>
                        </tr>  
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" Text="Tiempo de fabricacion:" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTiempoFabricacion" runat="server"></asp:Label>
                            </td>
                            <td>
                                
                            </td>
                        </tr>   
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label4" Text="Cantidad de operarios:" runat="server" ></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCantOpe" runat="server" ></asp:Label>
                            </td>
                            <td>
                                
                            </td>
                        </tr>    
                    </table>
                </td>
                <td class="auto-style2">
                    <table>
                        <tr>
                            <td>
                             <asp:GridView ID="grdPiezaAuto" Width="100%" runat="server"
                                    ViewStateMode="Enabled" CellPadding="4" ForeColor="#333333" GridLines="None"
                                 AutoGenerateColumns="true"
                                  EmptyDataText="No hay datos ingresados"
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
            <tr>
                <td class="auto-style2">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="grdTipoOpAuto" Width="100%" runat="server"
                                    ViewStateMode="Enabled" CellPadding="4" ForeColor="#333333" GridLines="None"
                                 AutoGenerateColumns="true"
                                  EmptyDataText="No hay datos ingresados"
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
