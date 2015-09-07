<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webDefault.aspx.cs" Inherits="WFront.webDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Módulo para la Asignación de Plazas 2015</title>
    <link href="Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="Styles/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <link href="Styles/MenuStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        javascript: window.history.forward(1);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="width: 80%;">
            <tr>
                <td align="center" class="style2" colspan="3">
                    <img alt="" class="style5" src="Imagenes/HeaderPrincipal_MS.jpg" />
                </td>
            </tr>
            <tr>
                <td align="Center" colspan="3" class="style2">
                    <img alt="" class="style3" src="Imagenes/asignacion_plazas.jpg" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:Label ID="lblUsuario" runat="server" CssClass="Avisos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <nav id="topNav">
                    <asp:Menu ID="menuConsultas" runat="server"
                        onmenuitemclick="menuConsultas_MenuItemClick" Orientation="Horizontal"
                        ItemWrap="True">
                    </asp:Menu>
                </nav>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" class="style7">
                    <iframe id="I1" runat="server" align="middle" frameborder="0" name="I1" scrolling="auto"
                        style="border-style: none; border-color: inherit; border-width: medium; color: #F7F7F7;
                        height: 618px; width: 1208px; background-color: #F7F7F7;" title="FrameMuestraAdmin">
                    </iframe>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <img alt="" class="style6" src="Imagenes/pie.png" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>