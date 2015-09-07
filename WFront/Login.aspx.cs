using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WFront
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { LlenarPerfiles(); }
        }
        protected void LlenarPerfiles()
        {
            Negocio.Otros Consulta = new Negocio.Otros();
            Consulta.Proc = Negocio.Otros.Procedimientos.spt_Sel_Perfiles;
            Consulta.Busqueda();
            if (Consulta.datos != null)
            {
                cblPerfiles.Items.Clear();
                cblPerfiles.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
                cblPerfiles.AppendDataBoundItems = true;
                cblPerfiles.DataSource = Consulta.datos.Tables[0];
                cblPerfiles.DataTextField = Consulta.datos.Tables[0].Columns[1].Caption.ToString();
                cblPerfiles.DataValueField = Consulta.datos.Tables[0].Columns[0].Caption.ToString();
                cblPerfiles.DataBind();
            }
        }
        protected void btnAutenticarUsuario_Click(object sender, EventArgs e)
        {
            Negocio.Otros Consulta = new Negocio.Otros();
            Consulta.Proc = Negocio.Otros.Procedimientos.spt_SEL_ObtieneLogin;
            Consulta.Usuario = txtNombreUsuario.Text.Trim();
            Consulta.Contraseña = txtContrasenia.Text.Trim();
            Consulta.Perfil = cblPerfiles.SelectedValue.ToString().Trim();
            Consulta.Busqueda();
            if (Consulta.datos != null)
            {
                Negocio.Ent_Usuario _Ent_Usuario = new Negocio.Ent_Usuario();


                _Ent_Usuario.Id_Usuario = Consulta.datos.Tables[0].Rows[0][0].ToString();
                _Ent_Usuario.Usuario = Consulta.datos.Tables[0].Rows[0][1].ToString();
                _Ent_Usuario.NombreUsuario = Consulta.datos.Tables[0].Rows[0][2].ToString();
                _Ent_Usuario.Usuario_ClaveEntidad = Consulta.datos.Tables[0].Rows[0][3].ToString();
                _Ent_Usuario.Usuario_Entidad = Consulta.datos.Tables[0].Rows[0][4].ToString();
                _Ent_Usuario.Perfil = Consulta.datos.Tables[0].Rows[0][5].ToString();
                _Ent_Usuario.Concurso = System.Configuration.ConfigurationSettings.AppSettings["Concurso"].ToString();
                Session["Info_User"] = _Ent_Usuario;


                Response.Redirect("webDefault.aspx");

            }
            else
            {
                txtContrasenia.Text = "";
                txtNombreUsuario.Text = "";
                LlenarPerfiles();
                new WebNegocio.Utils().Mensaje(this.Page, "Usuario, contraseña o perfil invalidos.");
                return;
            }
        }
    }
}