using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WFront.Configuracion
{
    public partial class Configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ent_Usuario _Ent_UsuarioValidacion = (Ent_Usuario)Session["Info_User"];
                if (_Ent_UsuarioValidacion.Perfil == "I" || _Ent_UsuarioValidacion.Perfil == "O")
                {
                    Get_Info();   
                }
                else
                {
                    Response.Redirect("~/TableroC/Resumen.aspx");
                }
            }
        }

        private void Get_Info()
        {
            try
            {
                Negocio.Otros _nCargarDatos = new Negocio.Otros();
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_AsignacionFechasXEntidad;
                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    gvFechaContratacion.DataSource = null;
                    gvFechaContratacion.DataBind();
                    gvFechaContratacion.DataSource = _nCargarDatos.datos.Tables[0];
                    gvFechaContratacion.DataBind();
                }
            }
            catch
            {

            }
        }


        protected void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_ActualizaFechasXEntidad;
            _nCargarDatos.Entidad = Convert.ToInt32(hidEntidad.Value);
            _nCargarDatos.FechaIni = Convert.ToDateTime(FechaIni.SelectedDate);
            _nCargarDatos.FechaFin = Convert.ToDateTime(FechaFin.SelectedDate);
            _nCargarDatos.GuardaInformacion();


            Get_Info();
            lbl_Mensaje.Text = "La información para la entidad: " + spnEntidad.InnerText + " ha sido actualizada.";
            LimpiarControles();
            FechaIni.SelectedDate = DateTime.Now.Date;
            FechaFin.SelectedDate = DateTime.Now.Date;
            DivFechas.Visible = false;
            lbl_Mensaje.Visible = true;





        }

        protected void btn_Cerrar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DivFechas.Visible = false;
        }

        protected void btn_Editar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string[] arg = new string[3];

                ImageButton ImgButton = (ImageButton)sender;
                arg = ImgButton.CommandArgument.ToString().Split('|');

                hidEntidad.Value = arg[0].ToString();
                spnEntidad.InnerText = arg[1].ToString();
                IdEntidad.Visible = true;
                FechaIni.SelectedDate = Convert.ToDateTime(arg[2]);
                FechaFin.SelectedDate = Convert.ToDateTime(arg[3]);
                DivFechas.Visible = true;
                lbl_Mensaje.Visible = false;
            }
            catch (Exception ex)
            {

            }


        }

        protected void gvFechaContratacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Ent_Usuario _Ent_Usuario = new Ent_Usuario();
            //_Ent_Usuario.ds = _Config_FechaContratacion.ConfiguracionFechas();
            //gvFechaContratacion.DataSource = _Ent_Usuario.ds.Tables[0];
            //gvFechaContratacion.PageIndex = e.NewPageIndex;
            //gvFechaContratacion.DataBind();
        }

        protected void gvFechaContratacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton ImgButton = (ImageButton)e.Row.FindControl("btn_Editar");
        }


        protected void gvFechaContratacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow fila = gvFechaContratacion.SelectedRow;
            //hidDescripcion.Value = fila.Cells[1].Text.ToString();
            //hidFechaIni.Value = fila.Cells[2].Text.ToString();
            //hidFechaFin.Value = fila.Cells[3].Text.ToString();
        }

        protected void LimpiarControles()
        {
            hidEntidad.Value = "0";
            spnEntidad.InnerText = "";
            IdEntidad.Visible = false;
            FechaIni.Text = string.Empty;
            FechaFin.Text = string.Empty;
        }
    }
}