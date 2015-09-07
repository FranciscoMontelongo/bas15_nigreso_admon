<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucFiltros.ascx.cs" Inherits="WFront.Controles.wucFiltros" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="upFiltro" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlFuncion" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlTipo_Evaluacion" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlServicio" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlEntidad_Federativa" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlTipo_Sostenimiento" EventName="SelectedIndexChanged" />
    </Triggers>
    <ContentTemplate>
        <table align="center" border="0">
            <tr>
                <td align="right">
                    <asp:Label ID="lblFuncion" runat="server" Text="Función:" CssClass="Titulos_Etiqueta" Width="139px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlFuncion" runat="server" AutoPostBack="true" Width="500px" CssClass="Titulos_CajasTexto" onselectedindexchanged="ddlFuncion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvFuncion" runat="server" ControlToValidate="ddlFuncion" InitialValue="-1" Display="None" ValidationGroup="gpo_filtro" ErrorMessage="Seleccione una Función."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vceFuncion" runat="server" TargetControlID="rfvFuncion"></asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <!-- Función -->
            <tr>
                <td align="right">
                    <asp:Label ID="lblTipo_Evaluacion" runat="server" Text="Tipo de evaluación:" CssClass="Titulos_Etiqueta" Width="150px"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTipo_Evaluacion" runat="server" AutoPostBack="true" Width="500px" CssClass="Titulos_CajasTexto" OnSelectedIndexChanged="ddlTipo_Evaluacion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipo_Evaluacion" runat="server" ControlToValidate="ddlTipo_Evaluacion" InitialValue="-1" Display="None" ValidationGroup="gpo_filtro" ErrorMessage="Seleccione un tipo de evaluación."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vceTipo_Evaluacion" runat="server" TargetControlID="rfvTipo_Evaluacion"></asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <!-- Tipo de Evaluación -->
            <tr>
                <td align="right">
                    <asp:Label ID="lblServicio" runat="server" Text="Servicio:" CssClass="Titulos_Etiqueta" Width="150px" Visible="false"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlServicio" runat="server" AutoPostBack="true" Width="500px" CssClass="Titulos_CajasTexto" Visible="false" OnSelectedIndexChanged="ddlServicio_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvServicio" runat="server" ControlToValidate="ddlServicio" InitialValue="-1" Display="None" ValidationGroup="gpo_filtro" ErrorMessage="Seleccione un servicio."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vceServicio" runat="server" TargetControlID="rfvServicio"></asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <!-- Servicio -->
            <tr>
                <td align="right">
                    <asp:Label ID="lblEntidad_Federativa" runat="server" Text="Entidad federativa:" CssClass="Titulos_Etiqueta" Width="150px"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlEntidad_Federativa" runat="server" AutoPostBack="true" Width="500px" CssClass="Titulos_CajasTexto" OnSelectedIndexChanged="ddlEntidad_Federativa_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvEntidad_Federativa" runat="server" ControlToValidate="ddlEntidad_Federativa" InitialValue="-1" Display="None" ValidationGroup="gpo_filtro" ErrorMessage="Seleccione una entidad federativa."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vceEntidad_Federativa" runat="server" TargetControlID="rfvEntidad_Federativa"></asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <!-- Entidad Federativa -->
            <tr>
                <td align="right">
                    <asp:Label ID="lblTipo_Sostenimiento" runat="server" Text="Tipo de sostenimiento:" CssClass="Titulos_Etiqueta" Width="150px"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTipo_Sostenimiento" runat="server" Width="500px" CssClass="Titulos_CajasTexto"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipo_Sostenimiento" runat="server" ControlToValidate="ddlTipo_Sostenimiento" InitialValue="-1" Display="None" ValidationGroup="gpo_filtro" ErrorMessage="Seleccione un tipo de sostenimiento."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vceTipo_Sostenimiento" runat="server" TargetControlID="rfvTipo_Sostenimiento"></asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <!-- Tipo de Sostenimiento -->
            <tr>
                <td align="right">
                    <asp:Label ID="lblEstatus" runat="server" Text="Estatus:" CssClass="Titulos_Etiqueta" Width="150px"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlEstatusAsignacion" runat="server" AutoPostBack="true" Width="500px" CssClass="Titulos_CajasTexto" OnSelectedIndexChanged="ddlEstatusAsignacion_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvEstatusAsignacion" runat="server" ControlToValidate="ddlEstatusAsignacion" InitialValue="-1" Display="None" ValidationGroup="gpo_filtro" ErrorMessage="Seleccione un estatus."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vceEstatusAsignacion" runat="server" TargetControlID="rfvEstatusAsignacion"></asp:ValidatorCalloutExtender>
                </td>
            </tr>
            <!-- Estatus de Asignación -->
            <tr>
                <td align="right" colspan="2" style="padding-top: 10px;">
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" BackColor="#CF242A" CssClass="button" OnClick="btnConsultar_Click" ValidationGroup="gpo_filtro" Font-Size="8pt" Height="23px" Width="100px" />
                    <%--<asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" BackColor="#CF242A" CssClass="button" OnClick="btnExportar_Click" ValidationGroup="gpo_filtro" Font-Size="8pt" Height="23px" Width="100px" Visible="false" />--%>
                </td>
            </tr>
        </table>    
    </ContentTemplate>
</asp:UpdatePanel>

