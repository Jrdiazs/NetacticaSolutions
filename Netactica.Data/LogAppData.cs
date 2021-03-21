using Dapper;
using Netactica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Netactica.Data
{
    /// <summary>
    /// Clase de acceso a datos a la tabla LogApp log de errores
    /// </summary>
    public class LogAppData : Repository<LogApp>, ILogAppData, IDisposable
    {
        /// <summary>
        /// Consulta el listado de registros del log por rango de fecha de creacion, solo consulta el top parametrizado en el valor del parametro
        /// TopDataValue
        /// </summary>
        /// <param name="fechaIni">fecha inicial</param>
        /// <param name="fechaFin"> fecha final</param>
        /// <param name="transaction">trnasccion sql</param>
        /// <returns>List LogApp</returns>
        public List<LogApp> ConsultarLog(DateTime fechaIni, DateTime fechaFin, IDbTransaction transaction = null)
        {
            try
            {
                int? topData = DataCommon.GetParameterValue<int?>("TopDataValue") ?? 200;

                string sql = "SELECT TOP (@top) la.IdLog, la.DateCreate, la.ThreadLog, la.LeveLog, la.Logger, la.MessagLog, la.ExceptionLog  FROM LogApp la " +
                    "WHERE CAST(la.DateCreate AS DATE) BETWEEN CAST(@ini AS DATE) AND CAST(@fin AS DATE) ORDER BY la.DateCreate DESC;";
                var query = DataBase.Query<LogApp>(sql: sql, param: new
                {
                    ini = fechaIni.Date,
                    fin = fechaFin.Date,
                    top = topData
                }, commandType: CommandType.Text, transaction: transaction).ToList();
                return query ?? new List<LogApp>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Clase de acceso a datos a la tabla LogApp log de errores
    /// </summary>
    public interface ILogAppData : IRepository<LogApp>, IDisposable
    {
        /// <summary>
        /// Consulta el listado de registros del log por rango de fecha de creacion, solo consulta el top parametrizado en el valor del parametro
        /// TopDataValue
        /// </summary>
        /// <param name="fechaIni">fecha inicial</param>
        /// <param name="fechaFin"> fecha final</param>
        /// <param name="transaction">trnasccion sql</param>
        /// <returns>List LogApp</returns>
        List<LogApp> ConsultarLog(DateTime fechaIni, DateTime fechaFin, IDbTransaction transaction = null);
    }
}