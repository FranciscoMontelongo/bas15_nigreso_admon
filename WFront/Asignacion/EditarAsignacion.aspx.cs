using System;
using System.Data;
using System.Web.UI.WebControls;

namespace WFront.Asignacion
{
    public partial class EditarAsignacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCURP.Text = Request.QueryString["CURP"].ToString().ToUpper();
                lblEstatus.Text = Session["EstaSelDesc"].ToString();
                lblFolioFed.Text = Request.QueryString["FOLFE"].ToString();
                lblNombre.Text = Request.QueryString["Nom"].ToString();
                lblProv.Text = Session["TipoNom"].ToString();
                lblCargo.Text = Request.QueryString["Cargo"].ToString();

                string listaPrelacion = Session["listaPrelacion"].ToString();
                LlenadoCatalogos();
                PoblarGridView();
                cboEstatFinal.Enabled = false;
                Session["ClaveNom"] = null;
                Session["Actualiza"] = "NO";
                try
                {
                    if (Session["Editable"].ToString() == null || Session["Editable"].ToString() == "")
                    { Session["Editable"] = 2; }// 05092014

                    if (Int32.Parse(Request.QueryString["ROW"].ToString()) > int.Parse(Session["Editable"].ToString()))
                    {
                        BloquearControles();
                        new WebNegocio.Utils().Mensaje(this.Page, "Existen folios con prioridad por asignar.");
                        return;
                    }
                    if (Int32.Parse(Session["EstaSel"].ToString()) == 3)
                    { BloquearControles(); }
                }
                catch
                { }
            }
        }

        protected void PoblarGridView()
        {
            Negocio.Asignacion _obAsignacion = new Negocio.Asignacion();
            _obAsignacion.Proc = Negocio.Asignacion.Procedimientos.spt_SEL_TiposNombramientoAspirante;
            _obAsignacion.CURP = Request.QueryString["CURP"].Trim().ToString();
            _obAsignacion.FolioFed = Request.QueryString["FOLFE"].Trim().ToString();
            _obAsignacion.prelacion = int.Parse(Session["listaPrelacion"].ToString());
            _obAsignacion.Busqueda();
            if (_obAsignacion.datos != null)
            {
                grNombramientos.DataSource = _obAsignacion.datos.Tables[0];
                grNombramientos.DataBind();
                DataTable dtTabla = _obAsignacion.datos.Tables[0];
                Session["TablaAspirantes"] = dtTabla;
            }
        }

        protected void BloquearControles()
        {
            txtCCT.Enabled = false;
            txtClavePrep.Enabled = false;
            txtEfectoNom.Enabled = false;
            cboTurno.Enabled = false;
            cboTipoPlaza.Enabled = false;
            txtDescripcionCCT.Enabled = false;
            cboEstatFinal.Enabled = false;
            cboNombramiento.Enabled = false;
            cboNEstatus.Enabled = false;
            btnActualizar.Enabled = false;
        }

        protected void LlenadoCatalogos()
        {
            Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
            _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_SEL_SOSTENIMIENTO;
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                cboTurno.Items.Clear();
                cboTurno.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboTurno.AppendDataBoundItems = true;
                cboTurno.DataSource = _nCargarDatos.datos.Tables[0];
                cboTurno.DataTextField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                cboTurno.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                cboTurno.DataBind();

                cboTipoPlaza.Items.Clear();
                cboTipoPlaza.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboTipoPlaza.AppendDataBoundItems = true;
                cboTipoPlaza.DataSource = _nCargarDatos.datos.Tables[1];
                cboTipoPlaza.DataTextField = _nCargarDatos.datos.Tables[1].Columns[1].Caption.ToString();
                cboTipoPlaza.DataValueField = _nCargarDatos.datos.Tables[1].Columns[0].Caption.ToString();
                cboTipoPlaza.DataBind();

                cboNombramiento.Items.Clear();
                cboNombramiento.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboNombramiento.AppendDataBoundItems = true;
                cboNombramiento.DataSource = _nCargarDatos.datos.Tables[2];
                cboNombramiento.DataTextField = _nCargarDatos.datos.Tables[2].Columns[1].Caption.ToString();
                cboNombramiento.DataValueField = _nCargarDatos.datos.Tables[2].Columns[0].Caption.ToString();
                cboNombramiento.DataBind();

                if (Int32.Parse(Request.QueryString["ROW"].ToString()) != 1)
                {
                    ListItem removeItem2 = cboNombramiento.Items.FindByText("Definitivo");
                    cboNombramiento.Items.Remove(removeItem2);
                }

                cboEstatFinal.Items.Clear();
                cboEstatFinal.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboEstatFinal.AppendDataBoundItems = true;
                cboEstatFinal.DataSource = _nCargarDatos.datos.Tables[3];
                cboEstatFinal.DataTextField = _nCargarDatos.datos.Tables[3].Columns[1].Caption.ToString();
                cboEstatFinal.DataValueField = _nCargarDatos.datos.Tables[3].Columns[0].Caption.ToString();
                cboEstatFinal.DataBind();

                cboNEstatus.Items.Clear();
                cboNEstatus.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboNEstatus.AppendDataBoundItems = true;
                cboNEstatus.DataSource = _nCargarDatos.datos.Tables[4];
                cboNEstatus.DataTextField = _nCargarDatos.datos.Tables[4].Columns[1].Caption.ToString();
                cboNEstatus.DataValueField = _nCargarDatos.datos.Tables[4].Columns[0].Caption.ToString();
                cboNEstatus.DataBind();
                ListItem removeItem = cboNEstatus.Items.FindByText("Idóneo sin asignar");
                cboNEstatus.Items.Remove(removeItem);

                if (Session["TipoNom"].ToString() == "Definitivo")
                { this.btnActualizar.Enabled = false; }
            }
        }

        protected void LlenaEstatus(int Opcion)
        {
            Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
            _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_Sel_NuevoEstatusAsignacion;
            _nCargarDatos.Opcion = Opcion;
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                cboNEstatus.Items.Clear();
                cboNEstatus.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboNEstatus.AppendDataBoundItems = true;
                cboNEstatus.DataSource = _nCargarDatos.datos.Tables[0];
                cboNEstatus.DataTextField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                cboNEstatus.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                cboNEstatus.DataBind();
            }
        }

        protected void ObtieneEstaus()
        {
            Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
            _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_ObtieneEstatus;
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                cboNEstatus.Items.Clear();
                cboNEstatus.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboNEstatus.AppendDataBoundItems = true;
                cboNEstatus.DataSource = _nCargarDatos.datos.Tables[0];
                cboNEstatus.DataTextField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                cboNEstatus.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                cboNEstatus.DataBind();
            }
        }

        protected void cboNEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(cboNEstatus.SelectedValue.ToString()) == 3)
            { cboEstatFinal.Enabled = true; }
            else
            { cboEstatFinal.Enabled = false; }
        }

        /// <summary>
        /// Actualiza la información.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cboEstatFinal.Enabled == true) && (Int32.Parse(cboEstatFinal.SelectedValue.ToString()) == 0))
                {
                    new WebNegocio.Utils().Mensaje(this.Page, "Debe seleccionar un motivo de rechazo válido.");
                    return;
                }
                else
                {
                    /* 
                     * Validar que aún existan vacantes disponibles, se checa la prelacion 1, 2 e historico
                     */
                    Negocio.Asignacion _Comprobacion = new Negocio.Asignacion();
                    _Comprobacion.Proc = Negocio.Asignacion.Procedimientos.spt_SEL_ASIGNACION_COMPROBACION;
                    _Comprobacion.DescCCT = txtDescripcionCCT.Text.ToString();
                    _Comprobacion.SubSis = Int32.Parse((string)Session["ClaveSubsistemaAsignacion"]);
                    _Comprobacion.DesEntidadAsignacion = Session["DesEntidadAsignacion"].ToString();
                    _Comprobacion.Busqueda();
                    if (_Comprobacion.datos != null)
                    {
                        if (_Comprobacion.datos.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            new WebNegocio.Utils().Mensaje(this.Page, "No existen plazas disponibles para la relación seleccionada.");
                            return;
                        }
                        else
                        {
                            DataTable Tabla = (DataTable)Session["TablaAspirantes"];
                            int iContador1 = 0, iContador2 = 0;

                            if (Session["Actualiza"].ToString() == "SI")
                            {
                                Negocio.Asignacion _Actualizar = new Negocio.Asignacion();
                                if (Session["ClaveNom"] == null)
                                { _Actualizar.ClaveNombramiento = 0; }
                                else
                                { _Actualizar.ClaveNombramiento = Int32.Parse(Session["ClaveNom"].ToString()); }
                                _Actualizar.Entidad = Int32.Parse((string)Session["ClaveEntidadAsignacion"]);
                                _Actualizar.SubSis = Int32.Parse((string)Session["ClaveSubsistemaAsignacion"]);
                                _Actualizar.CURP = lblCURP.Text.ToString().ToUpper().Trim();
                                _Actualizar.ClaveCCT = txtCCT.Text.ToString().ToUpper();
                                _Actualizar.DescCCT = txtDescripcionCCT.Text.ToString();
                                _Actualizar.EfectoNombramiento = txtEfectoNom.Text;
                                _Actualizar.TipoPlaza = int.Parse(cboTipoPlaza.SelectedValue);
                                _Actualizar.CvePresupuestal = txtClavePrep.Text;
                                _Actualizar.Turno = int.Parse(cboTurno.SelectedValue);
                                _Actualizar.EstatusAsignacion = int.Parse(cboNEstatus.SelectedValue);
                                _Actualizar.TipoNombramiento = Int32.Parse(cboNombramiento.SelectedValue.ToString());
                                _Actualizar.EstatusAsignacion = Int32.Parse(cboNEstatus.SelectedValue.ToString());
                                if (cboEstatFinal.Enabled == true)
                                { _Actualizar.EstatusRechazo = Int32.Parse(cboEstatFinal.SelectedValue.ToString()); }
                                else
                                { _Actualizar.EstatusRechazo = 0; }
                                _Actualizar.FolioFed = lblFolioFed.Text;
                                if (ckbGenerarFolio.Checked == true)
                                { _Actualizar.FolioGenerado = "1"; }
                                else
                                { _Actualizar.FolioGenerado = "0"; }
                                _Actualizar.UsuarioGenera = Session["id_Usuario"].ToString();

                                if (cboNombramiento.SelectedValue == "3")
                                {
                                    _Actualizar.FechaInicio = null; _Actualizar.FechaTermino = null;
                                }
                                else
                                {
                                    if (tb_StartDate.Visible == false && tb_EndDate.Visible == false)
                                    {
                                        _Actualizar.FechaInicio = null;
                                        _Actualizar.FechaTermino = null;
                                    }
                                    else
                                    {
                                        DateTime dtFechaInicio, dtFechaTermino;
                                        dtFechaInicio = tb_StartDate.SelectedDate;
                                        dtFechaTermino = tb_EndDate.SelectedDate;
                                        if (dtFechaInicio > dtFechaTermino)
                                        {
                                            new WebNegocio.Utils().Mensaje(this.Page, "La fecha de inicio no puede ser mayor a la fecha de termino.");
                                            return;
                                        }
                                        else
                                        {
                                            _Actualizar.FechaInicio = dtFechaInicio;
                                            _Actualizar.FechaTermino = dtFechaTermino;
                                        }
                                    }
                                }
                                _Actualizar.prelacion = int.Parse(Session["listaPrelacion"].ToString());
                                _Actualizar.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_INS_ASIGNACION;
                                _Actualizar.Busqueda();
                                if (_Actualizar.datos != null)
                                {
                                    new WebNegocio.Utils().Mensaje(this.Page, "Asignación generada correctamente.");
                                    PoblarGridView();
                                }
                                else
                                { new WebNegocio.Utils().Mensaje(this.Page, "No se pudo generar la Asignación."); }
                                return;
                            }
                            else
                            {
                                if (Tabla == null)
                                {
                                    Negocio.Asignacion _Actualizar = new Negocio.Asignacion();
                                    if (Session["ClaveNom"] == null)
                                    { _Actualizar.ClaveNombramiento = 0; }
                                    else
                                    { _Actualizar.ClaveNombramiento = Int32.Parse(Session["ClaveNom"].ToString()); }
                                    _Actualizar.Entidad = Int32.Parse((string)Session["ClaveEntidadAsignacion"]);
                                    _Actualizar.SubSis = Int32.Parse((string)Session["ClaveSubsistemaAsignacion"]);
                                    _Actualizar.CURP = lblCURP.Text.ToString().ToUpper().Trim();
                                    _Actualizar.ClaveCCT = txtCCT.Text.ToString().ToUpper();
                                    _Actualizar.DescCCT = txtDescripcionCCT.Text.ToString().Trim();
                                    _Actualizar.EfectoNombramiento = txtEfectoNom.Text;
                                    _Actualizar.TipoPlaza = int.Parse(cboTipoPlaza.SelectedValue);
                                    _Actualizar.CvePresupuestal = txtClavePrep.Text;
                                    _Actualizar.Turno = int.Parse(cboTurno.SelectedValue);
                                    _Actualizar.EstatusAsignacion = int.Parse(cboNEstatus.SelectedValue);
                                    _Actualizar.TipoNombramiento = Int32.Parse(cboNombramiento.SelectedValue.ToString());
                                    _Actualizar.EstatusAsignacion = Int32.Parse(cboNEstatus.SelectedValue.ToString());
                                    if (cboEstatFinal.Enabled == true)
                                    { _Actualizar.EstatusRechazo = Int32.Parse(cboEstatFinal.SelectedValue.ToString()); }
                                    else
                                    { _Actualizar.EstatusRechazo = 0; }
                                    _Actualizar.FolioFed = lblFolioFed.Text;
                                    if (ckbGenerarFolio.Checked == true)
                                    { _Actualizar.FolioGenerado = "1"; }
                                    else
                                    { _Actualizar.FolioGenerado = "0"; }
                                    _Actualizar.UsuarioGenera = Session["id_Usuario"].ToString();
                                    if (cboNombramiento.SelectedValue == "3")
                                    {
                                        _Actualizar.FechaInicio = null; _Actualizar.FechaTermino = null;
                                    }
                                    else
                                    {
                                        if (tb_StartDate.Visible == false && tb_EndDate.Visible == false)
                                        {
                                            _Actualizar.FechaInicio = null;
                                            _Actualizar.FechaTermino = null;
                                        }
                                        else
                                        {
                                            DateTime dtFechaInicio, dtFechaTermino;
                                            dtFechaInicio = tb_StartDate.SelectedDate;
                                            dtFechaTermino = tb_EndDate.SelectedDate;
                                            if (dtFechaInicio > dtFechaTermino)
                                            {
                                                new WebNegocio.Utils().Mensaje(this.Page, "La fecha de inicio no puede ser mayor a la fecha de termino.");
                                                return;
                                            }
                                        }
                                    }
                                    _Actualizar.prelacion = int.Parse(Session["listaPrelacion"].ToString());
                                    _Actualizar.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_INS_ASIGNACION;
                                    _Actualizar.Busqueda();
                                    if (_Actualizar.datos != null)
                                    {
                                        new WebNegocio.Utils().Mensaje(this.Page, "Asignación generada correctamente.");
                                        PoblarGridView();
                                    }
                                    else
                                    { new WebNegocio.Utils().Mensaje(this.Page, "No se pudo generar la Asignación."); }
                                    return;
                                }
                                else
                                {
                                    foreach (DataRow row in Tabla.Rows)
                                    {
                                        if (row[8].ToString() == "Provisional")
                                        { iContador1 = 1; }
                                        if (row[8].ToString() == "Definitivo")
                                        { iContador2 = 1; }
                                    }

                                    if (iContador1 == iContador2)
                                    {
                                        new WebNegocio.Utils().Mensaje(this.Page, "No es posible agregar más plazas.");
                                        return;
                                    }
                                    else
                                    {
                                        Negocio.Asignacion _Actualizar = new Negocio.Asignacion();
                                        if (Session["ClaveNom"] == null)
                                        { _Actualizar.ClaveNombramiento = 0; }
                                        else
                                        { _Actualizar.ClaveNombramiento = Int32.Parse(Session["ClaveNom"].ToString()); }
                                        _Actualizar.Entidad = Int32.Parse((string)Session["ClaveEntidadAsignacion"]);
                                        _Actualizar.SubSis = Int32.Parse((string)Session["ClaveSubsistemaAsignacion"]);
                                        _Actualizar.CURP = lblCURP.Text.ToString().ToUpper().Trim();
                                        _Actualizar.ClaveCCT = txtCCT.Text.ToString().ToUpper();
                                        _Actualizar.DescCCT = txtDescripcionCCT.Text.ToString();
                                        _Actualizar.EfectoNombramiento = txtEfectoNom.Text;
                                        _Actualizar.TipoPlaza = int.Parse(cboTipoPlaza.SelectedValue);
                                        _Actualizar.CvePresupuestal = txtClavePrep.Text;
                                        _Actualizar.Turno = int.Parse(cboTurno.SelectedValue);
                                        _Actualizar.EstatusAsignacion = int.Parse(cboNEstatus.SelectedValue);
                                        _Actualizar.TipoNombramiento = Int32.Parse(cboNombramiento.SelectedValue.ToString());
                                        _Actualizar.EstatusAsignacion = Int32.Parse(cboNEstatus.SelectedValue.ToString());
                                        if (cboEstatFinal.Enabled == true)
                                        { _Actualizar.EstatusRechazo = Int32.Parse(cboEstatFinal.SelectedValue.ToString()); }
                                        else
                                        { _Actualizar.EstatusRechazo = 0; }
                                        _Actualizar.FolioFed = lblFolioFed.Text;
                                        if (ckbGenerarFolio.Checked == true)
                                        { _Actualizar.FolioGenerado = "1"; }
                                        else
                                        { _Actualizar.FolioGenerado = "0"; }
                                        _Actualizar.UsuarioGenera = Session["id_Usuario"].ToString();
                                        if (cboNombramiento.SelectedValue == "3")
                                        {
                                            _Actualizar.FechaInicio = null; _Actualizar.FechaTermino = null;
                                        }
                                        else
                                        {
                                            if (tb_StartDate.Visible == false && tb_EndDate.Visible == false)
                                            {
                                                _Actualizar.FechaInicio = null;
                                                _Actualizar.FechaTermino = null;
                                            }
                                            else
                                            {
                                                DateTime dtFechaInicio, dtFechaTermino;
                                                dtFechaInicio = tb_StartDate.SelectedDate;
                                                dtFechaTermino = tb_EndDate.SelectedDate;
                                                if (dtFechaInicio > dtFechaTermino)
                                                {
                                                    new WebNegocio.Utils().Mensaje(this.Page, "La fecha de inicio no puede ser mayor a la fecha de termino.");
                                                    return;
                                                }
                                            }
                                        }
                                        _Actualizar.prelacion = int.Parse(Session["listaPrelacion"].ToString());
                                        _Actualizar.Proc = Negocio.Asignacion.Procedimientos.spt_Asignacion_INS_ASIGNACION;
                                        _Actualizar.Busqueda();
                                        if (_Actualizar.datos != null)
                                        {
                                            new WebNegocio.Utils().Mensaje(this.Page, "Asignación generada correctamente.");
                                            PoblarGridView();
                                        }
                                        else
                                        { new WebNegocio.Utils().Mensaje(this.Page, "No se pudo generar la Asignación."); }
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                new WebNegocio.Utils().Mensaje(this.Page, "No se pudo generar la Asignación verifique su captura.");
                return;
            }
        }

        protected void cboTipoPlaza_SelectedIndexChanged(object sender, EventArgs e)
        { }

        protected void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        { txtDescripcionCCT.Text = ""; }

        protected void grNombramientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtieneEstaus();
            GridViewRow fila = grNombramientos.SelectedRow;
            Negocio.Asignacion _obAsignacion = new Negocio.Asignacion();
            _obAsignacion.Proc = Negocio.Asignacion.Procedimientos.spt_SEL_TiposNombramientoAspiranteDetalle;
            _obAsignacion.ClaveNombramiento = int.Parse(fila.Cells[1].Text);
            _obAsignacion.CURP = Request.QueryString["CURP"].Trim().ToString();
            _obAsignacion.Busqueda();
            if (_obAsignacion.datos != null)
            {
                this.txtCCT.Text = _obAsignacion.datos.Tables[0].Rows[0][0].ToString();
                this.txtDescripcionCCT.Text = _obAsignacion.datos.Tables[0].Rows[0][1].ToString();
                this.txtEfectoNom.Text = _obAsignacion.datos.Tables[0].Rows[0][2].ToString();
                this.cboTipoPlaza.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][3].ToString();
                this.txtClavePrep.Text = _obAsignacion.datos.Tables[0].Rows[0][4].ToString();
                this.cboTurno.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][5].ToString();
                this.cboNEstatus.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][6].ToString();
                if (int.Parse(_obAsignacion.datos.Tables[0].Rows[0][7].ToString()) == 3)
                {
                    if (cboNombramiento.Items.Count == 4)
                    { cboNombramiento.SelectedIndex = 3; }
                    else
                    { this.cboNombramiento.Items.Insert(3, new ListItem("Definitivo")); this.cboNombramiento.SelectedIndex = 3; }
                }
                else
                { this.cboNombramiento.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][7].ToString(); }
                if (_obAsignacion.datos.Tables[0].Rows[0][8].ToString() == "0")
                { this.cboEstatFinal.SelectedIndex = 0; }
                else
                { this.cboEstatFinal.SelectedValue = _obAsignacion.datos.Tables[0].Rows[0][8].ToString(); }

                if (_obAsignacion.datos.Tables[0].Rows[0][9].ToString() == null || _obAsignacion.datos.Tables[0].Rows[0][9].ToString() == "")
                {
                    FechaInicio.Visible = false;
                    FechaTermino.Visible = false;
                    tb_StartDate.Visible = false;
                    tb_EndDate.Visible = false;
                }
                else
                {
                    FechaInicio.Visible = true;
                    FechaTermino.Visible = true;
                    tb_StartDate.Visible = true;
                    tb_EndDate.Visible = true;
                    tb_StartDate.SelectedValue = DateTime.Parse(_obAsignacion.datos.Tables[0].Rows[0][9].ToString());
                    tb_EndDate.SelectedValue = DateTime.Parse(_obAsignacion.datos.Tables[0].Rows[0][10].ToString());
                }

                Session["ClaveNom"] = fila.Cells[1].Text;
                Session["Actualiza"] = "SI";
            }
        }

        protected void grNombramientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Negocio.Asignacion _obAsignacion = new Negocio.Asignacion();
            _obAsignacion.Proc = Negocio.Asignacion.Procedimientos.SPT_DEL_EliminaAspiranteAsignacionDetalle;
            _obAsignacion.ClaveNombramiento = Int32.Parse(grNombramientos.Rows[e.RowIndex].Cells[1].Text);
            _obAsignacion.Busqueda();
            if (_obAsignacion.datos != null)
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Se elimino la información correctamente.");
                PoblarGridView();
                return;
            }
            else
            {
                new WebNegocio.Utils().Mensaje(this.Page, "Ocurrio un error al eliminar la información.");
                return;
            }
        }

        protected void grNombramientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow row = (e.Row.DataItem as DataRowView).Row;
                if (row["firma"].ToString() != "")
                {
                    if (int.Parse(row["firma"].ToString()) == 1 && row["firma"].ToString() != "")
                    {
                        e.Row.Cells[0].Enabled = false;
                        e.Row.Cells[12].Enabled = false;
                    }
                }
            }
        }

        protected void cboNombramiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNombramiento.SelectedIndex == 1 || cboNombramiento.SelectedIndex == 2)
            { LlenaEstatus(1); }
            else if (cboNombramiento.SelectedIndex == 3)
            { LlenaEstatus(2); }

            if (cboNombramiento.SelectedItem.Text != "Definitivo")
            {
                FechaInicio.Visible = true;
                FechaTermino.Visible = true;
                tb_StartDate.Visible = true;
                tb_EndDate.Visible = true;
            }
            else
            {
                FechaInicio.Visible = false;
                FechaTermino.Visible = false;
                tb_StartDate.Visible = false;
                tb_EndDate.Visible = false;
            }
        }
    }
}