<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ejercicio1.aspx.cs" Inherits="TP4_GRUPO_5.ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 92px;
        }
        .auto-style3 {
            width: 203px;
        }
        .auto-style4 {
            width: 92px;
            height: 31px;
        }
        .auto-style5 {
            width: 203px;
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
        }
        .auto-style7 {
            width: 446px;
        }
        .auto-style8 {
            height: 31px;
            width: 446px;
        }
        .auto-style9 {
            height: 26px;
        }
        .auto-style10 {
            width: 446px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Overline="False" Font-Underline="True" Text="DESTINO INICIO"></asp:Label>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style9">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Text="PROVINCIA:"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:DropDownList ID="ddlProvinciaPartida" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaPartida_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text="LOCALIDAD:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlLocalidadPartida" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Font-Underline="True" Text="DESTINO FINAL"></asp:Label>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Text="PROVINCIA:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlProvinciaDestino" runat="server" OnSelectedIndexChanged="ddlProvinciaDestino_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" Text="LOCALIDAD:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="ddlLocalidadDestino" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnComprar" runat="server" Text="Comprar Boletos" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblMensajeCompra" runat="server"></asp:Label>
    </form>
</body>
</html>
