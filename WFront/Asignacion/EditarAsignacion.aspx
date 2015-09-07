<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarAsignacion.aspx.cs"
    Inherits="WFront.Asignacion.EditarAsignacion" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            height: 18px;
        }
        .style5
        {
            height: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="width: 90%;">
            <tr>
                <td align="right" class="style3">
                    &nbsp;
                </td>
                <td align="left" class="style2">
                    &nbsp;
                </td>
                <td align="left" class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    Nombre ::
                </td>
                <td align="left" class="style2" colspan="2">
                    <asp:Label ID="lblNombre" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
                <td align="left">
                    CURP ::
                    <asp:Label ID="lblCURP" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    Estatus Actual ::
                </td>
                <td align="left" class="style2" colspan="2">
                    <asp:Label ID="lblEstatus" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
                <td align="left">
                    Folio Federal ::
                    <asp:Label ID="lblFolioFed" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    Cargo :
                </td>
                <td align="left" class="style2" colspan="2">
                    <asp:Label ID="lblCargo" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblProv" runat="server" CssClass="ItemCol" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    &nbsp;
                </td>
                <td align="left" class="style2" colspan="2">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    &nbsp;
                </td>
                <td align="left" class="style2" colspan="2">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="4">
                    <asp:GridView ID="grNombramientos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="True" Font-Size="8pt" OnSelectedIndexChanged="grNombramientos_SelectedIndexChanged"
                        OnRowDeleting="grNombramientos_RowDeleting" OnRowDataBound="grNombramientos_RowDataBound">
                        <AlternatingRowStyle CssClass="alt" Font-Size="8pt"></AlternatingRowStyle>
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="Clave" />
                            <asp:BoundField DataField="CLAVECCT" HeaderText="Clave centro de trabajo" />
                            <asp:BoundField DataField="DESCRIPCIONCCT" HeaderText="Centro de trabajo" />
                            <asp:BoundField DataField="EFECTOSNOMBRAMIENTOS" HeaderText="Nombramiento" />
                            <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                            <asp:BoundField DataField="CLAVEPRESUPUESTAL" HeaderText="Clave presupuestal" />
                            <asp:BoundField DataField="DescripcionTurno" HeaderText="Turno" />
                            <asp:BoundField DataField="DescripcionAsigancionEstatus" HeaderText="Estatus" />
                            <asp:BoundField DataField="DescripcionAsignacionNombramiento" HeaderText="Tipo Asignación" />
                            <asp:BoundField DataField="TipoRechazo" HeaderText="Tipo rechazo" />
                            <asp:BoundField DataField="FolioGenerado" HeaderText="Folio Generado" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    &nbsp;
                </td>
                <td align="left" class="style2" colspan="2">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    &nbsp;
                </td>
                <td align="left" class="style2" colspan="2">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style1" colspan="4" style="border-color: #cf242A; border-bottom-style: solid;
                    border-width: thin; font-size: 1px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    Clave del Centro de Trabajo::
                </td>
                <td align="left" class="style2">
                    <asp:TextBox ID="txtCCT" runat="server" Width="197px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    Nombre Centro de Trabajo ::
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDescripcionCCT" runat="server" Width="197px"></asp:TextBox>
                    <%--<asp:DropDownList ID="cboAsignatura" runat="server" Width="200px">
                    </asp:DropDownList>--%>
                </td>
                <td align="right" class="style2">
                    Efectos del Nombramiento :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEfectoNom" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    Tipo Plaza ::
                </td>
                <td align="left" class="style2">
                    <asp:DropDownList ID="cboTipoPlaza" runat="server" Width="200px" AutoPostBack="True"
                        OnSelectedIndexChanged="cboTipoPlaza_SelectedIndexChanged" Height="16px">
                    </asp:DropDownList>
                </td>
                <td align="right" class="style5">
                    Plaza (clave presupuestal) ::
                </td>
                <td class="style5" align="left">
                    <asp:TextBox ID="txtClavePrep" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    Turno ::
                </td>
                <td align="left" class="style4">
                    <asp:DropDownList ID="cboTurno" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td align="right" class="style4">
                    Estatus Asignación ::
                </td>
                <td class="style4" align="left">
                    <asp:DropDownList ID="cboNEstatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboNEstatus_SelectedIndexChanged"
                        Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    Tipo de Nombramiento ::
                </td>
                <td align="left" class="style5">
                    <asp:DropDownList ID="cboNombramiento" runat="server" Width="200px" AutoPostBack="true"
                        OnSelectedIndexChanged="cboNombramiento_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" class="style5">
                    <asp:Label ID="Label1" runat="server" Text="Estatus de Rechazo ::"></asp:Label>
                </td>
                <td class="style5" align="left">
                    <asp:DropDownList ID="cboEstatFinal" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- <tr>
                <td colspan="4">
                    <table runat="server" id="TablaFechasInicioTermino" width="100%" style="display: none">
                        <tr>
                            <td class="style4">
                                Fecha de inicio
                            </td>
                            <td class="style5" align="left">
                                <asp:TextBox ID="txtFechaInicio" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                Fecha de termino
                            </td>
                            <td class="style5" align="left">
                                <asp:TextBox ID="txtFechaTermino" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td align="right" runat="server" id="FechaInicio" visible="false">
                    Fecha Inicio :
                </td>
                <td align="left">
                    <ew:CalendarPopup ID="tb_StartDate" runat="server" Visible="false" ControlDisplay="TextBoxImage"
                        ImageUrl="~/Imagenes/calendar.PNG" Nullable="True" ShowGoToToday="True" />
                </td>
                <td align="right" runat="server" id="FechaTermino" visible="false">
                    Fecha Termino :
                </td>
                <td align="left">
                    <ew:CalendarPopup ID="tb_EndDate" runat="server" ControlDisplay="TextBoxImage" Visible="false"
                        ImageUrl="~/Imagenes/calendar.PNG" Nullable="True" ShowGoToToday="True" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    <asp:Label ID="lblFOlio" Text="Generar Folio ::" runat="server" Visible="false" />
                </td>
                <td align="left">
                    <asp:CheckBox ID="ckbGenerarFolio" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    &nbsp;
                </td>
                <td align="left" class="style5">
                    &nbsp;
                </td>
                <td align="right" class="style5">
                    &nbsp;
                </td>
                <td class="style5" align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style4" colspan="4">
                    <asp:Button ID="btnActualizar" runat="server" BackColor="#CF242A" CssClass="button"
                        Font-Size="8pt" Height="23px" OnClick="btnActualizar_Click" Text="Actualizar"
                        Width="102px" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td align="right" class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
