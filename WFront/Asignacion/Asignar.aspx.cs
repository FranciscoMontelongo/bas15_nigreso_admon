using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocio;
using WFront.Common;


namespace WFront.Asignacion
{
    public partial class Asignar : System.Web.UI.Page
    {
        private Ent_Usuario _Ent_Usuario { get { return (Ent_Usuario)Session["Info_User"]; } }
        private int? ID_AsignacionDetalle { get { return (int?)ViewState["ID_AsignacionDetalle"]; } set { ViewState["ID_AsignacionDetalle"] = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Info_User"] = new Ent_Usuario();
                CargarListados();
                Encabezado();
                CargarAsignaciones();
            }
        }

        private void Encabezado()
        {
            Negocio.AsignacionListas _Asignacion = new Negocio.AsignacionListas();
            _Asignacion.Proc = Negocio.AsignacionListas.Procedimientos.spt_SEL_DocenteResultado;
            _Asignacion.Filtros.id_Resultados = this._Ent_Usuario.id_Resultados = 2287;
            _Asignacion.Busqueda();

            if (_Asignacion.datos != null)
            {
                lblNombre.Text = _Asignacion.datos.Tables[0].Rows[0]["Nombre"].ToString();
                lblCURP.Text = _Asignacion.datos.Tables[0].Rows[0]["curp"].ToString();
                lblEstatus.Text = _Asignacion.datos.Tables[0].Rows[0]["Estatus"].ToString();
                lblFolioFederal.Text = _Asignacion.datos.Tables[0].Rows[0]["FolioFederal"].ToString();
                lblFuncion.Text = _Asignacion.datos.Tables[0].Rows[0]["Funcion"].ToString();
                lblEntidad.Text = _Asignacion.datos.Tables[0].Rows[0]["Entidad_Federativa"].ToString();
                lblServicio.Text = _Asignacion.datos.Tables[0].Rows[0]["Servicio"].ToString();
                lblTipoEvuacion.Text = _Asignacion.datos.Tables[0].Rows[0]["Tipo_Evaluacion"].ToString();
                lblTipoSostenimiento.Text = _Asignacion.datos.Tables[0].Rows[0]["Tipo_Sostenimiento"].ToString();
            }
        }
        private void CargarListados()
        {
            ddlTurno.LoadData(GetTurno(), true);
            ddlVigenciaAdscripcion.LoadData(GetVigenciaAdscripcion(), true);
            ddlTipoVacante.LoadData(GetTipoVacante(), true);
            ddlTipoNombramiento.LoadData(GetTipoNombramiento(), true);
            ddlTipoCategoria.LoadData(GetTipoCategoria(), true);
            ddlEntidadOrigen.LoadData(GetEntidades(), true);
            ddlDenominacionPlaza.LoadData(GetDenominacionPlaza(), true);
            ddlTipoPlaza.LoadData(GetTipoPlaza(), true);
            ddlEstatusAsignacion.LoadData(GetEstatusAsignacion(), true);
        }
        private void CargarAsignaciones(int id_Resultados = 2287)
        {
            Negocio.AsignacionListas _Asignacion = new Negocio.AsignacionListas();
            _Asignacion.Proc = Negocio.AsignacionListas.Procedimientos.spt_SEL_DocenteAsignaciones;
            _Asignacion.Filtros.id_Resultados = id_Resultados;
            _Asignacion.Busqueda();

            if (_Asignacion.datos != null)
            {
                grNombramientos.DataSource = _Asignacion.datos;
                grNombramientos.DataBind();
            }
        }

