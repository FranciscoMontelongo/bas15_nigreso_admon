using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Negocio;

namespace WFront
{
    public partial class webDefault : System.Web.UI.Page
    {
        private Ent_Usuario _Ent_Usuario { get { return (Ent_Usuario)Session["Info_User"]; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = _Ent_Usuario.NombreUsuario;
                MenuGenerar();
            }
        }

        protected void MenuGenerar()
        {
            #region Menu

            DataTable dt = new DataTable();
            Negocio.Otros _nCargarDatos = new Negocio.Otros();
            _nCargarDatos.id_Padre = 0;
            _nCargarDatos.id_Usuario = int.Parse(_Ent_Usuario.Id_Usuario);
            _nCargarDatos.Proc = Negocio.Otros.Procedimientos.usc_TS_ASIGNACIONMenu;
            _nCargarDatos.Busqueda();
            if (_nCargarDatos.datos != null)
            {
                dt = _nCargarDatos.datos.Tables[0];
                foreach (DataRow rw in dt.Rows)
                {
                    IEnumerable<MenuItem> menuItems = Extensions.GetItems<MenuItem>(menuConsultas.Items, item => item.ChildItems);
                    MenuItem parent = menuItems.FirstOrDefault(mi => mi.Value == rw.Field<int>("id_padre").ToString());
                    string _sURL = "#";
                    try
                    {
                        _sURL = rw["url"].ToString();
                        _sURL = _sURL.Replace("~/", "");
                    }
                    catch { }
                    MenuItem newItem = new MenuItem();
                    if (_sURL != "#")
                    { newItem = new MenuItem(rw["descripcion"].ToString(), _sURL); }
                    else
                    {
                        newItem = new MenuItem(rw.Field<string>("descripcion"), rw.Field<int>("id_menu").ToString(), "", "javascript: void(0);");
                        // newItem = new MenuItem(rw.Field<string>("descripcion"), "javascript: void(0);");
                    }

                    if (parent == null)
                        menuConsultas.Items.Add(newItem);
                    else
                        parent.ChildItems.Add(newItem);
                }
            }

            #endregion Menu
        }

        protected void menuConsultas_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (menuConsultas.SelectedValue == "Cerrar")
            {
                Session["usr"] = null;
                Session.Abandon();
                Response.Cache.SetNoStore();
                Response.CacheControl = "no-cache";
                Response.Redirect("Login.aspx");
            }
            else
            { I1.Attributes.Add("src", menuConsultas.SelectedValue.ToString()); }
        }
    }
}