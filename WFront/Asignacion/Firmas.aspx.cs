using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebNegocio;

namespace WFront.Asignacion
{
    public partial class Firmas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Perfil"].ToString() == "I")
                {
                    LlenarCombos();
                    cboEntidades.Visible = true;
                    cboSubSistemas.Visible = true;
                }
                else
                { LlenarCombos(); }
            }
        }
        protected void LlenarCombos()
        {
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_SeleccionarEntidadClaveTipo2;
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                cboEntidades.Items.Clear();
                cboEntidades.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboEntidades.AppendDataBoundItems = true;
                cboEntidades.DataSource = _nCargarDatos.datos.Tables[0];
                cboEntidades.DataTextField = _nCargarDatos.datos.Tables[0].Columns[2].Caption.ToString();
                cboEntidades.DataValueField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                cboEntidades.DataBind();
            }
        }
        protected void ObtieneSubsistemaUsuario()
        {
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_Todos_ASIGNACION_SISTEMAS_ENTIDAD;
            _nCargarDatos.ClaveSubsistema = int.Parse(Session["Sistema"].ToString());
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                cboSubSistemas.Items.Clear();
                cboSubSistemas.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboSubSistemas.AppendDataBoundItems = true;
                cboSubSistemas.DataSource = _nCargarDatos.datos.Tables[0];
                cboSubSistemas.DataTextField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                cboSubSistemas.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                cboSubSistemas.DataBind();
            }
        }
        protected void cboEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Perfil"].ToString() == "I")
            {
                Negocio.Otros _nCargarDatos = new Negocio.Otros();
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_2;
                _nCargarDatos.Ent = int.Parse(cboEntidades.SelectedValue);
                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    cboSubSistemas.Items.Clear();
                    cboSubSistemas.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    cboSubSistemas.AppendDataBoundItems = true;
                    cboSubSistemas.DataSource = _nCargarDatos.datos.Tables[0];
                    cboSubSistemas.DataTextField = _nCargarDatos.datos.Tables[0].Columns[2].Caption.ToString();
                    cboSubSistemas.DataValueField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                    cboSubSistemas.DataBind();
                }
            }
            else
            { ObtieneSubsistemaUsuario(); }
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if(cboEntidades.SelectedIndex == 0)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Seleccione una entidad.");
                return;
            }
            else if (cboSubSistemas.SelectedIndex == 0)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Seleccione un subsistema.");
                return;
            }
            else if(cboFolios.SelectedIndex == 0)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Seleccione un folio.");
                return;
            }
            else
            { CargarGridView(); }
        }
        protected void CargarGridView()
        {
            try
            {
                Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
                _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_Sel_Firma;
                _nCargarDatos.Entidad = Int32.Parse(cboEntidades.SelectedValue.ToString());
                _nCargarDatos.SubSis = Int32.Parse(cboSubSistemas.SelectedValue.ToString());
                _nCargarDatos.FolioGenerado = cboFolios.SelectedValue;
                 _nCargarDatos.Busqueda();
                 if (_nCargarDatos.datos != null)
                 {
                     grDatos.DataSource = null;
                     grDatos.DataBind();
                     grDatos.DataSource = _nCargarDatos.datos.Tables[0];
                     grDatos.DataBind();
                 }
                 else
                 {
                     grDatos.DataSource = null;
                     grDatos.DataBind();
                 }
            }
            catch (Exception mensaje)
            { throw new Exception(mensaje.ToString()); }
        }
        protected void btnFirmas_Click(object sender, EventArgs e)
        {
            Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
            foreach (GridViewRow row in grDatos.Rows)
            {
                CheckBox check = row.FindControl("chkFirma") as CheckBox;
                try
                {
                    if (check.Checked == true)
                    {
                        _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_UPD_Firma;
                        _nCargarDatos.CURP = grDatos.DataKeys[row.RowIndex].Values[0].ToString();
                        _nCargarDatos.Firma = 1;
                        _nCargarDatos.Busqueda();
                        if (_nCargarDatos.datos != null)
                        {
                            new WebNegocio.Utils().Mensaje(this.Page, "Aplicacion de firmas correctamente.");
                            CargarGridView();
                            return;
                        }
                        else
                        {
                            new WebNegocio.Utils().Mensaje(this.Page, "Ocurrio un error al aplicar la firma.");
                            return;
                        }
                    }
                    else
                    {
                        new WebNegocio.Utils().Mensaje(this.Page, "Seleccione un candidato para aplicar Firma.");
                        return;
                    }
                }
                catch (Exception mensaje)
                { throw new Exception(mensaje.ToString()); }
            }
        }
        protected void cboSubSistemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
                _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_SEL_SeleccionarFolios;
                _nCargarDatos.Entidad = int.Parse(cboEntidades.SelectedValue);
                _nCargarDatos.SubSis = int.Parse(cboSubSistemas.SelectedValue);
                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    cboFolios.Items.Clear();
                    cboFolios.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    cboFolios.AppendDataBoundItems = true;
                    cboFolios.DataSource = _nCargarDatos.datos.Tables[0];
                    cboFolios.DataTextField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    cboFolios.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    cboFolios.DataBind();
                    cboFolios.Enabled = true;
                }
                else
                {
                    new Utils().Mensaje(this.Page, "No existen folios.");
                    return;
                }
            }
            catch { }
        }
    }
}