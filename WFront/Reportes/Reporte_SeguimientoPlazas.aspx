<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte_SeguimientoPlazas.aspx.cs" Inherits="WFront.Reportes.Reporte_Asignaciones"  %>
<%@ Register src="~/Controles/wucFiltros.ascx" tagname="wucFiltros" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Módulo para la Asignación de Funciones 2015</title>
    <link href="../App_Themes/Asignacion/Style/Asignacion%202014.css" rel="stylesheet"
        type="text/css" />
</head>
<center>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div style="text-align: center; font-size: 14pt; font-family: Verdana; margin: 10px; color: #999;">Reporte de Asignaciones</div>
    
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                Cargando ...
                <img src="../Imagenes/WaitCursor.gif" alt="" style="height: 30px; width: 30px" />
                
            </ProgressTemplate>
        </asp:UpdateProgress>  
    <table style="width:600;">
        <tr>
            <td style="vertical-align: bottom; text-align: center; width:500;">
            <uc1:wucFiltros ID="wucFiltros1" runat="server" Ver_btnExportar="false" />
            </td>
            <td style="vertical-align: bottom; text-align: left; width:100; padding-bottom:3pt;">
                <asp:Button ID="btn_Exportar" runat="server" Text="Exportar a Excel" BackColor="#CF242A" CssClass="button" OnClick="btn_Exportar_Click" Font-Size="8pt" Height="23px" Width="100px" />
            </td>
        </tr>
        </table>
 
                
                
        <asp:UpdatePanel ID="updPanel" runat="server">
            <ContentTemplate>
                <div id = "dvRep">
                    <asp:gridview id = "gvReporte" runat = "server" allowpaging = "true" 
                        pagerstyle-cssclass="pgr" alternatingrowstyle-cssclass="alt" pagesize = "20" 
                        onpageindexchanging="gvReporte_PageIndexChanging" onrowdatabound="gvReporte_RowDataBound" 
                        > 
                    </asp:gridview>
                    <asp:Label ID = "lblMensaje" runat = "server" Text = "No existe información para la consulta especificada." Visible = "false">
                    </asp:Label>
                </div>
            </ContentTemplate>            
        </asp:UpdatePanel>                                        
        </form>                        
</body>    
</center>                    
</html>
