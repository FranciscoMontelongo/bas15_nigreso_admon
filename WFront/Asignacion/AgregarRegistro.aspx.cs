using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFront.Asignacion
{
    public partial class AgregarRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtieneCatalogos();
                Session["Entidad"] = int.Parse(Request.QueryString["Entidad"].ToString());
                Session["Subsistema"] = int.Parse(Request.QueryString["Subsistema"].ToString());
                Session["Estatus"] = int.Parse(Request.QueryString["Estatus"].ToString());
                //Session["Asignatura"] = Request.QueryString["Asignatura"].ToString();
                Session["CURP"] = Request.QueryString["CURP"].ToString();
            }
        }
        protected void ObtieneCatalogos()
        {
            Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
            _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_ObtieneCatalogos;
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                cboTipoSostenimiento.Items.Clear();
                cboTipoSostenimiento.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboTipoSostenimiento.AppendDataBoundItems = true;
                cboTipoSostenimiento.DataSource = _nCargarDatos.datos.Tables[0];
                cboTipoSostenimiento.DataTextField = _nCargarDatos.datos.Tables[0].Columns[1].Caption.ToString();
                cboTipoSostenimiento.DataValueField = _nCargarDatos.datos.Tables[0].Columns[0].Caption.ToString();
                cboTipoSostenimiento.DataBind();

                cboTurno.Items.Clear();
                cboTurno.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboTurno.AppendDataBoundItems = true;
                cboTurno.DataSource = _nCargarDatos.datos.Tables[1];
                cboTurno.DataTextField = _nCargarDatos.datos.Tables[1].Columns[1].Caption.ToString();
                cboTurno.DataValueField = _nCargarDatos.datos.Tables[1].Columns[0].Caption.ToString();
                cboTurno.DataBind();

                cboNombramiento.Items.Clear();
                cboNombramiento.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cboNombramiento.AppendDataBoundItems = true;
                cboNombramiento.DataSource = _nCargarDatos.datos.Tables[2];
                cboNombramiento.DataTextField = _nCargarDatos.datos.Tables[2].Columns[1].Caption.ToString();
                cboNombramiento.DataValueField = _nCargarDatos.datos.Tables[2].Columns[0].Caption.ToString();
                cboNombramiento.DataBind();
            }
        }
        protected string Validaciones()
        {
            string mensaje = "";

            if (cboTipoRegistro.SelectedIndex == 0)
            {
                mensaje = "Debe de seleccionar un tipo de registro.";
            }
            else if (cboTipoSostenimiento.SelectedIndex == 0)
            {
                mensaje = "Debe de seleccionar un tipo de sostenimiento.";
            }
            else if (txtNombre.Text == "")
            {
                mensaje = "Debe de introducir un nombre.";
            }
            else if (txtApellidoPaterno.Text == "")
            {
                mensaje = "Debe de introducir el Apellido Paterno.";
            }
            else if(txtApellidoMaterno.Text=="")
            {
                mensaje = "Debe de introducir el Apellido Materno.";
            }
            else if (txtRFC.Text == "")
            {
                mensaje = "Debe de introducir el RFC.";
            }
            else if (cboTipo.SelectedIndex == 0)
            {
                mensaje = "Debe de seleccionar el tipo de perfil.";
            }
            else if (txtCorreo.Text == "")
            {
                mensaje = "Debe de introducir un correo.";
            }
            else if (txtDireccion.Text == "")
            {
                mensaje = "Debe de introducir una dirección.";
            }
            else if (txtTelefono.Text == "")
            {
                mensaje = "Debe de introducir un número de telefono.";
            }
            else if (txtTelefonoCelular.Text == "")
            {
                mensaje = "Debe de introducir un número de telefono celular.";
            }
            else if (cboTipoRegistro.SelectedValue == "2")
            {
                if (txtClaveCCT.Text == "")
                {
                    mensaje = "Debe de introducir la clave de centro de trabajo.";
                }
                else if (txtNombreCCT.Text == "")
                {
                    mensaje = "Debe de introducir el nombre del centro de trabajo.";
                }
                else if (cbTipoPlaza.SelectedIndex == 0)
                {
                    mensaje = "Debe de seleccionar el tipo de plaza.";
                }
                else if (txtHoras.Text == "")
                {
                    mensaje = "Debe de introducir el número de horas.";
                }
                else if (cboTurno.SelectedIndex == 0)
                {
                    mensaje = "Debe de seleccionar el turno.";
                }
                else if (cboNombramiento.SelectedIndex == 0)
                {
                    mensaje = "Debe de seleccionar el tipo de nombramiento.";
                }
            }

            return mensaje;
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = Validaciones();
                if (mensaje != "")
                {
                    new WebNegocio.Utils().Mensaje(this.Page, mensaje);
                    return;
                }
                else
                {
                    Negocio.Asignacion _nCargarDatos = new Negocio.Asignacion();
                    _nCargarDatos.Proc = Negocio.Asignacion.Procedimientos.spt_InertaNuevoRegistroAsignacion;
                    _nCargarDatos.Entidad = (int)Session["Entidad"];
                    _nCargarDatos.SubSis = (int)Session["Subsistema"];
                    _nCargarDatos.Estatus = (int)Session["Estatus"];
                    _nCargarDatos.CURP = Session["CURP"].ToString();
                    _nCargarDatos.TipoRegistro = int.Parse(cboTipoRegistro.SelectedValue);
                    _nCargarDatos.TipoSostenimiento = int.Parse(cboTipoSostenimiento.SelectedValue);
                    _nCargarDatos.Nombre = txtNombre.Text.ToUpper();
                    _nCargarDatos.ApeidoPaterno = txtApellidoPaterno.Text.ToUpper();
                    _nCargarDatos.ApeidoMaterno = txtApellidoMaterno.Text.ToUpper();
                    _nCargarDatos.RFC = txtRFC.Text.ToUpper();
                    _nCargarDatos.TipoPerfil = int.Parse(cboTipo.SelectedValue);
                    _nCargarDatos.Correo = txtCorreo.Text;
                    _nCargarDatos.Direccion = txtDireccion.Text;
                    _nCargarDatos.Telefono = Int64.Parse(txtTelefono.Text);
                    _nCargarDatos.TelefonoCelular = Int64.Parse(txtTelefonoCelular.Text);
                    if (cboTipoRegistro.SelectedValue == "2")
                    {
                        DatosAdicionales.Visible = true;
                        _nCargarDatos.ClaveCCT = txtClaveCCT.Text;
                        _nCargarDatos.DescCCT = txtNombreCCT.Text;
                        _nCargarDatos.TipoPlaza = int.Parse(cbTipoPlaza.SelectedValue);
                        if (cbTipoPlaza.SelectedValue == "1")
                        {
                            _nCargarDatos.Jornada = 1;
                            _nCargarDatos.Horas = 0;
                        }
                        else
                        {
                            _nCargarDatos.Jornada = 0;
                            _nCargarDatos.Horas = int.Parse(txtHoras.Text);
                        }
                        _nCargarDatos.Turno = int.Parse(cboTurno.SelectedValue);
                        _nCargarDatos.TipoNombramiento = int.Parse(cboNombramiento.SelectedValue);
                    }
                    else
                    {
                        _nCargarDatos.ClaveCCT = null;
                        _nCargarDatos.DescCCT = null;
                        _nCargarDatos.TipoPlaza = 0;
                        _nCargarDatos.Jornada = 0;
                        _nCargarDatos.Horas = null;
                        _nCargarDatos.Jornada = null;
                        _nCargarDatos.Horas = null;
                        _nCargarDatos.Turno = 0;
                        _nCargarDatos.TipoNombramiento = 0;
                    }
                    _nCargarDatos.Busqueda();
                    if (_nCargarDatos.datos != null)
                    {
                        string Nombre = txtNombre.Text.ToUpper() + " " + txtApellidoPaterno.Text.ToUpper() + " " + txtApellidoMaterno.Text.ToUpper();
                        Response.Redirect("EditarAsignacion.aspx?CURP=" + Session["CURP"].ToString() + "&EstaSelDesc=" + " " + "&FOLFE=" + " " + "&Nom=" + Nombre +
                                                               "&TipoNom=" + cboNombramiento.SelectedItem.Text + "&CCT=" + txtClaveCCT.Text +
                                                               "&pkResultados=" + _nCargarDatos.datos.Tables[0].Rows[0][0].ToString() + "&ROW=" + 1 + "&Adicional=1", false);

                        cboTipoRegistro.SelectedIndex = 0; cboTipoSostenimiento.SelectedIndex = 0;
                        txtNombre.Text = ""; txtRFC.Text = "";
                        cboTipo.SelectedIndex = 0; txtCorreo.Text = ""; txtDireccion.Text = "";
                        txtTelefono.Text = ""; txtTelefonoCelular.Text = ""; txtClaveCCT.Text = "";
                        txtNombreCCT.Text = ""; cbTipoPlaza.SelectedIndex = 0; txtHoras.Text = "";
                        cboTurno.SelectedIndex = 0; cboNombramiento.SelectedIndex = 0;
                        DatosAdicionales.Visible = false;
                    }
                    else
                    {
                        new WebNegocio.Utils().Mensaje(this.Page, "Ocurrio un error al guardar la información.");
                        return;
                    }
                }
            }
            catch (Exception mensaje)
            { throw new Exception(mensaje.ToString()); }
        }
        protected void cboTipoRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoRegistro.SelectedValue == "2")
            { this.DatosAdicionales.Visible = true; }
            else
            { this.DatosAdicionales.Visible = false; }
        }
        protected void cbTipoPlaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbTipoPlaza.SelectedIndex == 1)
            {
                this.txtHoras.Text = "0";
                this.txtHoras.Enabled = false;
            }
            else
            {
                this.txtHoras.Text = "";
                this.txtHoras.Enabled = true;
            }
        }
    }
}