<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarListado.aspx.cs" Inherits="WFront.Asignacion.AsignarListado" StylesheetTheme="Asignacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controles/wucFiltros.ascx" tagname="wucFiltros" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/themes/blitzer/jquery-ui.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                Cargando ...
                <img src="../Imagenes/WaitCursor.gif" alt="" style="height: 30px; width: 30px" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <div style="margin-top: 20px;">
            <uc1:wucFiltros ID="wucFiltros1" runat="server" />
        </div>

        <div style="margin: 10px 20px;">
            <asp:UpdatePanel ID="upDatosAsignacion" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="wucFiltros1" EventName="Buscar"/>
                    <asp:AsyncPostBackTrigger ControlID="gvDatosAsignacion" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="gvDatosAsignacion" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="True" PageSize="15" EmptyDataText="Sin datos para mostrar." Font-Size="8pt"
                        OnPageIndexChanging="gvDatosAsignacion_PageIndexChanging">
                        <AlternatingRowStyle CssClass="alt" Font-Size="8pt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="Posicion" HeaderText="Orden" />
                            <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="CURP" HeaderText="CURP" />
                            <asp:BoundField DataField="FolioFederal" HeaderText="Folio Federal" />
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                            <asp:BoundField HeaderText="Tipo de Nombramiento" />
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" CommandArgument='%# Eval("id_Resultados") %>' OnClick="lnkEditar_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
