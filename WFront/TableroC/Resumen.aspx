<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resumen.aspx.cs" Inherits="WFront.TableroC.Resumen"
    StylesheetTheme="Asignacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Módulo para la Asignación de Plazas 2015</title>
    <script src="../App_Themes/Asignacion/Scripts/Actualizando.js" type="text/javascript"></script>
    <script src="../App_Themes/Asignacion/Scripts/jquery-1.8.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 33%;
        }
        .style2
        {
            height: 31px;
        }
        .style3
        {
            width: 1000px;
            height: 75px;
        }
        .style4
        {
            height: 29px;
        }
        .style5
        {
            width: 150px;
        }
    </style>
    <style type="text/css">
        html, body, form, #container
        {
            padding: 0;
            margin: 0;
            height: 100%;
        }
        form > #container
        {
            height: auto;
            min-height: 100%;
        }
        #footer
        {
            clear: both;
            position: relative;
            z-index: 10;
            height: 150px;
            margin-top: -150px;
        }
        #wrap
        {
            padding-bottom: 150px;
        }
        #container
        {
            width: 1000px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div>
            <div style="text-align: center; font-size: 14pt; font-family: Verdana; margin: 10px;
                color: #999;">
                Resumen</div>
            <table class="tblResumenContenedor">
                <tr>
                    <td colspan="3" align="left">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 60%;">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="Label1" runat="server" Text="Entidad:" CssClass="Titulos_Etiqueta"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="cbo_Entidad" Width="250px" runat="server" CssClass="Titulos_CajasTexto"
                                        Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="cbo_Entidad_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <%--<table class="gvResumenBody">
                            <tr>
                                <th colspan="2">
                                    Aspirantes
                                </th>
                            </tr>
                            <tr>
                                <td class="style5">
                                    Total Aspirantes
                                </td>
                                <td>
                                    <span id="sASPTotal" runat="server">-</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    Aspirantes con Plaza Asignada &sup1;
                                </td>
                                <td>
                                    <span id="sASPPlazaAsignada" runat="server">-</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    Aspirantes Rechazados
                                </td>
                                <td>
                                    <span id="sASPRechazados" runat="server">-</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    Con más de una Plaza &sup2;
                                </td>
                                <td>
                                    <span id="sASPMasDeUnaPlaza" runat="server">-</span>
                                </td>
                            </tr>
                        </table>--%>
                        <asp:GridView ID = "gvObtenTotalAspirantes" runat = "server" class="gvResumenBody">
                        <HeaderStyle CssClass="gvHeaderResumen" />
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:GridView ID="gvTipoPlazaHoras" CssClass="gvResumenBody" runat="server" >
                            <HeaderStyle CssClass="gvHeaderResumen" />
                        </asp:GridView>
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvTipoSostenimiento" CssClass="gvResumenBody" runat="server" 
                            Width="900px">
                            <HeaderStyle CssClass="gvHeaderResumen" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left">
                        <span class="nota_aclaratoria">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" class="style4">
                        &sup1;<span class="nota_aclaratoria"> Los aspirantes con más de una plaza sólo se contabilizan
                            una vez en el total.<br />
                        </span>&sup2;<span class="nota_aclaratoria"> El número no afecta el total de aspirantes.</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="left" class="style2">
                    </td>
                </tr>
            </table>
        </div>
        <div id="wrap">
        </div>
    </div>
    <div id="footer">
        <div style="width: 1000px; margin: 0 auto;">
            <img class="style3" src="../App_Themes/Asignacion/Images/footer.png" />
        </div>
    </div>
    </form>
</body>
</html>
