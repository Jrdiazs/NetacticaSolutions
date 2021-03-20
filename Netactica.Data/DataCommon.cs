using Dapper;
using System;
using System.Data;

namespace Netactica.Data
{
    /// <summary>
    /// Clase de acceso a datos con metodos comunes
    /// </summary>
    public class DataCommon : DataConnections, IDataCommon, IDisposable
    {
        public DataCommon() : base()
        {
        }

        /// <summary>
        /// Verifica si un rol es super administrador
        /// </summary>
        /// <param name="rolId">id del rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si es super administrador, false si no</returns>
        public bool IsRolAdmon(Guid rolId, IDbTransaction transaction = null)
        {
            try
            {
                bool isAdmon = (bool)DataBase.ExecuteScalar(sql: "SELECT DBO.IsAdmonRol(@rol) IsAdmon ", param: new { rol = rolId }, commandType: CommandType.Text);
                return isAdmon;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Clase de acceso a datos con metodos comunes
    /// </summary>
    public interface IDataCommon : IDataConnections, IDisposable
    {
        /// <summary>
        /// Verifica si un rol es super administrador
        /// </summary>
        /// <param name="rolId">id del rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si es super administrador, false si no</returns>
        bool IsRolAdmon(Guid rolId, IDbTransaction transaction = null);
    }
}