using System;
using System.Data;
using System.Collections.Generic;
using Datos;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Datos
{
    public class Datos
    {
        private Exception _exception;
        public Exception exception { get { return _exception; } }
        private List<DataParam> _lparams = new List<DataParam>();
        public List<DataParam> lparams { get { return _lparams; } set { _lparams = value; } }

        public DataSet RecuperarDatos(string _strStoreProcedure)
        {
            _exception = null;
            ControladorDB Acceso = new ControladorDB("CONAPD13");
            DataSet ds = new DataSet();
            try
            {
                if (Acceso.exception == null)
                {
                    ds = Acceso.ExecuteDataSetdb(_strStoreProcedure, _lparams);
                    if (Acceso.exception != null)
                    { _exception = new Exception("Error de base de datos", Acceso.exception); }
                }
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                _exception = ex;
            }
            return ds;
        }
    }
}
