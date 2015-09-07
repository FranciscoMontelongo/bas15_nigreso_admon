using System;
using System.Web.UI.WebControls;

namespace WFront.Tablero
{
    public partial class Resumen : System.Web.UI.Page
    {
        private enum lista
        {
            lista1 = 1,
            lista2
        }

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
                Notificaciones.Visible = true;
                Solicitudes.Visible = true;
            }
        }

        protected void DatosGenerar()
        {
            if (cboPrelacion.SelectedIndex < 1)
            {
                return;
            }
            LimpiarDatos();
            Negocio.Tablero Consulta = new Negocio.Tablero();

            if (cboPrelacion.SelectedItem.Value == "1")
                Consulta.Proc = Negocio.Tablero.Procedimientos.spt_Asignacion_SEL_ASIGNACION_ASPIRANTES;
            if (cboPrelacion.SelectedItem.Value == "2")
                Consulta.Proc = Negocio.Tablero.Procedimientos.spt_Asignacion_SEL_ASIGNACION_ASPIRANTES_tbl2;

            if (Session["Perfil"].ToString() == "I")
            {
                Consulta.Entidad = Int32.Parse(cboEntidades.SelectedValue.ToString());
                Consulta.SubSis = Int32.Parse(cboSubSistemas.SelectedValue.ToString());
            }
            else
            {
                Consulta.Entidad = Int32.Parse(cboEntidades.SelectedValue.ToString());
                Consulta.SubSis = Int32.Parse(cboSubSistemas.SelectedValue.ToString());
            }
            Consulta.Busqueda();
            //************** Aspirantes
            if (Consulta.datos != null)
            {
                lblTotal.Text = Consulta.datos.Tables[0].Rows[0][0].ToString();
                lblTotPlaza.Text = Consulta.datos.Tables[0].Rows[0][1].ToString();
                lblRech.Text = Consulta.datos.Tables[0].Rows[0][2].ToString();
               // lblEspera.Text = Consulta.datos.Tables[0].Rows[0][3].ToString();
                lblAsignadosProvisionalmente.Text = Consulta.datos.Tables[0].Rows[0][4].ToString();
            }
            //************** Asignaciones
            if (cboPrelacion.SelectedItem.Value == "1")
                Consulta.Proc = Negocio.Tablero.Procedimientos.spt_Asignacion_SEL_ASIGNACION_FOLIOSGENERADOS;
            if (cboPrelacion.SelectedItem.Value == "2")
                Consulta.Proc = Negocio.Tablero.Procedimientos.spt_Asignacion_SEL_ASIGNACION_FOLIOSGENERADOS_tbl2;

            Consulta.Busqueda();
            if (Consulta.datos != null)
            {
                lblFolios.Text = Consulta.datos.Tables[0].Rows[0][0].ToString();
                lblFirmadas.Text = Consulta.datos.Tables[0].Rows[0][1].ToString();
                lblSinFirmar.Text = Consulta.datos.Tables[0].Rows[0][2].ToString();
            }
            //************** Solicitudes
            Consulta.Proc = Negocio.Tablero.Procedimientos.spt_Asignacion_SEL_ASIGNACION_SOLICITUDES;
            Consulta.Busqueda();
            if (Consulta.datos != null)
            {
                lblSol1.Text = Consulta.datos.Tables[0].Rows[0][0].ToString();
                lblSol2.Text = Consulta.datos.Tables[0].Rows[0][1].ToString();
                lblSol3.Text = Consulta.datos.Tables[0].Rows[0][2].ToString();
            }
            //************** Notificaciones
            Consulta.Proc = Negocio.Tablero.Procedimientos.spt_Asignacion_SEL_ASIGNACION_NOTIFICACIONES;
            Consulta.Busqueda();
            if (Consulta.datos != null)
            {
                lblNot1.Text = Consulta.datos.Tables[0].Rows[0][0].ToString();
                lblNot2.Text = Consulta.datos.Tables[0].Rows[0][1].ToString();
                lblNot3.Text = Consulta.datos.Tables[0].Rows[0][2].ToString();
            }
        }

        protected void LlenarCombos()
        {


            /*Lista Prelacion*/
            cboPrelacion.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
            cboPrelacion.Items.Insert(1, new ListItem("Prelacion 1", "1"));
            cboPrelacion.Items.Insert(2, new ListItem("Prelacion 2", "2"));
        }
        private void CArgaEntidades()
        {
            if (cboPrelacion.SelectedIndex > 0)
            {
                Negocio.Otros _nCargarDatos = new Negocio.Otros();
                // _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_SeleccionarEntidadClaveTipo2;
                if (cboPrelacion.SelectedIndex == (int)lista.lista1)
                {
                    _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_SeleccionarEntidad_Resultado;
                }
                else
                {
                    _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_SeleccionarEntidad_Resultado_tbl2;
                }
                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    cboEntidades.Items.Clear();
                    cboEntidades.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    cboEntidades.AppendDataBoundItems = true;
                    cboEntidades.DataSource = _nCargarDatos.datos.Tables[0];
                    cboEntidades.DataTextField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    cboEntidades.DataValueField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                    cboEntidades.DataBind();
                }

            }
        }
        protected void cboEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Perfil"].ToString() == "I")
            {
                Negocio.Otros _nCargarDatos = new Negocio.Otros();
                //_nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_2;
                //_nCargarDatos.Ent = Int32.Parse(cboEntidades.SelectedValue.ToString());
                if (cboPrelacion.SelectedIndex == (int)lista.lista1)
                {
                    _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_4;
                }
                else//Lista prelacion 2
                {
                    _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_4_tbl2;
                }
                _nCargarDatos.sEntidad = cboEntidades.SelectedItem.Text;
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
            else { ObtieneSubsistemaUsuario(); }
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

        protected void cboSubSistemas_SelectedIndexChanged(object sender, EventArgs e)
        { DatosGenerar(); }

        protected void LimpiarDatos()
        {
            lblNot1.Text = "0";
            lblNot2.Text = "0";
            lblNot3.Text = "0";
            lblTotal.Text = "0";
            lblTotPlaza.Text = "0";
            lblRech.Text = "0";
            //lblEspera.Text = "0";
            lblFolios.Text = "0";
            lblFirmadas.Text = "0";
            lblSinFirmar.Text = "0";
        }

        protected void cboPrelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CArgaEntidades();
        }

        public void mensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ScriptRep1", String.Format("<script language='javascript'>javascript:alert('{0}');</script>", mensaje), false);
        }

    }
}