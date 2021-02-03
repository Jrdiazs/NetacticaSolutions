using Netactica.Tools.StringTools;
using System;
using System.Data;
using System.Data.SqlClient;

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
        public IDbConnection DataBase { get; private set; }

        public DataConnections()
        {
            DataBase = GetSqlConnection("DefaultDatabase");
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
                if (DataBase != null && DataBase.State != ConnectionState.Closed)
                    DataBase.Close();
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
                if (DataBase != null && DataBase.State != ConnectionState.Open)
                    DataBase.Open();
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
    }
}