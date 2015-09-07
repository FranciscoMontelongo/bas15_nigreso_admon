<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs"
    Inherits="WFront.Configuracion.Configuracion" StylesheetTheme="Asignacion" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Módulo para la Asignación de Plazas 2015</title>
    <script src="../App_Themes/Asignacion/Scripts/Actualizando.js" type="text/javascript"></script>
    <script src="../App_Themes/Asignacion/Scripts/jquery-1.8.1.min.js" type="text/javascript"></script>
     <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/themes/blitzer/jquery-ui.css" />
    <style type="text/css">
        .style1
        {
            width: 639px;
        }
    </style>
</head>
<center>
    <body>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="text-align: center; font-size: 14pt; font-family: Verdana; margin: 10px;
            color: #999;">
            Periodo de Asignación de Plazas</div>
        <%-- <table width="1000px" border="0">
                       <tr>
                <td colspan="5" align="center">
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Periodo de Asignación de Plazas" Style="font-weight: 700;
                        font-size: 12pt" /><br /><br />
                </td>
            </tr>
         </table>--%>
        <asp:Panel ID="DivFechas" runat="server" Visible="false">
            <table width="264" border="0">
                <tr>
                    <td nowrap="nowrap">
                        <b>&nbsp;Entidad:&nbsp;</b>
                    </td>
                    <td colspan="4" nowrap="nowrap" class="alineacion_izquierda">
                        &nbsp;<b><span id="spnEntidad" runat="server"></span></b><div id="IdEntidad" runat="server"
                            visible="false">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <b>&nbsp;Fecha Inicial:&nbsp;</b>
                    </td>
                    <td nowrap="nowrap">
                        <ew:CalendarPopup ID="FechaIni" runat="server" ControlDisplay="TextBoxImage" Font-Bold="False"
                            ForeColor="#0000C0" ImageUrl="../App_Themes/Asignacion/Images/Calendar.png" Width="72px"
                            Font-Names="Arial" Font-Size="8pt">
                        </ew:CalendarPopup>
                        <td nowrap="nowrap">
                            <b>&nbsp;Fecha Final:&nbsp;</b>
                        </td>
                        <td nowrap="nowrap">
                            <ew:CalendarPopup ID="FechaFin" runat="server" ControlDisplay="TextBoxImage" Font-Bold="False"
                                ForeColor="#0000C0" ImageUrl="../App_Themes/Asignacion/Images/Calendar.png" Width="72px"
                                Font-Names="Arial" Font-Size="8pt">
                            </ew:CalendarPopup>
                        </td>
                        <td nowrap="nowrap">
                            <asp:Button ID="btn_Actualizar" runat="server" alt="Cerrar" CssClass="btn01" Text="Guardar"
                                OnClick="btn_Actualizar_Click" />
                            &nbsp;
                            <asp:Button ID="btn_Cerrar" runat="server" alt="Cerrar" CssClass="btn01" Text="Cerrar"
                                OnClick="btn_Cerrar_Click" />
                        </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        &nbsp;
                    </td>
                    <td colspan="4" nowrap="nowrap" style="text-align: left">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lbl_Mensaje" runat="server" CssClass="nota_aclaratoria" Font-Bold="True"
            Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="gvFechaContratacion" 
        runat="server" 
        AutoGenerateColumns="False"
        EnableModelValidation="True" 
        AllowPaging="True" 
        PageSize="50" 
        CssClass="mGrid"
        Width="700px" 
        GridLines="None"
        Font-Size="8pt"
        EmptyDataText="Sin datos para mostrar."
        OnPageIndexChanging="gvFechaContratacion_PageIndexChanging" 
        OnRowDataBound="gvFechaContratacion_RowDataBound"
        OnSelectedIndexChanged="gvFechaContratacion_SelectedIndexChanged">
        <AlternatingRowStyle CssClass="alt" Font-Size="8pt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="ClaveEntidad" HeaderText="ID" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderText="Nombre Entidad"></asp:BoundField>
            <asp:BoundField DataField="FechaInicioAsignacion" HeaderText="Fecha Inicial" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="FechaFinalAsignacion" HeaderText="Fecha Final" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:ImageButton ID="btn_Editar" runat="server" ImageUrl="~/App_Themes/Asignacion/Images/Editar.png"
                        OnClick="btn_Editar_Click" Width="25px" 
                        CommandArgument=' <%# Eval("ClaveEntidad") +"|"+ Eval("Descripcion") +"|" + Eval("FechaInicioAsignacion") +"|" + Eval("FechaFinalAsignacion") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <asp:HiddenField ID="hidEntidad" runat="server" Value="0" />
    <asp:HiddenField ID="hidDescripcion" runat="server" Value="" />
    <asp:HiddenField ID="hidFechaIni" runat="server" Value="" />
    <asp:HiddenField ID="hidFechaFin" runat="server" Value="" />
        </form>
    </body>
</center>
</html>
