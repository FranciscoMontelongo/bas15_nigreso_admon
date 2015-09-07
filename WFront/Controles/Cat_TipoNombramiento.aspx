<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cat_TipoNombramiento.aspx.cs"
    Inherits="WFront.Cat_TipoNombramiento" StylesheetTheme="Asignacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <div style="font-family: Verdana; margin: 10px; color: #999;" class="style1">
            <strong style="text-align: center">Tipo de Nombramiento</strong></div>
        <asp:UpdatePanel ID="updPanel" runat="server">
            <ContentTemplate>
                <div id="dvRep">
                    <asp:GridView ID="gvReporte" runat="server" AllowPaging="false" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt">
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </center>
</body>
</html>
