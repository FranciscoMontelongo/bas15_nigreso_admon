<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlazaAntecedente.aspx.cs" Inherits="WFront.Asignacion.PlazaAntecedente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script>
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
        }  
    </script>
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
                    <asp:Label ID="txtCURP" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    Estatus Actual ::
                </td>
                <td align="left" class="style2" colspan="2">
                    <asp:Label ID="lblEstatus" runat="server" CssClass="ItemCol"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td align="right" class="style3">
                    <%--Centro de Trabajo ::--%>
                </td>
                <td align="left" class="style2" colspan="2">
                    <%--<asp:Label ID="lblAsignatura" runat="server" CssClass="ItemCol"></asp:Label>--%>
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
        </table>
        <table>
            <tr>
                <td align="right" class="style3">
                    Clave del Centro de Trabajo 
                    de antecedente::
                </td>
                <td align="left" colspan="2" class="style2">
                    <asp:TextBox ID="txtCCT" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right"  class="style2">
                    Nombre Centro de Trabajo de antecedente ::
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDescripcionCCT" runat="server" Width="250px"></asp:TextBox>
                    <%--<asp:DropDownList ID="cboAsignatura" runat="server" Width="200px">
                    </asp:DropDownList>--%>
                </td>
                
            </tr>
            <tr>
                <td align="right" class="style3">
                    Tipo Plaza ::
                </td>
                <td align="left" class="style2">
                    <asp:DropDownList ID="cboTipoPlaza" runat="server" Width="250px" AutoPostBack="True"
                        OnSelectedIndexChanged="cboTipoPlaza_SelectedIndexChanged" Height="16px">
                    </asp:DropDownList>
                </td>
               
            </tr>
            <tr id="horas" runat="server">
                <td align="right" class="style4">
                    &nbsp;Número de horas ::
                </td>
                <td align="left" class="style4">
                   <asp:TextBox ID="txtHoras" runat="server" Width="250px" onkeypress="return numbersonly(event);"></asp:TextBox>
                    
                </td>
                

            </tr>
            <tr>
                <td align="right" class="style4">
                    Clave de la plaza de antecedente ::
                </td>
                <td align="left" class="style5">
                      <%--<asp:TextBox ID="txtClavePlaza" runat="server" Width="250px"></asp:TextBox>--%>
                      <asp:DropDownList ID = "ddlTipoCategoria" runat = "server" OnSelectedIndexChanged = "ddlTipoCategoria_SelectedIndexChanged" AutoPostBack = "true">
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
                <td align="right" class="style4">
                   <%-- Generar Folio ::--%>
                    Denominación de la plaza de antecedente ::
                </td>
                <td align="left">
                    <%--<asp:TextBox ID="txtDenominacion" runat="server" Width="250px"></asp:TextBox>--%>
                    <asp:DropDownList ID = "ddlDenominacionPlaza" runat = "server">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    Clave presupuestal ::&nbsp;
                </td>
                <td align="left" class="style5">
                   <asp:TextBox ID="txtClavePresupuestal" runat="server" Width="250px"></asp:TextBox>
                    
                </td>
               
            </tr>
            <tr>
                <td align="right" class="style4">
                    Nivel de carrera magisterial ::&nbsp;
                </td>
                <td align="left" class="style5">
                   <asp:DropDownList ID="cboNivelCarrera" runat="server" Width="250px" AutoPostBack="True" Height="16px">
                    </asp:DropDownList>
                
                    
                </td>
               
            </tr>
            </table>
            <table width="40%">
            <tr>
             <td align="center" class="style4">
                    <br /><asp:Button ID="btnGuardar" runat="server" BackColor="#CF242A" CssClass="button"
                        Font-Size="8pt" Height="23px" Text="Guardar" Width="102px" 
                        onclick="btnGuardar_Click" />
                </td>
                <td align="center" class="style4">
                    <br /><asp:Button ID="btnActualizar" runat="server" BackColor="#CF242A" CssClass="button"
                        Font-Size="8pt" Height="23px" OnClick="btnActualizar_Click" Text="Siguiente"
                        Width="102px" Visible = "false" />
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
            <table>
            <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="grNombramientos" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" GridLines="None"
                        AllowPaging="True" Font-Size="8pt" OnSelectedIndexChanged="grNombramientos_SelectedIndexChanged"
                        OnRowDeleting="grNombramientos_RowDeleting" 
                    OnRowDataBound="grNombramientos_RowDataBound" 
                    onpageindexchanging="grNombramientos_PageIndexChanging">
                        <AlternatingRowStyle CssClass="alt" Font-Size="8pt"></AlternatingRowStyle>
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />                            
                            <asp:BoundField DataField="ID Antecedente" HeaderText="ID Antecedente"/>
                            <asp:BoundField DataField="CURP" HeaderText="CURP" />
                            <asp:BoundField DataField="CCT" HeaderText="CCT" />
                            <asp:BoundField DataField="Nombre CCT" HeaderText="Nombre CCT" />
                            <asp:BoundField DataField="Tipo de Plaza" HeaderText="Tipo de Plaza" />
                            <asp:BoundField DataField="Horas" HeaderText="Número de Horas" />
                            <asp:BoundField DataField="Clave o Categoria" HeaderText="Clave de Categoría" />
                            <asp:BoundField DataField="Denominacion de Plaza" HeaderText="Denominacion de Plaza" />
                            <asp:BoundField DataField="ClavePresupuestal" HeaderText="Clave Presupuestal" />
                            <asp:BoundField DataField="Carrera Magisterial" HeaderText="Carrera Magisterial" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
