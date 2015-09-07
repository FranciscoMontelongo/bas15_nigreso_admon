<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpresionFoliosAspirantes.aspx.cs"
    Inherits="WFront.Prelacion.ImpresionFoliosAspirantes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/themes/blitzer/jquery-ui.css" />
    <style type="text/css">
        .style1
        {
            width: 696px;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 18px;
        }
        .style6
        {
            width: 136px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="width: 70%;">
            <tr>
                <td>
                </td>
                <td class="style1">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="font-size: 12px">
                    Entidad ::
                </td>
                <td align="left">
                    <asp:DropDownList ID="cboEntidades" runat="server" AutoPostBack="True" Width="350px"
                        OnSelectedIndexChanged="cboEntidades_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="font-size: 12px">
                    Subsistema ::
                </td>
                <td align="left">
                    <asp:DropDownList ID="cboSubSistemas" runat="server" AutoPostBack="True" Width="350px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style1" align="right" style="font-size: 12px">
                    Folio ::
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFolio" runat="server" Width="245px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
                <td align="left">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="btnEjecutarReporte" runat="server" BackColor="#CF242A" CssClass="button"
                                    Font-Size="8pt" Height="23px" Text="Consultar" Width="102px" OnClick="btnEjecutarReporte_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnImprimir" runat="server" BackColor="#CF242A" CssClass="button"
                                    Font-Size="8pt" Height="23px" Text="Imprimir" Width="102px" OnClick="btnImprimir_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <table id="tblDatos" runat="server" class="style2">
                        <tr>
                            <td align="right" class="style6">
                                <asp:Label ID="Label1" runat="server" Text="Folio Impresión:" CssClass="Titulos_Etiqueta"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblFolioImpresion" runat="server" Text="" CssClass="Titulos_Etiqueta"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style6">
                                <asp:Label ID="Label2" runat="server" Text="Entidad:" CssClass="Titulos_Etiqueta"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEntidad" runat="server" Text="" CssClass="Titulos_Etiqueta"></asp:Label>
                            </td>
                            <td class="style3">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style6">
                                <asp:Label ID="Label3" runat="server" Text="Plaza:" CssClass="Titulos_Etiqueta"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPlaza" runat="server" Text="" CssClass="Titulos_Etiqueta"></asp:Label>
                            </td>
                            <td class="style3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:GridView ID="grDatos" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                        AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="CURP" Font-Size="8pt"
                        GridLines="None" PagerStyle-CssClass="pgr">
                        <AlternatingRowStyle CssClass="alt" Font-Size="8pt" />
                        <Columns>
                            <asp:BoundField DataField="prelac" HeaderText="Número" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="CURP" HeaderText="CURP" />
                            <asp:BoundField DataField="foliofeder" HeaderText="Folio Federal" />
                            <asp:BoundField DataField="DesAsignacion" HeaderText="Estatus" />
                            <asp:BoundField DataField="CLAVECCT" HeaderText="Clave Centro de Trabajo" />
                            <asp:BoundField DataField="DesNomb" HeaderText="Tipo Nombramiento" />
                            <asp:BoundField DataField="CLAVEPRESUPUESTAL" HeaderText="Clave Presupuestal" />
                        </Columns>
                        <PagerStyle CssClass="pgr" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <div id="ImpresionFolios" runat="server" style="display: none">
                        <table align="center">
                            <tr>
                                <td>
                                    <img src="http://201.175.44.226/SNRSPD/MediaSuperiorDirectores/AsignacionDir/imagenes/HeaderPrincipal_D.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Folio de Impresion:
                                    <asp:Label ID="lblFolioImpresion0" runat="server" Text="" CssClass="Titulos_Etiqueta"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Entidad:
                                    <asp:Label ID="lblEntidad0" runat="server" Text="" CssClass="Titulos_Etiqueta"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Plaza:
                                    <asp:Label ID="lblPlaza0" runat="server" Text="" CssClass="Titulos_Etiqueta"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="grFolios" runat="server" AllowPaging="False" AlternatingRowStyle-CssClass="alt"
                                        AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="CURP" EmptyDataText="Sin datos para mostrar."
                                        Font-Size="8pt" GridLines="None" PagerStyle-CssClass="pgr" OnRowCreated="grFolios_RowCreated">
                                        <AlternatingRowStyle CssClass="alt" Font-Size="8pt" />
                                        <Columns>
                                            <asp:BoundField DataField="prelac" HeaderText="Número" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="CURP" HeaderText="CURP" />
                                            <asp:BoundField DataField="foliofeder" HeaderText="Folio Federal" />
                                            <asp:BoundField DataField="DesAsignacion" HeaderText="Estatus" />
                                            <asp:BoundField DataField="CLAVECCT" HeaderText="Clave Centro de Trabajo" />
                                            <asp:BoundField DataField="DesNomb" HeaderText="Tipo Nombramiento" />
                                            <asp:BoundField DataField="CLAVEPRESUPUESTAL" HeaderText="Clave Presupuestal" />
                                        </Columns>
                                    </asp:GridView>
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
