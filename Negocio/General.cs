using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Negocio
{

    public abstract class General
    {
        public List<DataParam> _lparam;
        private string _StoreProcedure;
        public string StoreProcedure { set { _StoreProcedure = value; } }

        //private string _TipoConexion;
        //public string TipoConexion { get { return _TipoConexion; } set { _TipoConexion = value; } }

        private DataSet _ds = null;
        public DataSet datos { get { return _ds; } }

        public General()
        { _ds = new DataSet(); }


        //public string Entity()
        //{
        //    string entity = "0";
        //    HttpContext httpContext = HttpContext.Current;
        //    try
        //    {
        //        if (httpContext.ApplicationInstance.Session.Count > 0)
        //            entity = httpContext.ApplicationInstance.Session["Conexion"].ToString();
        //    }
        //    catch
        //    { }
        //    return entity;
        //}

        public void Busqueda()
        {
            _ds = new DataSet();
            Datos.Datos _Datos = new Datos.Datos();
            LlenaParametros();
            _Datos.lparams = _lparam;
            //TipoConexion = Entity();
            _ds = _Datos.RecuperarDatos(_StoreProcedure);
            if (_ds == null || _ds.Tables.Count == 0 || _ds.Tables[0].Rows.Count == 0)
            { _ds = null; }
        }

        // Montel Este metodo lo borraron; yo lo regreso...
        public void GuardaInformacion()
        {
            _ds = new DataSet();
            Datos.Datos _Datos = new Datos.Datos();

            if (_lparam == null)
                _lparam = new List<DataParam>();

            LlenaParametros();
            _Datos.lparams = _lparam;
            _ds = _Datos.RecuperarDatos(_StoreProcedure);
            if (_ds == null || _ds.Tables.Count == 0 || _ds.Tables[0].Rows.Count == 0)
            { _ds = null; }
        }

        public void BusquedaTalCual()
        {
            _ds = new DataSet();
            Datos.Datos _Datos = new Datos.Datos();
            LlenaParametros();
            _Datos.lparams = _lparam;
            //TipoConexion = Entity();
            _ds = _Datos.RecuperarDatos(_StoreProcedure);
        }

        public virtual void LlenaParametros()
        { }
    }
}
