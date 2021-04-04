using Netactica.Tools.StringTools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Netactica.Data
{
    /// <summary>
    /// Clase de conexion
    /// </summary>
    public class DataConnections : IDataConnections, IDisposable
    {
        /// <summary>
        /// Obtiene la conexion actual de base de datos
        /// </summary>
        public IDbConnection DataBase { get {
                if (_dataBase == null)
                    _dataBase = GetSqlConnection("DefaultDatabase");
                else
                    if (_dataBase.ConnectionString == string.Empty)
                    _dataBase.ConnectionString = "DefaultDatabase".ReadConnections();

                return _dataBase;
            } }

        /// <summary>
        /// Variables para la conexion actual
        /// </summary>
        private IDbConnection _dataBase;

        /// <summary>
        /// 
        /// </summary>
        public DataConnections()
        {
            _dataBase = GetSqlConnection("DefaultDatabase");
        }

        /// <summary>
        /// Retorna una conexion sql segun el nombre de la llave de base de datos
        /// </summary>
        /// <param name="keyConnections"></param>
        /// <returns></returns>
        private SqlConnection GetSqlConnection(string keyConnections)
        {
            return new SqlConnection(keyConnections.ReadConnections());
        }

        /// <summary>
        /// Cierra la conexion actual
        /// </summary>
        public void Close()
        {
            try
            {
                if (_dataBase != null && _dataBase.State != ConnectionState.Closed)
                    _dataBase.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Abre la conexion actual
        /// </summary>
        public void Open()
        {
            try
            {
                if (_dataBase != null && _dataBase.State != ConnectionState.Open)
                    _dataBase.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el valor del id del objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public TValue GetIdValue<T, TValue>(T model)
        {
            try
            {
                PropertyInfo[] props = typeof(T).GetProperties();
                PropertyInfo prop = null;
                foreach (PropertyInfo p in props)
                {
                    var customKeyAttribute = p.GetCustomAttributes(false).Where(x => x.GetType().FullName.ToUpper().Contains("KEYATTRIBUTE")).Any();

                    if (customKeyAttribute)
                    {
                        prop = p;
                        break;
                    }
                }

                TValue value = default;
                if (prop != null)
                {
                    var obj = prop.GetValue(model);
                    if (obj is TValue)
                        value = (TValue)obj;
                }
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region [Dispose]

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Close();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DataConnections()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    public interface IDataConnections : IDisposable
    {
        /// <summary>
        /// Abre la conexion actual
        /// </summary>
        void Open();

        /// <summary>
        /// Obtiene la conexion actual de base de datos
        /// </summary>
        IDbConnection DataBase { get; }

        /// <summary>
        /// Cierra la conexion actual
        /// </summary>
        void Close();

        /// <summary>
        /// Obtiene el valor del id del objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        TValue GetIdValue<T, TValue>(T model);
    }
}