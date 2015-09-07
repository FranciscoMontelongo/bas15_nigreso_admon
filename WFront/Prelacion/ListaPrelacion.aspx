<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPrelacion.aspx.cs"
    Inherits="WFront.Prelacion.ListaPrelacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/MenuStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 641px;
        }
        .style2
        {
            height: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
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
                        Lista ::
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboPrelacion" runat="server" AutoPostBack="True" Width="350px"
                            OnSelectedIndexChanged="cboPrelacion_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="font-size: 12px">
                        Entidad ::
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboEntidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboEntidades_SelectedIndexChanged"
                            Width="350px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="font-size: 12px">
                        Subsistema ::
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboSubSistemas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboSubSistemas_SelectedIndexChanged"
                            Width="350px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="font-size: 12px">
                        <asp:Label ID="lblCCT" runat="server" Text="  CCT ::"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCCT" runat="server" Width="350px" AutoPostBack="true" OnSelectedIndexChanged="ddlCCT_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="font-size: 12px">
                        Cargo ::
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCargo" runat="server" Width="350px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="font-size: 12px" class="style2">
                        &nbsp;
                    </td>
                    <td align="left" class="style2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style1" align="right" style="font-size: 12px">
                        <%--Centro de Trabajo ::--%>
                    </td>
                    <td align="left">
                        <%--<asp:DropDownList ID="cboAsignatura" runat="server" Enabled="False" Height="18px" AutoPostBack="true"
                            Width="350px" onselectedindexchanged="cboAsignatura_SelectedIndexChanged">
                        </asp:DropDownList>--%>
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
                    <td align="center" colspan="3">
                        <asp:GridView ID="grDatos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" GridLines="None"
                            AllowPaging="True" OnPageIndexChanging="grDatos_PageIndexChanging" EmptyDataText="Sin datos para mostrar.">
                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                            <Columns>
                                <asp:BoundField DataField="PRELAC" HeaderText="Orden" />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
                                <asp:BoundField DataField="CURP" HeaderText="CURP" />
                                <asp:BoundField DataField="foliofeder" HeaderText="Folio Federal" />
                                <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                                <asp:BoundField DataField="gpo_desemp" HeaderText="Desempeño" />
                                <asp:BoundField DataField="ClaveEstatusAsignacion" HeaderText="Estatus" />
                            </Columns>
                            <PagerStyle CssClass="pgr"></PagerStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style1">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                        </asp:ScriptManager>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                Cargando ...
                                <img src="../Imagenes/WaitCursor.gif" alt="" style="height: 30px; width: 30px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="Panel">
                            <ContentTemplate>
                                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Style="display: none"
                                    Text="refresh" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
