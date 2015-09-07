<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Firmas.aspx.cs" Inherits="WFront.Asignacion.Firmas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/btnStyle.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styleGrid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/themes/blitzer/jquery-ui.css" />
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 562px;
        }
        .style3
        {
            height: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
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
                <table style="width: 90%;">
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="Entidad ::"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cboEntidades" runat="server" AutoPostBack="True" Width="350px"
                                OnSelectedIndexChanged="cboEntidades_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Subsistema ::"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cboSubSistemas" runat="server" Width="350px" 
                                AutoPostBack="true" 
                                onselectedindexchanged="cboSubSistemas_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style3" colspan="2">
                            Folio ::
                        </td>
                        <td align="left" class="style3">
                            <asp:DropDownList ID="cboFolios" runat="server" Height="21px" Width="180px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style3" colspan="2">
                            &nbsp;
                        </td>
                        <td align="left" class="style3">
                            &nbsp;
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnGenerar" runat="server" BackColor="#CF242A" CssClass="button"
                                Font-Size="8pt" Height="23px" Text="Consultar" Width="102px" 
                                onclick="btnGenerar_Click" />
                            <asp:Button ID="btnFirmas" runat="server" BackColor="#CF242A" CssClass="button" Font-Size="8pt"
                                Height="23px" Text="Aplicar Firmas" Width="102px" 
                                onclick="btnFirmas_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center" class="style1" colspan="2">
                            <asp:GridView ID="grDatos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" GridLines="None"
                                AllowPaging="True" EmptyDataText="Sin datos para mostrar."
                                Font-Size="8pt" DataKeyNames="curp,FOLIOGENERADO,CLAVESUBSISTEMA">
                                <AlternatingRowStyle CssClass="alt" Font-Size="8pt"></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="curp" HeaderText="CURP" />
                                    <asp:BoundField DataField="foliofeder" HeaderText="Folio Federal" />
                                    <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                                    <asp:BoundField DataField="DESCRIPCIONCCT" HeaderText="Centro de Trabajo" />
                                    <asp:BoundField DataField="TipoNom" HeaderText="Tipo Nombramiento" />
                                    <asp:TemplateField HeaderText="Firmar" Visible="True">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkFirma" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Firma").ToString() == "1" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pgr"></PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hndEditable" runat="server" />
                <asp:HiddenField ID="hndTipoNom" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
