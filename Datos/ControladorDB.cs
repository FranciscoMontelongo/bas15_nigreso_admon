using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Web;

namespace Datos
{
    public class ControladorDB
    {
        #region Constructores
        public ControladorDB(string dataNameConnectionInConfigFile)
        {
            _exception = null;
            _dataNameConnectionInConfigFile = dataNameConnectionInConfigFile;
            try
            { _dbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[_dataNameConnectionInConfigFile].ProviderName); }
            catch (Exception ex)
            {
                _exception = new Exception("No fue posible obtener el proveedor de datos especificado en el archivo de configuración de la aplicación.", ex);
                return;
            }
            _command = _dbFactory.CreateCommand();
            _command.CommandType = CommandType.StoredProcedure;
            _command.Connection = _dbFactory.CreateConnection();
        }
        #endregion
        #region Miembros
        // Representa una Fabrica del tipo de Proveedor establecido.
        private readonly DbProviderFactory _dbFactory;
        // Nombre de la conección de base de datos en el archivo de configuración de la aplicación.        
        private readonly string _dataNameConnectionInConfigFile = string.Empty;
        // Representa un Command del tipo de Proveedor establecido.        
        private readonly DbCommand _command;
        // Campo para manipular las excepciones internas.
        private Exception _exception;
        #endregion

        #region Propiedades

        // Si se obtuvo una excepción, en esta propiedad puede ser leida.
        public Exception exception
        {
            get { return _exception; }
        }

        #endregion

        #region Metodos Privados

        // Agrega los parámetros al DbCommand interno.
        // <param name="parametros">Parámetros a agregar al DbCommand.</param>
        private void AddParameters(DbParameter[] parametros)
        {
            _command.Parameters.Clear();
            for (int i = 0; i < parametros.Length; i++)
                _command.Parameters.Add(parametros[i]);
        }

        private void AddParams(List<DataParam> parametros)
        {
            DbParameter[] Parametro = new DbParameter[parametros.Count];
            for (int i = 0; i < parametros.Count; i++)
            {
                Parametro[i] = CreateParameter();
                Parametro[i].ParameterName = parametros[i].Name;
                Parametro[i].Value = parametros[i].Value;
            }
            AddParameters(Parametro);
        }

        #endregion

        #region Metodos Publicos

        // Crea e inicializa un DbParameter.
        // <returns>DbParameter</returns>
        public DbParameter CreateParameter()
        {
            return _command.CreateParameter();
        }

        // Obtiene un DataSet, a partir de un Stored Procedure.
        // <param name="storedProcedureName">Nombre del Stored Procedure.</param>
        // <param name="parametros">Parámetros del Stored Procedure.</param>
        // <returns>DataSet</returns>
        public DataSet ExecuteDataSet(string storedProcedureName, params DbParameter[] parametros)
        {
            _command.CommandText = storedProcedureName;
            if (parametros.Length > 0)
                AddParameters(parametros);
            try
            {
                return DatabaseFactory.CreateDatabase(_dataNameConnectionInConfigFile).ExecuteDataSet(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return null;
            }
        }

        public DataSet ExecuteDataSetdb(string storedProcedureName, List<DataParam> lparametros)
        {
            _command.CommandText = storedProcedureName;
            _command.CommandTimeout = 600;
            if (lparametros.Count > 0)
                AddParams(lparametros);
            try
            {
                Database _dbFact = DatabaseFactory.CreateDatabase(_dataNameConnectionInConfigFile);
                return _dbFact.ExecuteDataSet(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return new DataSet();
            }
        }

        // Obtiene un int, resultado de un Stored Procedure.
        // <param name="storedProcedureName">Nombre del Stored Procedure.</param>
        // <param name="parametros">Parámetros del Stored Procedure.</param>
        // <returns>int</returns>
        public int ExecuteNonQuery(string storedProcedureName, params DbParameter[] parametros)
        {
            _command.CommandText = storedProcedureName;
            if (parametros.Length > 0)
                AddParameters(parametros);
            try
            {
                return DatabaseFactory.CreateDatabase(_dataNameConnectionInConfigFile).ExecuteNonQuery(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return 0;
            }
        }

        // Obtiene un IDataReader, resultado de un Stored Procedure.
        // <param name="storedProcedureName">Nombre del Stored Procedure.</param>
        // <param name="parametros">Parámetros del Stored Procedure.</param>
        // <returns>IDataReader</returns>
        public IDataReader ExecuteReader(string storedProcedureName, params DbParameter[] parametros)
        {
            _command.CommandText = storedProcedureName;
            if (parametros.Length > 0)
                AddParameters(parametros);
            try
            {
                return DatabaseFactory.CreateDatabase(_dataNameConnectionInConfigFile).ExecuteReader(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return null;
            }
        }

        // Obtiene un object, resultado de un Stored Procedure.
        // <param name="storedProcedureName">Nombre del Stored Procedure.</param>
        // <param name="parametros">Parámetros del Stored Procedure.</param>
        // <returns>object</returns>
        public object ExecuteScalar(string storedProcedureName, params DbParameter[] parametros)
        {
            _command.CommandText = storedProcedureName;
            if (parametros.Length > 0)
                AddParameters(parametros);
            try
            {
                return DatabaseFactory.CreateDatabase(_dataNameConnectionInConfigFile).ExecuteScalar(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return null;
            }
        }


        public DataSet ExecuteSQL(string sqlQuery)
        {
            _command.CommandType = CommandType.Text;
            _command.CommandText = sqlQuery;
            try
            {
                return DatabaseFactory.CreateDatabase(_dataNameConnectionInConfigFile).ExecuteDataSet(_command);
            }
            catch (Exception ex)
            {
                _exception = ex;
                return null;
            }
        }


        #endregion

    }
    public class DataParam
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public enum spAccion
    {
        Alta
       ,
        Baja
            ,
        Modificacion
            ,
        Consulta
            , ConsultaFiltros
    }
}
