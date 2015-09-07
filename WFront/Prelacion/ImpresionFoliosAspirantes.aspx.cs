using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Drawing;

namespace WFront.Prelacion
{
    public partial class ImpresionFoliosAspirantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["Perfil"].ToString() == "I")
                    {
                        LlenarCombos();
                        cboEntidades.Visible = true;
                        cboSubSistemas.Visible = true;
                        tblDatos.Visible = false;
                    }
                    else
                    {
                        LlenarCombos();
                        tblDatos.Visible = false;
                    }
                }
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
                txtFolio.Text = "";
                Negocio.Otros _nCargarDatos = new Negocio.Otros();
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_2;
                _nCargarDatos.Ent = Int32.Parse(cboEntidades.SelectedValue.ToString());
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

                    this.tblDatos.Visible = false;
                    grDatos.DataSource = null;
                    grDatos.DataBind();
                }
            }
            else
            { ObtieneSubsistemaUsuario(); }
        }
        protected void btnEjecutarReporte_Click(object sender, EventArgs e)
        {
            if (cboEntidades.SelectedIndex == 0)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Debe seleccionar una entidad.");
                return;
            }
            else if (cboSubSistemas.SelectedIndex == 0)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Debe seleccionar un Subsistema.");
                return;
            }
            else if (txtFolio.Text.Length == 0 || txtFolio.Text == "")
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Debe capturar un Número de Folio.");
                return;
            }
            else
            {
                Negocio.Otros _nCargarDatos = new Negocio.Otros();
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_ImpresionFoliosAsignacion;
                _nCargarDatos.Entidad = int.Parse(cboEntidades.SelectedValue);
                _nCargarDatos.ClaveSubsistema = int.Parse(cboSubSistemas.SelectedValue);
                _nCargarDatos.Folio = txtFolio.Text.ToString();
                _nCargarDatos.Busqueda();
                if(_nCargarDatos.datos!=null)
                {
                    grDatos.DataSource = _nCargarDatos.datos.Tables[0];
                    grDatos.DataBind();
                    tblDatos.Visible=true;

                    grFolios.DataSource = _nCargarDatos.datos.Tables[0];
                    grFolios.DataBind();

                    this.lblFolioImpresion.Text = txtFolio.Text.ToString();
                    this.lblEntidad.Text = cboEntidades.SelectedItem.Text.ToString();
                    this.lblPlaza.Text = _nCargarDatos.datos.Tables[0].Rows[0][8].ToString();

                    this.lblFolioImpresion0.Text = txtFolio.Text.ToString();
                    this.lblEntidad0.Text = cboEntidades.SelectedItem.Text.ToString();
                    this.lblPlaza0.Text = _nCargarDatos.datos.Tables[0].Rows[0][8].ToString();
                }
                else
                {
                    new WebNegocio.Utils().Mensaje(this.Page, "No se encontro información con los criterios indicados.");
                    this.tblDatos.Visible = false;
                    return;
                }
            }
        }
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            new PDFExpress().ASPXToPDF(ImpresionFolios);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void grFolios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Attributes.Add("bgcolor", "#8B0000");
                e.Row.Attributes.Add("align", "center");
                e.Row.Attributes.Add("valign", "middle");
                e.Row.ForeColor = Color.White;
                e.Row.Font.Bold = true;
                e.Row.Font.Name = "HELVETICA";
                e.Row.Font.Size = 9;
            }
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("bgcolor", "#8B0000");
                e.Row.Cells[0].Attributes.Add("align", "center");
                e.Row.Cells[0].Attributes.Add("valign", "middle");
                e.Row.Cells[0].ForeColor = Color.White;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].Font.Size = 11;

                e.Row.Cells[0].Attributes.Add("width", "5%");
                e.Row.Cells[1].Attributes.Add("width", "13%");
                e.Row.Cells[2].Attributes.Add("width", "12%");

                e.Row.Font.Name = "HELVETICA";
                e.Row.Font.Size = 7;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }
    }
}