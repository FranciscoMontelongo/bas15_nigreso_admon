<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignar.aspx.cs" Inherits="WFront.Asignacion.Asignar" StylesheetTheme="Asignacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

    <div>
        <table style="width: 95%; margin: 0 auto;">
            <tr>
                <td style="width: 45%;" valign="top">
                    <table style="width: 95%; margin: 0 auto;">
                        <tr>
                            <td style="text-align: right; width: 25%;">Nombre ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblNombre" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 25%;">CURP ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblCURP" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">Estatus Actual ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblEstatus" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">Folio Federal ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblFolioFederal" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 55%;" valign="top">
                    <table style="width: 95%; margin: 0 auto;">
                        <tr>
                            <td style="text-align: right; width: 27%;">Función ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblFuncion" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 27%;">Entidad ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblEntidad" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 27%;">Servicio ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblServicio" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 27%;">Tipo de Evaluación ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblTipoEvuacion" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 27%;">Tipo de Sostenimiento ::</td>
                            <td style="text-align: left;"><asp:Label ID="lblTipoSostenimiento" runat="server" CssClass="ItemCol"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        <div style="margin: 20px;">
            <asp:UpdatePanel ID="upNombramientos" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="grNombramientos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="True" Font-Size="8pt">
                        <AlternatingRowStyle CssClass="alt" Font-Size="8pt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("ID_AsignacionDetalle") %>' OnClick="lnkSeleccionar_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CCT" HeaderText="Clave" />
                            <asp:BoundField DataField="NombreCCT" HeaderText="Centro de trabajo" />
                            <asp:BoundField DataField="Nombramiento" HeaderText="Nombramiento" />
                            <asp:BoundField DataField="Turno" HeaderText="Turno" />
                            <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" />
                            <asp:BoundField DataField="TipoVacante" HeaderText="Cargo" />
                            <asp:BoundField DataField="TipoNombramiento" HeaderText="Nombramiento" />
                            <asp:BoundField DataField="ClavePresupuestal" HeaderText="Clave presupuestal" />
                            <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha de asignación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Entidad_Origen" HeaderText="Entidad de origen" />
                            <asp:BoundField DataField="AproboEvaluacionInduccion" HeaderText="Aprobó" />
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("ID_AsignacionDetalle") %>' OnClick="lnkEliminar_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <!-- Botón para agregar una nueva asignación -->
        </div>

        <asp:UpdatePanel ID="upCapturaAsignacion" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:Panel ID="pnlCapturaAsignacion" runat="server" DefaultButton="btnGuardar">
                    <table style="width: 95%; margin: 20px auto; border-color: #cf242A; border-top-style: solid; border-width: thin;">
                        <tr>
                            <td style="width: 50%;" valign="top">
                                <table style="width: 95%; margin: 0 auto;" cellspacing="4">
                                    <tr>
                                        <td style="text-align: right; width: 30%;">Clave:</td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtCCT" runat="server" Width="97%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCCT" runat="server" ControlToValidate="txtCCT" Display="None" ErrorMessage="La clave es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceCCT" runat="server" TargetControlID="rfvCCT" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Centro de trabajo:</td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtNombreCCT" runat="server" Width="97%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNombreCCT" runat="server" ControlToValidate="txtNombreCCT" Display="None" ErrorMessage="El centro de trabajo es requerido" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceNombreCCT" runat="server" TargetControlID="rfvNombreCCT" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Turno:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlTurno" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTurno" runat="server" ControlToValidate="ddlTurno" InitialValue="-1" Display="None" ErrorMessage="El turno es requerido" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceTurno" runat="server" TargetControlID="rfvTurno" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Vigencia de adscripción:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlVigenciaAdscripcion" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvVigenciaAdscripcion" runat="server" ControlToValidate="ddlVigenciaAdscripcion" InitialValue="-1" Display="None" ErrorMessage="La vigencia de adscripción es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceVigenciaAdscripcion" runat="server" TargetControlID="rfvVigenciaAdscripcion" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table style="width: 95%; margin: 0 auto;">
                                                <tr>
                                                    <td>Fecha inicial:</td>
                                                    <td><asp:Label ID="lblFechaFinal" runat="server" Text="Fecha final:"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFechaInicial" runat="server" Enabled="false"></asp:TextBox>
                                                        <img id="calendario_inicio" alt="" src="../Imagenes/calendario.png" />
                                                        <asp:CalendarExtender ID="ceFechaInicial" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaInicial" PopupButtonID="calendario_inicio"></asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="rfvFechaInicial" runat="server" ControlToValidate="txtFechaInicial" Display="None" ErrorMessage="La fecha inicial es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="vceFechaInicial" runat="server" TargetControlID="rfvFechaInicial" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlFechaPeriodo" runat="server">
                                                            <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="false"></asp:TextBox>
                                                            <img id="calendario_fin" alt="" src="../Imagenes/calendario.png" />
                                                            <asp:CalendarExtender ID="ceFechaFinal" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaFinal" PopupButtonID="calendario_fin"></asp:CalendarExtender>
                                                            
                                                            <asp:RequiredFieldValidator ID="rfvFechaFinal" runat="server" ControlToValidate="txtFechaFinal" Display="None" ErrorMessage="La fecha final es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="vceFechaFinal" runat="server" TargetControlID="rfvFechaFinal" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                                            
                                                            <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txtFechaInicial" ControlToValidate="txtFechaFinal" Type="Date" Operator="GreaterThan" ErrorMessage="Fecha no válida" Display="None" ValidationGroup="grp_asignacion"></asp:CompareValidator>
                                                            <asp:ValidatorCalloutExtender ID="vceFechas" runat="server" TargetControlID="cvFechas" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Vacante:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlTipoVacante" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTipoVacante" runat="server" ControlToValidate="ddlTipoVacante" InitialValue="-1" Display="None" ErrorMessage="La vacante es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceTipoVacante" runat="server" TargetControlID="rfvTipoVacante" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Nombramiento:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlTipoNombramiento" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTipoNombramiento" runat="server" ControlToValidate="ddlTipoNombramiento" InitialValue="-1" Display="None" ErrorMessage="El tipo de nombramiento es requerido" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceTipoNombramiento" runat="server" TargetControlID="rfvTipoNombramiento" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <table style="width: 95%; margin: 0 auto;" cellspacing="4">
                                    <tr>
                                        <td style="text-align: right; width: 33%;">Categoría:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlTipoCategoria" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTipoCategoria" runat="server" ControlToValidate="ddlTipoCategoria" InitialValue="-1" Display="None" ErrorMessage="La categoría es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceTipoCategoria" runat="server" TargetControlID="rfvTipoCategoria" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Clave presupuestal:</td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtClavePresupuestal" runat="server" Width="97%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvClavePresupuestal" runat="server" ControlToValidate="txtClavePresupuestal" Display="None" ErrorMessage="La clave presupuestal es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceClavePresupuestal" runat="server" TargetControlID="rfvClavePresupuestal" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Fecha de asignación:</td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtFechaAsignacion" runat="server" Enabled="false"></asp:TextBox>
                                            <img id="fecha_asignacion" alt="" src="../Imagenes/calendario.png" />
                                            <asp:CalendarExtender ID="ceFechaAsignacion" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaAsignacion" PopupButtonID="fecha_asignacion"></asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="rfvFechaAsignacion" runat="server" ControlToValidate="txtFechaAsignacion" Display="None" ErrorMessage="La fecha de asignación es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceFechaAsignacion" runat="server" TargetControlID="rfvFechaAsignacion" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Entidad de origen:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlEntidadOrigen" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvEntidadOrigen" runat="server" ControlToValidate="ddlEntidadOrigen" Display="None" InitialValue="-1" ErrorMessage="La entidad de origen es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceEntidadOrigen" runat="server" TargetControlID="rfvEntidadOrigen" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Aprobó la Evaluación de Inducción:</td>
                                        <td style="text-align: left;">
                                            <asp:RadioButtonList ID="rblAproboEvaluacionInduccion" runat="server" RepeatDirection="Horizontal" Width="50%">
                                                <asp:ListItem Text="Si" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Denominación de la plaza:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlDenominacionPlaza" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvDenominacionPlaza" runat="server" ControlToValidate="ddlDenominacionPlaza" Display="None" InitialValue="-1" ErrorMessage="La denominación de la plaza es requerida" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceDenominacionPlaza" runat="server" TargetControlID="rfvDenominacionPlaza" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Tipo de plaza:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList id="ddlTipoPlaza" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvTipoPlaza" runat="server" ControlToValidate="ddlTipoPlaza" Display="None" InitialValue="-1" ErrorMessage="El tipo de plaza es requerido" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceTipoPlaza" runat="server" TargetControlID="rfvTipoPlaza" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlHoras" runat="server" Visible="true">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="text-align: right; width: 33%;">Horas:</td>
                                                        <td style="text-align: left;"><asp:TextBox ID="txtHoras" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">Estatus de asignación:</td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlEstatusAsignacion" runat="server" Width="97%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvEstatusAsignacion" runat="server" ControlToValidate="ddlEstatusAsignacion" Display="None" InitialValue="-1" ErrorMessage="El estatus de asignación es requerido" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="vceEstatusAsignacion" runat="server" TargetControlID="rfvEstatusAsignacion" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlMotivo" runat="server" Visible="false">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="text-align: right; width: 33%;">Motivo de rechazo:</td>
                                                        <td style="text-align: left;">
                                                            <asp:DropDownList ID="ddlMotivoRechazo" runat="server" Width="97%"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvMotivoRechazo" runat="server" ControlToValidate="ddlMotivoRechazo" Display="None" InitialValue="-1" ErrorMessage="El estatus de asignación es requerido" ValidationGroup="grp_asignacion"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="vceMotivoRechazo" runat="server" TargetControlID="rfvMotivoRechazo" PopupPosition="TopLeft"></asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="grp_asignacion" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
