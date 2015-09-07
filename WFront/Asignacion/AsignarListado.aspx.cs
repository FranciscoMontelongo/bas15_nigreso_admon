using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WFront.Asignacion
{
    public partial class AsignarListado : System.Web.UI.Page
    {
        Negocio.Ent_Usuario _Ent_Usuario;
        private Controles.FiltrosArg Filtros { get { return (Controles.FiltrosArg)Session["FiltrosAsignacionLista"]; } set { Session["FiltrosAsignacionLista"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            wucFiltros1.Buscar += new EventHandler<Controles.FiltrosArg>(wucFiltros1_Buscar);
            _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
            if (!IsPostBack)
            {

            }
        }

        protected void wucFiltros1_Buscar(object sender, WFront.Controles.FiltrosArg e)
        {
            this.Filtros = e;
            CargarGridView(e);
        }

        private void CargarGridView(Controles.FiltrosArg e, int pagina = 0)
        {
            if (Validar_Usuario(_Ent_Usuario, e.Entidad_Federativa) == true)
            {
                Negocio.AsignacionListas _nCargarDatos = new Negocio.AsignacionListas();
                _nCargarDatos.Proc = Negocio.AsignacionListas.Procedimientos.spt_SEL_AsignacionPorEstatus;

                _nCargarDatos.Filtros.Entidad_Federativa = e.Entidad_Federativa;
                _nCargarDatos.Filtros.Funcion = e.Funcion;
                _nCargarDatos.Filtros.Tipo_Evaluacion = e.Tipo_Evaluacion;
                _nCargarDatos.Filtros.Servicio = e.Servicio;
                _nCargarDatos.Filtros.Tipo_Sostenimiento = e.Tipo_Sostenimiento;
                _nCargarDatos.Filtros.ClaveEstatusAsignacion = e.ClaveEstatusAsignacion;
                _nCargarDatos.Busqueda();

                if (_nCargarDatos.datos != null)
                {
                    var datos = _nCargarDatos.datos.Tables[0];

                    gvDatosAsignacion.PageIndex = pagina;
                    gvDatosAsignacion.DataSource = datos;
                    gvDatosAsignacion.DataBind();
                }
                else
                {
                    gvDatosAsignacion.PageIndex = pagina;
                    gvDatosAsignacion.DataSource = null;
                    gvDatosAsignacion.DataBind();
                }
            }
            else
            {
                gvDatosAsignacion.PageIndex = pagina;
                gvDatosAsignacion.DataSource = null;
                gvDatosAsignacion.DataBind();
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

        protected void gvDatosAsignacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarGridView(this.Filtros, e.NewPageIndex);
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            int IdResultados = int.Parse(((LinkButton)sender).CommandArgument);
            /*
             * Buscamos y validamos que el registro tenga o no los antecedentes
             * 
             */


        }
    }
}