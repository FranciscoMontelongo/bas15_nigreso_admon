using System;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace WFront.TableroC
{
    public partial class Resumen : System.Web.UI.Page
    {
        Ent_Usuario _Ent_Usuario = new Ent_Usuario();
        DataSet ds = new DataSet();
        Negocio.TableroC _TableroC = new Negocio.TableroC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _Ent_Usuario = (Ent_Usuario)Session["Info_User"];
                ObtenEntidadTodos();
                //if (_Ent_Usuario.ClaveEntidad == null) {
                //    _Ent_Usuario.ClaveEntidad = "1";
                //}
                cbo_Entidad.SelectedValue = _Ent_Usuario.ClaveEntidad;                    
                fillGV();
                Get_Info();
                if (_Ent_Usuario.Perfil == "O" || _Ent_Usuario.Perfil == "I")
                {
                    cbo_Entidad.Enabled = true;
                }
            }
        }

        private void fillGV()
        {
            _TableroC.TableroCA.CveEntidad = _Ent_Usuario.ClaveEntidad;                
            _TableroC.Proc = Negocio.TableroC.Procedimientos.spt_SEL_ObtenTotalAspirantes;
            _TableroC.Busqueda();            
            gvObtenTotalAspirantes.fillGridView(_TableroC.datos);

            _TableroC.Proc = Negocio.TableroC.Procedimientos.spt_SEL_ObtenTipoPlazaHoras;
            _TableroC.Busqueda();
            gvTipoPlazaHoras.fillGridView(_TableroC.datos);

            _TableroC.Proc = Negocio.TableroC.Procedimientos.spt_SEL_ObtenTipoSostenimientoHoras;
            _TableroC.Busqueda();
            gvTipoSostenimiento.fillGridView(_TableroC.datos);


            //ds = _catalogos.obtentiposostenimiento(_ent_usuario);
            //gvtiposostenimiento.cargagrid(ds);

            //if (ds != null)
            //{
            //    ds.clear();
            //}

            //ds = _catalogos.obtentipovacante(_ent_usuario);
            //gvtipovacante.cargagrid(ds);
        }

        private void ObtenEntidadTodos()
        {                        
            _TableroC.Proc = Negocio.TableroC.Procedimientos.spt_SEL_SeleccionarEntidad;
            _TableroC.Busqueda();
            cbo_Entidad.fillddl(_TableroC.datos);
            //DataSet ds = new DataSet();
            //ds = _Catalogos.ObtenEntidadTodos();
            //cbo_Entidad.Items.Clear();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = dr["Descripcion"].ToString();
            //    li.Value = dr["ClaveEntidad"].ToString();
            //    cbo_Entidad.Items.Add(li);
            //}
        }
        private void Get_Info()
        {
            //try
            //{
            //    Ent_Usuario _Ent_Usuario2 = new Ent_Usuario();
            //    _Ent_Usuario2.ClaveEntidad = cbo_Entidad.SelectedValue;
            //    _Ent_Usuario2.ds = _TC_Resumen.ObtenTableroResumen(_Ent_Usuario2);
            //    if (_Ent_Usuario2.ds != null)
            //    {
            //        foreach (DataRow dr in _Ent_Usuario2.ds.Tables[0].Rows)
            //        {
            //            //ASPIRANTES
            //            sASPTotal.InnerText = dr["AspirantesTotal"].ToString();
            //            sASPPlazaAsignada.InnerText = dr["AspirantesAsignados"].ToString();
            //            sASPRechazados.InnerText = dr["AspirantesRechazados"].ToString();
            //            sASPMasDeUnaPlaza.InnerText = dr["AspirantesMasDeUnaAsignacion"].ToString();
            //        }
            //    }
            //}
            //catch { }
        }

        protected void cbo_Entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Ent_Usuario.ClaveEntidad = cbo_Entidad.SelectedValue;
            fillGV();
            Get_Info();
        }
        protected void ddlConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Ent_Usuario.ClaveEntidad = cbo_Entidad.SelectedValue;
            fillGV();
            Get_Info();
            //MensajeSeleccion();            
        }

        protected void gvTipoSostenimiento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[0].Width = 200;
            }
        }

        protected void gvTipoVacante_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.Footer))
            {
                e.Row.Cells[0].Width = 100;
                e.Row.Cells[1].Width = 150;
                e.Row.Cells[2].Width = 150;
            }
        }
    }
}