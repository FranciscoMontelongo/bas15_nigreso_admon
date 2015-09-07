using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using WFront.Common;
using Negocio;

namespace WFront.Controles
{
    public partial class wucFiltros : System.Web.UI.UserControl
    {
        [Browsable(true)]
        public event EventHandler<FiltrosArg> Buscar;
        //[Browsable(true)]
        //public event EventHandler<FiltrosArg> Exportar;

        //[Browsable(true)]
        //public bool Ver_btnExportar { get { return (bool)ViewState["Ver_btnExportar"]; } set { ViewState["Ver_btnExportar"] = btnExportar.Visible = value; } }


        Negocio.Ent_Usuario _Ent_Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
            if (!IsPostBack)
            {
                CargarCombos();
            }
        }

        #region SelectedIndexChanged Drops Event
        protected void ddlFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string funcion = ddlFuncion.SelectedValue.Trim();
            ddlTipo_Evaluacion.LoadData(GetTipo_Evaluacion(funcion), true);

            CargaServicio(funcion, "-1");
            ddlEstatusAsignacion.ClearSelection();
            ddlEntidad_Federativa.LoadData(GetEntidades(funcion, "-1", "-1"), true);
            ddlTipo_Sostenimiento.LoadData(GetTipo_Sostenimiento(funcion, "-1", "-1", "-1"), true);
        }
        protected void ddlTipo_Evaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string funcion = ddlFuncion.SelectedValue.Trim();
            string tipo_evaluacion = ddlTipo_Evaluacion.SelectedValue.Trim();

            CargaServicio(funcion, tipo_evaluacion);

            ddlEstatusAsignacion.ClearSelection();
            ddlEntidad_Federativa.LoadData(GetEntidades(funcion, tipo_evaluacion, "-1"), true);
            ddlTipo_Sostenimiento.LoadData(GetTipo_Sostenimiento(funcion, tipo_evaluacion, "-1", "-1"), true);
        }
        protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string funcion = ddlFuncion.SelectedValue.Trim();
            string tipo_evaluacion = ddlTipo_Evaluacion.SelectedValue.Trim();
            string servicio = ddlServicio.SelectedValue.Trim();

            ddlEstatusAsignacion.ClearSelection();
            ddlEntidad_Federativa.LoadData(GetEntidades(funcion, tipo_evaluacion, servicio), true);
            ddlTipo_Sostenimiento.LoadData(GetTipo_Sostenimiento(funcion, tipo_evaluacion, servicio, "-1"), true);
        }
        protected void ddlEntidad_Federativa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string funcion = ddlFuncion.SelectedValue.Trim();
            string tipo_evaluacion = ddlTipo_Evaluacion.SelectedValue.Trim();
            string servicio = ddlServicio.SelectedValue.Trim();
            string entidad = ddlEntidad_Federativa.SelectedItem.Text.Trim();

            ddlEstatusAsignacion.ClearSelection();
            ddlTipo_Sostenimiento.LoadData(GetTipo_Sostenimiento(funcion, tipo_evaluacion, servicio, entidad), true);
        }
        protected void ddlEstatusAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFuncion.SelectedValue != "-1" &&
                ddlTipo_Evaluacion.SelectedValue != "-1" &&
                (
                    ddlServicio.SelectedValue != "-1" && ddlServicio.Visible ||
                    ddlServicio.SelectedValue == "-1" && !ddlServicio.Visible 
                ) &&
                ddlEntidad_Federativa.SelectedValue != "-1")
            {
                btnConsultar_Click(null, null);
            }
        }
        #endregion

        #region Métodos privados
        private void CargarCombos()
        {
            ddlFuncion.LoadData(GetFunciones(), true);
            ddlTipo_Evaluacion.LoadData(GetTipo_Evaluacion("-1"), true);
            CargaServicio("-1", "-1");
            ddlEntidad_Federativa.LoadData(GetEntidades("-1", "-1", "-1"), true);
            ddlTipo_Sostenimiento.LoadData(GetTipo_Sostenimiento("-1", "-1", "-1", "-1"), true);
            ddlEstatusAsignacion.LoadData(GetEstatusAsignacion(), true);
        }
        private void CargaServicio(string funcion, string tipo_evaluacion)
        {
            var Servicios = GetServicio(funcion, tipo_evaluacion);
            if (Servicios.Count() > 0)
            {
                lblServicio.Visible = ddlServicio.Visible = true;
                rfvServicio.Enabled = vceServicio.Enabled = true;

                ddlServicio.LoadData(Servicios, true);
            }
            else
            {
                lblServicio.Visible = ddlServicio.Visible = false;
                rfvServicio.Enabled = vceServicio.Enabled = false;
                ddlServicio.LoadData(Servicios, true);
            }
        }
        private FiltrosArg ObtenerFiltro()
        {
            FiltrosArg fa = new FiltrosArg();

            fa.Entidad_Federativa = ddlEntidad_Federativa.SelectedItem.Text.Trim();
            fa.ClaveEntidad = int.Parse(ddlEntidad_Federativa.SelectedValue.Trim());
            fa.Funcion = ddlFuncion.SelectedValue.Trim();
            fa.Tipo_Evaluacion = ddlTipo_Evaluacion.SelectedValue.Trim();
            fa.Servicio = ddlServicio.SelectedValue.Trim();
            fa.Tipo_Sostenimiento = ddlTipo_Sostenimiento.SelectedValue.Trim();
            fa.ClaveEstatusAsignacion = int.Parse(ddlEstatusAsignacion.SelectedValue);

            return fa;
        } 
        #endregion

        #region Obtención de Datos
        private IEnumerable<ListItem> GetFunciones()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneFunciones;
            _Filtro.Filtros.Funcion = "";
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("Funcion", "Funcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTipo_Evaluacion(string Funcion)
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipo_Evaluacion;
            _Filtro.Filtros.Funcion = Funcion;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("Tipo_Evaluacion", "Tipo_Evaluacion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetServicio(string Funcion, string Tipo_Evaluacion)
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneResultadosServicios;
            _Filtro.Filtros.Funcion = Funcion;
            _Filtro.Filtros.Tipo_Evaluacion = Tipo_Evaluacion;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("Servicio", "Servicio");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetEntidades(string Funcion, string Tipo_Evaluacion, string Servicio)
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneEntidad_Federativa;
            _Filtro.Filtros.Funcion = Funcion;
            _Filtro.Filtros.Tipo_Evaluacion = Tipo_Evaluacion;
            _Filtro.Filtros.Servicio = Servicio;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("Clave_Entidad", "Entidad_Federativa");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTipo_Sostenimiento(string Funcion, string Tipo_Evaluacion, string Servicio, string Entidad_Federativa)
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipo_Sostenimiento;
            _Filtro.Filtros.Funcion = Funcion;
            _Filtro.Filtros.Tipo_Evaluacion = Tipo_Evaluacion;
            _Filtro.Filtros.Servicio = Servicio;
            _Filtro.Filtros.Entidad_Federativa = Entidad_Federativa;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("Tipo_Sostenimiento", "Tipo_Sostenimiento");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetEstatusAsignacion()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Asignacion _Filtro = new Negocio.Asignacion();
            _Filtro.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_SEL_Todos_AsignacionEstatus;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems(_Filtro.datos.Tables[0].Columns[0].Caption.ToString(), _Filtro.datos.Tables[0].Columns[1].Caption.ToString());
            }
            return Result;
        }
        #endregion

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            OnBuscar(this, ObtenerFiltro());
        }
        
        //protected void btnExportar_Click(object sender, EventArgs e)
        //{
        //    OnExportar(this, ObtenerFiltro());
        //}
        
        #region EventHandlers
        public virtual void OnBuscar(object sender, FiltrosArg e)
        {
            EventHandler<FiltrosArg> handler = Buscar;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        //public virtual void OnExportar(object sender, FiltrosArg e)
        //{
        //    EventHandler<FiltrosArg> handler = Exportar;
        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}
        #endregion
    }

    public class FiltrosArg : EventArgs
    {
        public string Funcion { get; set; }
        public int ClaveEntidad { get; set; }
        public string Tipo_Evaluacion { get; set; }
        public string Servicio { get; set; }
        public string Entidad_Federativa { get; set; }
        public string Tipo_Sostenimiento { get; set; }
        public int ClaveEstatusAsignacion { get; set; }
    }
}