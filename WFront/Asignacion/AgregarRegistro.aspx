<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarRegistro.aspx.cs" Inherits="WFront.Asignacion.AgregarRegistro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Asignacion.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
    <style type="text/css">
        .style1
        {
            width: 211px;
        }
        .style2
        {
            width: 129px;
        }
        .style4
        {
        }
        .style6
        {
            width: 156px;
        }
        .style7
        {
            width: 200px;
        }
        .style8
        {
            width: 155px;
        }
        .style9
        {
            width: 181px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td>
                    <table style="width: 90%;">
                        <tr>
                            <td class="Titulos_Etiqueta0">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="Titulos_Etiqueta0">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="Titulos_Etiqueta0" align="center">
                                Datos del Aspirante
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divOpcRechazar" runat="server" style="display: none">
                        <table width="90%">
                            <tr>
                                <td colspan="2" class="Titulos_Etiqueta0">
                                    Rechazar al Aspirante
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Motivo:
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divOpcAsingarEditar" runat="server" style="display: inline">
                        <table>
                            <tr>
                                <td>
                                    <table style="width: 90%;">
                                        <tr>
                                            <td align="right" class="style1">
                                                Tipo Registro::
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:DropDownList ID="cboTipoRegistro" runat="server" Width="150px" 
                                                    AutoPostBack="true" 
                                                    onselectedindexchanged="cboTipoRegistro_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="--Seleccione--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Nuevo Ingreso"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Docente en Servicio"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="style6">
                                                Tipo Sostenimiento ::
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cboTipoSostenimiento" runat="server" Width="150px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style1">
                                                Nombre del Aspirante::
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:TextBox ID="txtNombre" runat="server" Width="250px" style="text-transform :uppercase"></asp:TextBox>
                                            </td>
                                            <td align="right" class="style6">
                                                Apellido Paterno ::
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtApellidoPaterno" runat="server" Width="200px" style="text-transform :uppercase"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style6">
                                                Apellido Materno ::
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:TextBox ID="txtApellidoMaterno" runat="server" Width="200px" style="text-transform :uppercase"></asp:TextBox>
                                            </td>
                                            <td align="right" class="style6">
                                                RFC ::
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRFC" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style1">
                                                Tipo ::
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:DropDownList ID="cboTipo" runat="server" Width="150px">
                                                    <asp:ListItem Value="0" Text="--Seleccione--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Cumple Perfil"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pensionado"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="style6">
                                                Correo ::
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCorreo" runat="server" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style1">
                                                Dirección ::
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:TextBox ID="txtDireccion" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td id="lblHSM" runat="server" align="right" class="style6">
                                                Telefono ::
                                            </td>
                                            <td align="left">
                                                <div id="divHSM" runat="server" style="display: inline;">
                                                    <asp:TextBox ID="txtTelefono" runat="server" Width="200px"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style1">
                                                Telefono Celular ::
                                            </td>
                                            <td align="left" class="style2">
                                                <asp:TextBox ID="txtTelefonoCelular" runat="server" Width="250px"></asp:TextBox>
                                            </td>
                                            <td id="Td1" runat="server" align="right" class="style6">
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table id="DatosAdicionales" runat="server" visible="false" style="width: 90%;">
                            <tr>
                                <td align="right" class="style8">
                                    Clave Centro de Trabajo ::
                                </td>
                                <td align="left" class="style7">
                                    <asp:TextBox ID="txtClaveCCT" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td align="right" class="style9">
                                    Nombre Centro de trabajo ::
                                </td>
                                <td align="left" class="style8">
                                    <asp:TextBox ID="txtNombreCCT" runat="server" Width="194px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style8">
                                    Tipo Plaza ::
                                </td>
                                <td align="left" class="style7">
                                    <asp:DropDownList ID="cbTipoPlaza" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="cbTipoPlaza_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="--Seleccione--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Jornada"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Hora Semana Mes"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" class="style9">
                                    Horas ::
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtHoras" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right" class="style8">
                                    Turno ::
                                </td>
                                <td align="left" class="style7">
                                    <asp:DropDownList ID="cboTurno" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                              <td align="right" class="style9">
                                    Tipo Nombramiento ::
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cboNombramiento" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style8">
                                    &nbsp;</td>
                                <td align="left" class="style7">
                                    &nbsp;</td>
                                <td class="style9">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="style8">
                                    &nbsp;
                                </td>
                                <td align="left" class="style7">
                                    &nbsp;
                                </td>
                                <td align="right" class="style9">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table align="center">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                               <td align="right" class="style8">
                                    &nbsp;
                                </td>
                                <td align="right" class="style8">
                                    &nbsp;
                                </td>
                                <td align="center" class="style4">
                                    <asp:Button ID="btnActualizar" runat="server" BackColor="#CF242A" CssClass="button"
                                        Font-Size="8pt" Height="23px" Text="Guardar" Width="102px" OnClick="btnActualizar_Click" />
                                </td>
                                <td align="right" class="style8">
                                    &nbsp;
                                </td>
                                <td align="right" class="style8">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
