using Dapper;
using Netactica.Models;
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

        /// <summary>
        /// Obtiene el valor del parametro segun el tipo de valor que se necesite int, long, string, datetime, bool, guid
        /// </summary>
        /// <typeparam name="T">int, long, string, datetime, bool, guid</typeparam>
        /// <param name="keyName">nombre de la llave</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>T value</returns>
        public T GetParameterValue<T>(string keyName, IDbTransaction transaction = null)
        {
            try
            {
                T value = default;
                string sql = "SELECT TOP 1 p.ParametroId, " +
                "p.ParametroLlave, " +
                "p.ParametroDescripcion, " +
                "p.ValorGuid, " +
                "p.ValorEntero, " +
                "p.ValorDateTime, " +
                "p.ValorSrtring, " +
                "p.ValorBingInt, " +
                "p.ValorBoleano " +
                "FROM Parametros p WHERE p.ParametroLlave = @key;";

                var parameter = DataBase.QueryFirst<Parametros>(sql: sql, param: new { key = keyName }, transaction: transaction, commandType: CommandType.Text);

                if (parameter != null)
                {
                    if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                    {
                        value = (T)Convert.ChangeType(parameter.ValorEntero, typeof(T));
                    }
                    if (typeof(T) == typeof(string))
                    {
                        value = (T)Convert.ChangeType(parameter.ValorSrtring, typeof(T));
                    }
                    if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                    {
                        value = (T)Convert.ChangeType(parameter.ValorBingInt, typeof(T));
                    }
                    if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                    {
                        value = (T)Convert.ChangeType(parameter.ValorDateTime, typeof(T));
                    }
                    if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                    {
                        value = (T)Convert.ChangeType(parameter.ValorBoleano, typeof(T));
                    }
                    if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
                    {
                        value = (T)Convert.ChangeType(parameter.ValorGuid, typeof(T));
                    }
                }

                return value;
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

        /// <summary>
        /// Obtiene el valor del parametro segun el tipo de valor que se necesite int, long, string, datetime, bool, guid
        /// </summary>
        /// <typeparam name="T">int, long, string, datetime, bool, guid</typeparam>
        /// <param name="keyName">nombre de la llave</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>T value</returns>
        T GetParameterValue<T>(string keyName, IDbTransaction transaction = null);
    }
}