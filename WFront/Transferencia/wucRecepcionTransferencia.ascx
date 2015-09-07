<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucRecepcionTransferencia.ascx.cs" Inherits="WFront.Transferencia.wucRecepcionTransferencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="wucTransferenciaFiltro.ascx" tagname="wucTransferenciaFiltro" tagprefix="uc1" %>

<%@ Register src="wucRechazoTransferencia.ascx" tagname="wucRechazoTransferencia" tagprefix="uc2" %>

<script type="text/javascript">
    function confirmarTransferencia(msg) {
        return confirm(msg);
    }
</script>

<uc1:wucTransferenciaFiltro ID="wucTransferenciaFiltro1" runat="server" BloquearEntidad="false" />

<asp:UpdatePanel ID="upRecepcion" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="wucTransferenciaFiltro1" EventName="Buscar" />
    </Triggers>
    <ContentTemplate>
        <asp:Accordion ID="acSolicitudes" runat="server" TransitionDuration="200" FadeTransitions="True" FramesPerSecond="50" ContentCssClass="acordion-content" HeaderCssClass="acordion-header">
            <Panes>
                <asp:AccordionPane ID="apPendientes" runat="server">
                    <Header>Pendientes</Header>
                    <Content>
                        <asp:GridView ID="gvNotificacion_Pendientes" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
                            <Columns>
                                <asp:BoundField HeaderText="Folio" DataField="FolioFederal" Visible="false" />
                                <asp:BoundField HeaderText="CURP" DataField="Curp" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Entidad" DataField="Entidad_Destino" />
                                <asp:BoundField HeaderText="Tipo de Convocatoria" DataField="Tipo_Convocatoria_Destino" />
                                <asp:BoundField HeaderText="Tipo de Evaluación" DataField="Tipo_Evaluacion_Destino" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbAceptar" runat="server" CommandArgument='<%# Bind("pkTraspaso") %>' CssClass="lnk-aceptar" OnClick="lnkbAceptar_Click" OnClientClick="return confirmarTransferencia('¿Desea confirmar la transferencia?')" ToolTip="Aceptar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbRechazar" runat="server" CommandArgument='<%# Bind("pkTraspaso") %>' CssClass="lnk-rechazar" OnClick="lnkbRechazar_Click" OnClientClick="return confirmarTransferencia('¿Desea rechazar la transferencia?')" ToolTip="Rechazar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="border: 1px solid #E2E2E2; padding: 20px; font-size: 14pt;">
                                    No se localizaron notificaciones de transferencias pendientes.
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="apAceptados" runat="server">
                    <Header>Aceptados</Header>
                    <Content>
                        <asp:GridView ID="gvNotificacion_Aceptados" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
                            <Columns>
                                <asp:BoundField HeaderText="Folio" DataField="FolioFederal" Visible="false" />
                                <asp:BoundField HeaderText="CURP" DataField="Curp" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Entidad" DataField="Entidad_Destino" />
                                <asp:BoundField HeaderText="Tipo de Convocatoria" DataField="Tipo_Convocatoria_Destino" />
                                <asp:BoundField HeaderText="Tipo de Evaluación" DataField="Tipo_Evaluacion_Destino" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="border: 1px solid #E2E2E2; padding: 20px; font-size: 14pt;">
                                    No se localizaron notificaciones aceptadas.
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="apRechazados" runat="server">
                    <Header>Rechazados</Header>
                    <Content>
                        <asp:GridView ID="gvNotificacion_Rechazados" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
                            <Columns>
                                <asp:BoundField HeaderText="Folio" DataField="FolioFederal" Visible="false" />
                                <asp:BoundField HeaderText="CURP" DataField="Curp" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Entidad" DataField="Entidad_Destino" />
                                <asp:BoundField HeaderText="Tipo de Convocatoria" DataField="Tipo_Convocatoria_Destino" />
                                <asp:BoundField HeaderText="Tipo de Evaluación" DataField="Tipo_Evaluacion_Destino" />
                                <asp:BoundField HeaderText="Motivo" DataField="MotivoRechazo" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="border: 1px solid #E2E2E2; padding: 20px; font-size: 14pt;">
                                    No se localizaron notificaciones rechazadas.
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </ContentTemplate>
</asp:UpdatePanel>


<uc2:wucRechazoTransferencia ID="wucRechazoTransferencia1" runat="server" />



