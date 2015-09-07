using System;
using Negocio;

namespace WFront
{
    public partial class Cat_TipoNombramiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocio.Ent_Usuario _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
            Buscar(_Ent_Usuario);
        }
        private void Buscar(Ent_Usuario _Ent_Usuario)
        {
            try
            {
                Negocio.Reportes rep = new Negocio.Reportes();
                rep._Ent_Usuario = new ReportesArg { _Ent_Usuario = _Ent_Usuario };
                rep.Proc = Negocio.Reportes.Procedimientos.spt_Asignacion_SEL_Cat_TipoNombramiento;
                rep.Busqueda();

                if (rep.datos != null)
                {
                    gvReporte.DataSource = rep.datos;
                    gvReporte.DataBind();
                    gvReporte.Visible = true;
                }
            }
            catch
            {
            }
        }
    }
}