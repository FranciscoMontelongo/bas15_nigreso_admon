using System;
using System.Data;
using System.Web.UI.WebControls;

using System.Collections.Generic;

using WFront.Common;

using Negocio;

namespace WFront.Asignacion
{
    public partial class PlazaAntecedente : System.Web.UI.Page
    {

        private Ent_Usuario _Ent_Usuario { get { return (Ent_Usuario)Session["Info_User"]; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                cargaCatalogos();
                horas.Visible = false;
                btnActualizar.Enabled = false;
                //Session["Editar"] = "no";
                _Ent_Usuario.editar = "no";
                //txtCURP.Text = Request.QueryString["CURP"].ToString().ToUpper();
                txtCURP.Text = _Ent_Usuario.CURP;
                //lblEstatus.Text = Session["EstaSelDesc"].ToString();                
                lblEstatus.Text = _Ent_Usuario.EstatusActual;
                //lblNombre.Text = Request.QueryString["Nom"].ToString();
                lblNombre.Text = _Ent_Usuario.Usuario;
                PoblarGridView();                
            }
        }

        protected void cboTipoPlaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoras.Text = "";
            if (cboTipoPlaza.SelectedIndex == 2)
                horas.Visible = true;
            else
                horas.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asignar.aspx");
        }

        private IEnumerable<ListItem> GetTipoPlaza()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipoPlaza;
            _Filtro.Filtros.Funcion = "";
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_TipoPlaza", "Descripcion");
            }
            return Result;
        }

        private IEnumerable<ListItem> GetNivelCarrera()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneNivelCarrera;
            _Filtro.Filtros.Funcion = "";
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("idNivelCarrera", "DescripcionNivel");
            }
            return Result;
        }

        private IEnumerable<ListItem> GetTipoCategoria()
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            Negocio.Filtro _Filtro = new Negocio.Filtro();
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneTipoCategoria;
            _Filtro.Filtros.Funcion = "";
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
            _Filtro.Filtros.ID_TipoCategoria = ddlTipoCategoria.SelectedValue;
            _Filtro.Proc = Negocio.Filtro.Procedimientos.spt_SEL_ObtieneDenominacionPlazaXTipoCategoria;            
            _Filtro.Busqueda();

            if (_Filtro.datos != null)
            {
                var datos = _Filtro.datos.Tables[0];
                Result = datos.GenerateItems("ID_DenominacionPlaza", "Descripcion");
            }
            return Result;
        }       

        protected void cargaCatalogos()
        {

            cboTipoPlaza.LoadData(GetTipoPlaza(), true);

            cboNivelCarrera.LoadData(GetNivelCarrera(), true);                                   

            ddlTipoCategoria.LoadData(GetTipoCategoria(), true);

            ddlDenominacionPlaza.LoadData(GetDenominacionPlaza(), true);

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos() == true)
            {
                Negocio.Asignacion _Actualizar = new Negocio.Asignacion();

                _Actualizar.Entidad = int.Parse(_Ent_Usuario.ClaveEntidad);
                    //Int32.Parse((string)Session["ClaveEntidadAsignacion"]);
                //_Actualizar.SubSis = Int32.Parse((string)Session["ClaveSubsistemaAsignacion"]);
                _Actualizar.CURP = txtCURP.Text;
                _Actualizar.ClaveCCT = txtCCT.Text.ToString().ToUpper();
                _Actualizar.DescCCT = txtDescripcionCCT.Text.ToString().Trim();
                _Actualizar.TipoPlaza = int.Parse(cboTipoPlaza.SelectedValue);
                if (cboTipoPlaza.SelectedIndex == 2)
                    _Actualizar.HorasAntecedente = int.Parse(txtHoras.Text.ToString().Trim());
                else
                    _Actualizar.HorasAntecedente = 0;
                _Actualizar.ClavePlaza = ddlTipoCategoria.SelectedValue;                    
                _Actualizar.DescPlaza = ddlDenominacionPlaza.SelectedValue;                    
                _Actualizar.CvePresupuestal = txtClavePresupuestal.Text.ToString().Trim();
                _Actualizar.NivelCarrera = int.Parse(cboNivelCarrera.SelectedValue);
                if (_Ent_Usuario.editar == "si")
                    _Actualizar.ID = int.Parse(_Ent_Usuario.ID_Antecedente);
                else
                    _Actualizar.ID = 0;//en casi de que sea nuevo registro
                _Actualizar.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_INS_PlazasAntecedentes;
                _Actualizar.Busqueda();
                if (_Actualizar.datos != null)
                {
                    if (_Ent_Usuario.editar != "si")
                        new WebNegocio.Utils().Mensaje(this.Page, "Datos guardados correctamente");
                    else
                        new WebNegocio.Utils().Mensaje(this.Page, "Datos actualizados correctamente");
                    PoblarGridView();
                    _Ent_Usuario.editar = "no";
                }
                else
                { new WebNegocio.Utils().Mensaje(this.Page, "No se pudieron guardar los datos, verifique su información"); }

                limpiar();
            }
            else
                new WebNegocio.Utils().Mensaje(this.Page, "Todos los campos son requeridos");

            return;
        }

        protected void PoblarGridView()
        {                                 
            Negocio.Asignacion _obAsignacion = new Negocio.Asignacion();
            _obAsignacion.Proc = Negocio.Asignacion.Procedimientos.spt_SEL_MostrarPlazasAntecedentes;//procedure para mostrar antecedentes
            _obAsignacion.Entidad = int.Parse(_Ent_Usuario.ClaveEntidad);
                //Int32.Parse((string)Session["ClaveEntidadAsignacion"]);
            //_obAsignacion.SubSis = Int32.Parse((string)Session["ClaveSubsistemaAsignacion"]);
            _obAsignacion.CURP = txtCURP.Text;
            _obAsignacion.Busqueda();
            if (_obAsignacion.datos != null)
            {
                grNombramientos.DataSource = _obAsignacion.datos.Tables[0];
                grNombramientos.DataBind();
                DataTable dtTabla = _obAsignacion.datos.Tables[0];
                btnActualizar.Enabled = true;                
            }
            else
            {
                grNombramientos.DataBind();
                btnActualizar.Enabled = false;
            }

            if (grNombramientos.Rows.Count > 0)
            {
                btnActualizar.Visible = true;
            }
            else
            {
                btnActualizar.Visible = false;
            }
        }

        protected void grNombramientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = grNombramientos.SelectedRow;
            Negocio.Asignacion _obAsignacion = new Negocio.Asignacion();
            _obAsignacion.Proc = Negocio.Asignacion.Procedimientos.spt_SEL_PlazasAntecedentesPorID;//procedure para buscar por ID
            _obAsignacion.ID_Antecedente = int.Parse(fila.Cells[1].Text);
            _obAsignacion.Busqueda();
            if (_obAsignacion.datos != null)
            {
                this.txtCCT.Text = _obAsignacion.datos.Tables[0].Rows[0][4].ToString();
                this.txtDescripcionCCT.Text = _obAsignacion.datos.Tables[0].Rows[0][5].ToString();
                this.cboTipoPlaza.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][6].ToString();
                if (int.Parse(_obAsignacion.datos.Tables[0].Rows[0][6].ToString()) != 1)
                {
                    this.txtHoras.Text = _obAsignacion.datos.Tables[0].Rows[0][7].ToString();
                    horas.Visible = true;
                }
                else
                    horas.Visible = false;                
                ddlTipoCategoria.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][8].ToString();                
                ddlDenominacionPlaza.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][9].ToString();
                this.txtClavePresupuestal.Text = _obAsignacion.datos.Tables[0].Rows[0][10].ToString();
                this.cboNivelCarrera.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][11].ToString();
                _Ent_Usuario.ID_Antecedente = fila.Cells[1].Text;
                _Ent_Usuario.editar = "si";
            }
        }

        protected void grNombramientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }            
        }        

        protected void grNombramientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Negocio.Asignacion _obAsignacion = new Negocio.Asignacion();

            _obAsignacion.Proc = Negocio.Asignacion.Procedimientos.spt_DEL_EliminaPlazasAntecedentes;
            _obAsignacion.ID_Antecedente = Int32.Parse(grNombramientos.Rows[e.RowIndex].Cells[1].Text);
            _obAsignacion.Busqueda();
            if (_obAsignacion.datos != null)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Se eliminó la información correctamente.");
                PoblarGridView();
                limpiar();
                return;
            }
            else
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Ocurrió un error al eliminar la información.");
                return;
            }
        }

        protected void limpiar()
        {
            txtCCT.Text = "";
            txtDescripcionCCT.Text = "";
            cboTipoPlaza.SelectedIndex = 0;
            horas.Visible = false;
            txtHoras.Text = "";
            ddlDenominacionPlaza.SelectedIndex = 0;
            ddlTipoCategoria.SelectedIndex = 0;            
            txtClavePresupuestal.Text = "";
            cboNivelCarrera.SelectedIndex = 0;
        }

        protected bool validarCampos()
        {
            if (txtCCT.Text == "" || txtDescripcionCCT.Text == "" || cboTipoPlaza.SelectedIndex == 0
              || cboTipoPlaza.SelectedIndex == 2 && txtHoras.Text == "" || 
              //txtClavePlaza.Text == "" || 
              //txtDenominacion.Text == "" || 
              txtClavePresupuestal.Text == ""
                || cboNivelCarrera.SelectedIndex == 0)
                return false;
            else
                return true;
        }

        protected void grNombramientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PoblarGridView();
            grNombramientos.PageIndex = e.NewPageIndex;
            grNombramientos.DataBind();
        }

        protected void ddlTipoCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDenominacionPlaza.LoadData(GetDenominacionPlaza(), true);
        }
    }
}