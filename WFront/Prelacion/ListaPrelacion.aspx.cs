using System;
using System.Web.UI.WebControls;

namespace WFront.Prelacion
{
    public partial class ListaPrelacion : System.Web.UI.Page
    {
        enum lista
        {
            lista1 = 1,
            lista2
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCombos();
                cboEntidades.Visible = true;
                cboSubSistemas.Visible = true;
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
            else
            { ObtieneSubsistemaUsuario(); }
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
        {
            if (cboPrelacion.SelectedIndex == (int)lista.lista1)
            {
                CargaCCT();
            }
            else
            {
                ObtieneCargos_tbl2();
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
        protected void DatosGenerar()
        {
            try
            {
                Negocio.Prelacion _nCargarDatos = new Negocio.Prelacion();
                if (cboPrelacion.SelectedIndex == (int)lista.lista1)
                {
                    _nCargarDatos.Proc = Negocio.Prelacion.Procedimientos.spt_Asignacion_PrelacionConsulta;
                }
                else if (cboPrelacion.SelectedIndex == (int)lista.lista2)
                {
                    _nCargarDatos.Proc = Negocio.Prelacion.Procedimientos.spt_Asignacion_PrelacionConsulta_tbl2;
                }
                _nCargarDatos.Entidad = Int32.Parse(cboEntidades.SelectedValue.ToString());
                _nCargarDatos.SubSis = Int32.Parse(cboSubSistemas.SelectedValue.ToString());
                _nCargarDatos.ClaveCCT = ddlCCT.SelectedValue.ToString();
                _nCargarDatos.Cargo = ddlCargo.SelectedValue.ToString();

                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    grDatos.DataSource = _nCargarDatos.datos.Tables[0];
                    grDatos.DataBind();
                }
                else
                {
                    grDatos.DataSource = null;
                    grDatos.DataBind();
                }
            }
            catch
            {
                grDatos.DataSource = null;
                grDatos.DataBind();
            }
        }

        protected void grDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;
            DatosGenerar();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            DatosGenerar(); System.Threading.Thread.Sleep(1000);
        }

        private void CargaCCT()
        {
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            try
            {
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_SEL_CCT_SUBSIS_REsultado;
                _nCargarDatos.sEntidad = cboEntidades.SelectedItem.Text;
                _nCargarDatos.ClaveSubsistema = Int32.Parse(cboSubSistemas.SelectedItem.Value);
                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    ddlCCT.Items.Clear();
                    ddlCCT.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    ddlCCT.AppendDataBoundItems = true;
                    ddlCCT.DataSource = _nCargarDatos.datos.Tables[0];
                    ddlCCT.DataValueField = _nCargarDatos.datos.Tables[0].Columns["cct"].Caption.ToString();
                    ddlCCT.DataTextField = _nCargarDatos.datos.Tables[0].Columns["DESCRIPCION"].Caption.ToString();
                    ddlCCT.DataBind();
                }
            }
            catch (Exception ex)
            {
                new WebNegocio.Utils().Mensaje(this.Page, ex.ToString());
                return;
            }
        }



        protected void ddlCCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtieneCargos();
        }

        private void ObtieneCargos()
        {
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            try
            {
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_Sel_CargoDirectores_CCT_Subsistema;
                _nCargarDatos.sEntidad = cboEntidades.SelectedItem.Text;
                _nCargarDatos.ClaveSubsistema = Int32.Parse(cboSubSistemas.SelectedItem.Value);
                _nCargarDatos.ClaveCCT = ddlCCT.SelectedValue.ToString();
                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    ddlCargo.Items.Clear();
                    ddlCargo.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    ddlCargo.AppendDataBoundItems = true;
                    ddlCargo.DataSource = _nCargarDatos.datos.Tables[0];
                    ddlCargo.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    ddlCargo.DataTextField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    ddlCargo.DataBind();
                }
            }
            catch (Exception ex)
            {
                new WebNegocio.Utils().Mensaje(this.Page, ex.ToString());
                return;
            }
        }

        protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosGenerar();
        }

        /// <summary>
        /// Se selcciono una prelacion 2015
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cboPrelacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboPrelacion.SelectedIndex > 0)
            {
                CArgaEntidades();
                Session["listaPrelacion"] = cboPrelacion.SelectedItem.Value;//1 ó 2
                if (cboPrelacion.SelectedIndex == (int)lista.lista1)
                {
                    lblCCT.Visible = true;
                    ddlCCT.Visible = true;
                    if (cboSubSistemas.SelectedIndex > 0)
                    {
                        CargaCCT();
                    }
                }
                else
                {
                    ddlCCT.Items.Clear();
                    ddlCCT.DataBind();
                    lblCCT.Visible = false;
                    ddlCCT.Visible = false;
                    ddlCargo.Items.Clear();
                    ddlCargo.DataBind();
                    if (cboSubSistemas.SelectedIndex > 0)
                    {
                        ObtieneCargos_tbl2();
                    }
                }
            }
        }


        private void ObtieneCargos_tbl2()
        {
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            try
            {
                _nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_Sel_CargoDirectores_CCT_Subsistema_tbl2;
                _nCargarDatos.sEntidad = cboEntidades.SelectedItem.Text;
                _nCargarDatos.ClaveSubsistema = Int32.Parse(cboSubSistemas.SelectedItem.Value);

                _nCargarDatos.Busqueda();
                if (_nCargarDatos.datos != null)
                {
                    ddlCargo.Items.Clear();
                    ddlCargo.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                    ddlCargo.AppendDataBoundItems = true;
                    ddlCargo.DataSource = _nCargarDatos.datos.Tables[0];
                    ddlCargo.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    ddlCargo.DataTextField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                    ddlCargo.DataBind();
                }
            }
            catch (Exception ex)
            {
                new WebNegocio.Utils().Mensaje(this.Page, ex.ToString());
                return;
            }
        }
    }
}