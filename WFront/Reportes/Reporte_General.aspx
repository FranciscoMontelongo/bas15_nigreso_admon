<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte_General.aspx.cs" Inherits="WFront.Reportes.Reporte_General" StylesheetTheme="Asignacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Módulo para la Asignación de Funciones 2015</title>

        <link href="../App_Themes/Asignacion/Style/Asignacion%202014.css" rel="stylesheet"
        type="text/css" />
    <link href="../App_Themes/Asignacion/Style/Tab_Container.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .alineacion_izquierda
        {
            text-align: left;
        }
        .style3
        {
            width: 72px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="text-align: center; font-size: 14pt; font-family: Verdana; margin: 10px; color: #999;">Reporte General</div>  
        <asp:UpdatePanel ID="updPanel" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_Exportar" />
            </Triggers>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updPanel">
                                <ProgressTemplate>
                                    <center>
                                         <img id="imgProcesando" class="imgProcesando" alt="Procesando..." src="../App_Themes/Asignacion/Images/WaitCursor.gif" height="22"; style="visibility: visible;" border="0" />
                                        Procesando, espere por favor ...
                                        <br />
                                        <br />
                                    </center>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="400px">
                                <tr>
                                    <td style="text-align: left" class="style3">
                                        <asp:Label ID="Label19" runat="server" CssClass="Titulos_Etiqueta" Text="Entidad:"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="ddlEntidad" runat="server" AutoPostBack="True" CssClass="Titulos_CajasTexto"
                                            EnableTheming="True" OnSelectedIndexChanged="ddlEntidad_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3" style="text-align: left">
                                        &nbsp;
                                    </td>
                                    <td style="text-align: left">
                                      <asp:Button ID="btn_Buscar" runat="server"  alt="Actualizar" Text="Buscar" 
                                            BackColor="#CF242A" CssClass="button" OnClick="btn_Buscar_Click"   
                                            OnClientClick="MuestraGif();" Font-Size="8pt" Height="23px" Width="100px" />
                                        &nbsp;
                                          <asp:Button ID="btn_Exportar" runat="server" Text="Exportar a Excel" BackColor="#CF242A" CssClass="button" OnClick="btn_Exportar_Click" OnClientClick="MuestraGif();" Font-Size="8pt" Height="23px" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id = "dvRep">
                    <asp:gridview id = "gvReporte" runat = "server" allowpaging = "true" 
                        pagerstyle-cssclass="pgr" alternatingrowstyle-cssclass="alt" pagesize = "20" 
                        onpageindexchanging="gvReporte_PageIndexChanging"                         > 
                    </asp:gridview>
                    <asp:Label ID = "lblMensaje" runat = "server" Text = "No existe información para la consulta especificada." Visible = "false">
                    </asp:Label>
                </div>
            </ContentTemplate>            
        </asp:UpdatePanel>  
        </form>        
    </body>
</html>