        private void Limpiar()
        {
            txtCCT.Text = "";
            txtNombreCCT.Text = "";
            ddlTurno.ClearSelection();

            ddlVigenciaAdscripcion.ClearSelection();

            pnlFechaPeriodo.Visible = false;
            txtFechaInicial.Text = "";
            txtFechaFinal.Text = "";

            ddlTipoVacante.ClearSelection();
            ddlTipoNombramiento.ClearSelection();
            ddlTipoCategoria.ClearSelection();
            txtClavePresupuestal.Text = "";
            txtFechaAsignacion.Text = "";
            ddlEntidadOrigen.ClearSelection();
            rblAproboEvaluacionInduccion.ClearSelection();
            rblAproboEvaluacionInduccion.Items[0].Selected = true;
            ddlDenominacionPlaza.ClearSelection();
            ddlTipoPlaza.ClearSelection();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.AsignacionListas _Asignacion = new Negocio.AsignacionListas();

            try { _Asignacion.Asignacion.ID_AsignacionDetalle = (int?)this.ID_AsignacionDetalle; } catch { }
            try { _Asignacion.Asignacion.id_Resultados = (int?)this._Ent_Usuario.id_Resultados; } catch { }
            try { _Asignacion.Asignacion.FolioFederal = lblFolioFederal.Text; } catch { }
            try { _Asignacion.Asignacion.CURP = lblCURP.Text; } catch { }
            try { _Asignacion.Asignacion.CCT = txtCCT.Text; } catch { }
            try { _Asignacion.Asignacion.NombreCCT = txtNombreCCT.Text; } catch { }
            try { _Asignacion.Asignacion.ClaveDeTurno = (int?)int.Parse(ddlTurno.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.ID_VigenciaAdscripcion = (int?)int.Parse(ddlVigenciaAdscripcion.SelectedValue); } catch { }

            try { _Asignacion.Asignacion.Fecha_Inicio = (DateTime?)DateTime.Parse(txtFechaInicial.Text); } catch { }
            try { _Asignacion.Asignacion.Fecha_Fin = (DateTime?)DateTime.Parse(txtFechaFinal.Text); } catch { }
            
            try { _Asignacion.Asignacion.ID_TipoVacante = (int?)int.Parse(ddlTipoVacante.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.ID_TipoNombramiento = (int?)int.Parse(ddlTipoNombramiento.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.ID_TipoCategoria = (int?)int.Parse(ddlTipoCategoria.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.Funcion = lblFuncion.Text; } catch { }
            try { _Asignacion.Asignacion.TipoEvaluacion = lblTipoEvuacion.Text; } catch { }
            try { _Asignacion.Asignacion.ClaveEntidad = (int?)int.Parse(this._Ent_Usuario.ClaveEntidad); } catch { }
            try { _Asignacion.Asignacion.TipoSostenimiento = lblTipoSostenimiento.Text; } catch { }
            try { _Asignacion.Asignacion.ClavePresupuestal = txtCCT.Text; } catch { }
            try { _Asignacion.Asignacion.FechaAsignacion = (DateTime?)DateTime.Parse(txtFechaAsignacion.Text); } catch { }
            try { _Asignacion.Asignacion.ClaveEntidad_OrigenDocente = (int?)int.Parse(ddlEntidadOrigen.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.AproboEvaluacionInduccion = (bool?)(rblAproboEvaluacionInduccion.SelectedValue == "1"); } catch { }
            try { _Asignacion.Asignacion.UsuarioRegistro = this._Ent_Usuario.Usuario; } catch { }
            try { _Asignacion.Asignacion.ClaveEstatusAsignacion = (int?)int.Parse(ddlEstatusAsignacion.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.ID_MotivoRechazo = (int?)int.Parse(ddlMotivoRechazo.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.Servicio = lblServicio.Text; } catch { }
            try { _Asignacion.Asignacion.ID_DenominacionPlaza = (int?)int.Parse(ddlDenominacionPlaza.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.ID_TipoPlaza = (int?)int.Parse(ddlTipoPlaza.SelectedValue); } catch { }
            try { _Asignacion.Asignacion.NumHoras = (int?)int.Parse(txtHoras.Text, 0); } catch { }

            if (this.ID_AsignacionDetalle != null)
            {
                /* Actualizamos el detalle */
                _Asignacion.Proc = Negocio.AsignacionListas.Procedimientos.spt_UPD_AsignacionDetalle;
            }
            else
            {
                /* Insertamos un nuevo detalle */
                _Asignacion.Proc = Negocio.AsignacionListas.Procedimientos.spt_INS_AsignacionDetalle;
            }

            _Asignacion.Busqueda();
            if (_Asignacion.datos != null)
            {
                /* Se guardó el registro por lo que ahora se debe de actualizar el grid */
                CargarAsignaciones(this._Ent_Usuario.id_Resultados);
            }
            this.ID_AsignacionDetalle = null;
            Limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            ID_AsignacionDetalle = int.Parse(((LinkButton)sender).CommandArgument);
            CargarAsignacion((int)ID_AsignacionDetalle);
        }
        protected void lnkSeleccionar_Click(object sender, EventArgs e)
        {
            ID_AsignacionDetalle = int.Parse(((LinkButton)sender).CommandArgument);
            CargarAsignacion((int)ID_AsignacionDetalle);
        }
        
        private void CargarAsignacion(int ID_AsignacionDetalle)
        {
            Negocio.AsignacionListas _Asignacion = new Negocio.AsignacionListas();
            _Asignacion.Proc = Negocio.AsignacionListas.Procedimientos.spt_SEL_DocenteAsignacion;
            _Asignacion.Filtros.ID_AsignacionDetalle = ID_AsignacionDetalle;
            _Asignacion.Busqueda();

            if (_Asignacion.datos != null)
            {
                Limpiar();



                try { txtCCT.Text = _Asignacion.Asignacion.CCT.ToString(); } catch { }
                try { txtNombreCCT.Text = _Asignacion.Asignacion.NombreCCT.ToString(); } catch { }
                try { ddlTurno.Items.FindByValue(_Asignacion.Asignacion.ClaveDeTurno.ToString()).Selected = true; } catch { }
                try { ddlVigenciaAdscripcion.Items.FindByValue(_Asignacion.Asignacion.ID_VigenciaAdscripcion.ToString()).Selected = true; } catch { }

                try { _Asignacion.Asignacion.Fecha_Inicio = (DateTime?)DateTime.Parse(txtFechaInicial.Text); } catch { }
                try { _Asignacion.Asignacion.Fecha_Fin = (DateTime?)DateTime.Parse(txtFechaFinal.Text); } catch { }

                try { _Asignacion.Asignacion.ID_TipoVacante = (int?)int.Parse(ddlTipoVacante.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.ID_TipoNombramiento = (int?)int.Parse(ddlTipoNombramiento.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.ID_TipoCategoria = (int?)int.Parse(ddlTipoCategoria.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.Funcion = lblFuncion.Text; } catch { }
                try { _Asignacion.Asignacion.TipoEvaluacion = lblTipoEvuacion.Text; } catch { }
                try { _Asignacion.Asignacion.ClaveEntidad = (int?)int.Parse(this._Ent_Usuario.ClaveEntidad); } catch { }
                try { _Asignacion.Asignacion.TipoSostenimiento = lblTipoSostenimiento.Text; } catch { }
                try { _Asignacion.Asignacion.ClavePresupuestal = txtCCT.Text; } catch { }
                try { _Asignacion.Asignacion.FechaAsignacion = (DateTime?)DateTime.Parse(txtFechaAsignacion.Text); } catch { }
                try { _Asignacion.Asignacion.ClaveEntidad_OrigenDocente = (int?)int.Parse(ddlEntidadOrigen.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.AproboEvaluacionInduccion = (bool?)(rblAproboEvaluacionInduccion.SelectedValue == "1"); } catch { }
                try { _Asignacion.Asignacion.UsuarioRegistro = this._Ent_Usuario.Usuario; } catch { }
                try { _Asignacion.Asignacion.ClaveEstatusAsignacion = (int?)int.Parse(ddlEstatusAsignacion.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.ID_MotivoRechazo = (int?)int.Parse(ddlMotivoRechazo.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.Servicio = lblServicio.Text; } catch { }
                try { _Asignacion.Asignacion.ID_DenominacionPlaza = (int?)int.Parse(ddlDenominacionPlaza.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.ID_TipoPlaza = (int?)int.Parse(ddlTipoPlaza.SelectedValue); } catch { }
                try { _Asignacion.Asignacion.NumHoras = (int?)int.Parse(txtHoras.Text, 0); } catch { }
            }
        }

        #region Obtencion de Datos
        private IEnumerable<ListItem> GetEntidades()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_SeleccionarTodoEntidad;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ClaveEntidad", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTurno()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTurno;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ClaveDeTurno", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetVigenciaAdscripcion()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneVigenciaAdscripcion;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_VigenciaAdscripcion", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTipoVacante()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipoVacante;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_TipoVacante", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTipoNombramiento()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipoNombramiento;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_TipoNombramiento", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTipoCategoria()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipoCategoria;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_TipoCategoria", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetDenominacionPlaza()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_DenominacionPlaza;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_DenominacionPlaza", "Descripcion");
            }
            return Result;
        }
        private IEnumerable<ListItem> GetTipoPlaza()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_TipoPlaza;
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_TipoPlaza", "Descripcion");
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
    }
}