<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WFront.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Módulo para la Asignación de Plazas 2015</title>
    <link href="Styles/btnStyle.css" rel="stylesheet" type="text/css" /> 
    <script src="Validaciones/Login.js" type="text/javascript"></script> 
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 21px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            height: 25px;
        }
        .style5
        {
            height: 26px;
        }
        .style6
        {
            height: 29px;
        }
        .style7
        {
            height: 58px;
        }
        .style8
        {
            width: 1000px;
        }
        .style9
        {
            width: 1000px;
            height: 58px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table style="width:100%;">
            <tr>
                <td class="style2">
                </td>
                <td class="style3" align="center">
                    <img alt="" class="style10" src="Imagenes/HeaderPrincipal_MS.jpg" /></td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style5">
                </td>
                <td class="style6" align="center">
                    <img alt="" class="style9" src="Imagenes/asignacion_plazas.jpg" /></td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style6" align="center">
                    <img alt="" class="style9" src="Imagenes/BarraInicio.png" /></td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" class="style1">
                        <table bgcolor="White" 
                            style="width: 445px; height: 226px; background-image: url('Imagenes/acceso.png');" >
                            <tr>
                                <td colspan="2" style="text-align: center" class="style24">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                                        Font-Names="Arial, Helvetica, sans-serif" ForeColor="White" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style15" align="right">
                                </td>
                                <td class="style13" align="right">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style16">
                                    <asp:Label ID="Label21" runat="server" CssClass="etiquetas" Font-Bold="True" 
                                        Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="Black" 
                                        Text="Nombre de usuario:"></asp:Label>
                                </td>
                                <td align="left" class="style4">
                                    <asp:TextBox ID="txtNombreUsuario" runat="server" BorderColor="#CF242A" 
                                        BorderStyle="Solid" BorderWidth="1px" CssClass="tb_large" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style15">
                                    <asp:Label ID="Label22" runat="server" CssClass="etiquetas" Font-Bold="True" 
                                        Font-Names="Arial, Helvetica, sans-serif" Font-Size="Small" ForeColor="Black" 
                                        Text="Contraseña:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtContrasenia" runat="server" BorderColor="#CF242A" 
                                        BorderStyle="Solid" BorderWidth="1px" CssClass="tb_large" TextMode="Password" 
                                        Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style15">
                                    <asp:Label ID="Label23" runat="server" CssClass="etiquetas" Font-Bold="True" 
                                        Font-Names="Arial,Helvetica,sans-serif" Font-Size="Small" ForeColor="Black" 
                                        Text="Seleccione Perfil:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cblPerfiles" runat="server" Height="19px" Width="183px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8" colspan="2" align="center">
                                    <asp:Button ID="btnAutenticarUsuario" runat="server" BackColor="#CF242A" 
                                        CssClass="button" Font-Size="11pt" Height="33px" 
                                        onclick="btnAutenticarUsuario_Click" OnClientClick="return CamposValida();" 
                                        Text="Acceder" Width="102px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" valign="middle">
                                    &nbsp;&nbsp;
                                    </td>
                            </tr>
                            </table>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" class="style1">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        AsyncPostBackTimeout="36000">
                    </asp:ScriptManager>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td align="center" class="style7">
                </td>
                <td class="style7">
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" class="style1">
                    <img alt="" class="style11" src="Imagenes/pie.png" /></td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
