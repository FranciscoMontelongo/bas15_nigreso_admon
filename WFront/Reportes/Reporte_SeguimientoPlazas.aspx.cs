using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using Negocio;

namespace WFront.Reportes
{
    public partial class Reporte_Asignaciones : System.Web.UI.Page
    {
        Negocio.Ent_Usuario _Ent_Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
            if (!IsPostBack)
            {

            }
            wucFiltros1.Buscar += new EventHandler<Controles.FiltrosArg>(wucFiltros1_Buscar);
            //wucFiltros1.Exportar += new EventHandler<Controles.FiltrosArg>(wucFiltros1_Exportar);
        }

        protected void wucFiltros1_Buscar(object sender, WFront.Controles.FiltrosArg e)
        {
            Negocio.Ent_Usuario _Ent_Usuario = new Negocio.Ent_Usuario();
            if (Validar_Usuario(_Ent_Usuario, _Ent_Usuario.ClaveEntidad) == true)
            {
                _Ent_Usuario.Funcion = e.Funcion;
                _Ent_Usuario.TipoEvaluacion = e.Tipo_Evaluacion;
                _Ent_Usuario.Servicio = e.Servicio;
                _Ent_Usuario.ClaveEntidad = e.ClaveEntidad.ToString();
                _Ent_Usuario.TipoSostenimiento = e.Tipo_Sostenimiento;
                _Ent_Usuario.ClaveEstatusAsignacion = e.ClaveEstatusAsignacion;
                Buscar(_Ent_Usuario);
                Session["Info_User"] = _Ent_Usuario;
            }
            else
            {
                gvReporte.Visible = false;
                lblMensaje.Visible = true;
            }
        }
        void wucFiltros1_Exportar(object sender, Controles.FiltrosArg e)
        {
            btn_Exportar_Click(null, null);
        }


        protected void gvReporte_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReporte.PageIndex = e.NewPageIndex;
            Negocio.Ent_Usuario _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
            Buscar(_Ent_Usuario);
        }

        private void Buscar(Ent_Usuario _Ent_Usuario)
        {
            if (Validar_Usuario(_Ent_Usuario, _Ent_Usuario.ClaveEntidad) == true)
            {
                try
                {
                    Negocio.Reportes rep = new Negocio.Reportes();
                    rep._Ent_Usuario = new ReportesArg { _Ent_Usuario = _Ent_Usuario };
                    rep.Proc = Negocio.Reportes.Procedimientos.spt_Asignacion_SEL_Reporte_De_Asignaciones;
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
            else
            {
                gvReporte.Visible = false;
                lblMensaje.Visible = true;
            }
        }
        private bool Validar_Usuario(Ent_Usuario _Ent_Usuario, string Entidad_Validar)
        {
            switch (_Ent_Usuario.Perfil)
            {
                case "A":
                    if (_Ent_Usuario.Usuario_Entidad != Entidad_Validar)
                    {
                        new WebNegocio.Utils().Mensaje(this.Page, "Su nivel de usuario no le permite hacer consultas en otras entidades.");
                        return false;
                    }
                    break;
            }
            return true;
        }

        protected void gvReporte_RowDataBound(object o, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //    switch (int.Parse(ddlEstatusAsignacion.SelectedValue.ToString()))
            //    {
            //        case 3:
            //            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //            e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Right;
            //            e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Right;
            //            e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Right;
            //            e.Row.Cells[20].HorizontalAlign = HorizontalAlign.Right;
            //            break;
            //        case 1:
            //            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //            break;
            //        case 4:
            //            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            //            break;
            //    }
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


                    Negocio.Ent_Usuario _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
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
    }
}