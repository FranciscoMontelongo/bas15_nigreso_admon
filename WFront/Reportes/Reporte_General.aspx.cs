using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using System.IO;
using System.Drawing;

namespace WFront.Reportes
{
    public partial class Reporte_General : System.Web.UI.Page
    {
        Negocio.Ent_Usuario _Ent_Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
            if (!IsPostBack)
            {
                Llenar_Entidades();
                ddlEntidad.SelectedValue = _Ent_Usuario.Usuario_ClaveEntidad;
                if (_Ent_Usuario.Perfil == "A")
                {
                    ddlEntidad.Enabled = false;
                }
                Buscar(_Ent_Usuario);
            }
        }
        private void Llenar_Entidades()
        {
            Negocio.Reportes rep = new Negocio.Reportes();
            rep.Proc = Negocio.Reportes.Procedimientos.spt_Asignacion_SEL_Entidades;
            rep.Busqueda();

            if (rep.datos != null)
            {
                ListItem li = new ListItem();
                li.Value = "-1";
                li.Text = " -- Todas las Entidades -- ";
                ddlEntidad.Items.Add(li);
                foreach (DataRow dr in rep.datos.Tables[0].Rows)
                {
                    li = new ListItem();
                    li.Value = dr["ClaveEntidad"].ToString();
                    li.Text = dr["Descripcion"].ToString();
                    ddlEntidad.Items.Add(li);
                }
            }
        }


        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            Buscar(_Ent_Usuario);
        }
        private void Buscar(Ent_Usuario _Ent_Usuario)
        {
            try
            {
                _Ent_Usuario.ClaveEntidad = ddlEntidad.SelectedValue;
                Negocio.Reportes rep = new Negocio.Reportes();
                rep._Ent_Usuario = new ReportesArg { _Ent_Usuario = _Ent_Usuario };
                rep.Proc = Negocio.Reportes.Procedimientos.spt_Asignacion_SEL_Reporte_General;
                rep.Busqueda();

                if (rep.datos != null)
                {
                    gvReporte.DataSource = rep.datos;
                    gvReporte.DataBind();
                    gvReporte.Visible = true;
                    lblMensaje.Visible = false;
                }
                else
                {
                    gvReporte.Visible = false;
                    lblMensaje.Visible = true;
                }
            }
            catch
            {
                gvReporte.Visible = false;
                lblMensaje.Visible = true;
            }
        }

        protected void btn_Exportar_Click(object sender, EventArgs e)
        {
            if (gvReporte.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages

                    gvReporte.AllowPaging = false;
                    Buscar(_Ent_Usuario);

                    gvReporte.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvReporte.HeaderRow.Cells)
                    {
                        cell.BackColor = gvReporte.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvReporte.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            //if (row.RowIndex % 2 == 0)
                            //{
                            //    cell.BackColor = gvReporte.AlternatingRowStyle.BackColor;
                            //}
                            //else
                            //{
                            //    cell.BackColor = gvReporte.RowStyle.BackColor;
                            //}
                            cell.CssClass = "textmode";
                        }
                    }

                    gvReporte.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void gvReporte_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReporte.PageIndex = e.NewPageIndex;
            Buscar(_Ent_Usuario);
        }
        protected void ddlEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar(_Ent_Usuario);
        }
    }
}