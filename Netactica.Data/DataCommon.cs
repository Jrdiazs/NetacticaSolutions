using Dapper;
using Netactica.Models;
using System;
using System.Data;
using System.Text;

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
                bool isAdmon = DataBase.ExecuteScalar<bool>(sql: "SELECT DBO.IsAdmonRol(@rol) IsAdmon ", param: new { rol = rolId }, transaction: transaction, commandType: CommandType.Text);
                return isAdmon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el lenguaje de aplicación por defecto
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Id lenguaje default App</returns>
        public int DefaultLanguajeId(IDbTransaction transaction = null) 
        {
            try
            {
                int total = GetParameterValue<int>("DefaultLanguajeId", transaction);
                return total;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el numero de intentos fallidos para bloquear un usuario en la aplicacion
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Numero de intentos fallidos</returns>
        public int NumeroIntentosFallidos(IDbTransaction transaction = null)
        {
            try
            {
                int total = GetParameterValue<int>("TotalNumIntentos", transaction);
                return total;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si un rol es el rol de usuario invitado
        /// </summary>
        /// <param name="rolId">id del rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si es rol invitado, false si no</returns>
        public bool IsRolInvitado(Guid rolId, IDbTransaction transaction = null)
        {
            try
            {
                Guid rolIdInvitado = GetParameterValue<Guid>("RolInvitadoId", transaction);
                bool isRolInvitado = rolId == rolIdInvitado;
                return isRolInvitado;
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

                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT p.ParametroId,");
                sql.AppendLine(@"p.ParametroLlave, ");
                sql.AppendLine(@"p.ParametroDescripcion,");
                sql.AppendLine(@"p.ValorGuid,");
                sql.AppendLine(@"p.ValorEntero,");
                sql.AppendLine(@"p.ValorDateTime,");
                sql.AppendLine(@"p.ValorString,");
                sql.AppendLine(@"p.ValorBingInt,");
                sql.AppendLine(@"p.ValorBoleano,");
                sql.AppendLine(@"p.FechaCreacion,");
                sql.AppendLine(@"p.UsuarioCrea,");
                sql.AppendLine(@"p.UsuarioModifica,");
                sql.AppendLine(@"p.FechaModificacion ");
                sql.AppendLine(@"FROM Parametros p");
                sql.AppendLine(@"WHERE p.ParametroLlave = @key;");

                var parameter = DataBase.QueryFirst<Parametros>(sql: sql.ToString(), param: new { key = keyName }, transaction: transaction, commandType: CommandType.Text);

                if (parameter != null)
                {
                    switch (Type.GetTypeCode(typeof(T)))
                    {
                        case TypeCode.Int32:
                            value = (T)Convert.ChangeType(parameter.ValorEntero, typeof(T));
                            break;

                        case TypeCode.Int64:
                            value = (T)Convert.ChangeType(parameter.ValorBingInt, typeof(T));
                            break;

                        case TypeCode.String:
                            value = (T)Convert.ChangeType(parameter.ValorString, typeof(T));
                            break;

                        case TypeCode.Boolean:
                            value = (T)Convert.ChangeType(parameter.ValorBoleano, typeof(T));
                            break;

                        case TypeCode.DateTime:
                            value = (T)Convert.ChangeType(parameter.ValorDateTime, typeof(T));
                            break;

                        default:

                            if (typeof(T) == typeof(int?))
                                value = (T)Convert.ChangeType(parameter.ValorEntero, typeof(T));
                            else
                            if (typeof(T) == typeof(long?))
                                value = (T)Convert.ChangeType(parameter.ValorBingInt, typeof(T));
                            else
                            if (typeof(T) == typeof(DateTime?))
                                value = (T)Convert.ChangeType(parameter.ValorDateTime, typeof(T));
                            else
                            if (typeof(T) == typeof(bool?))
                                value = (T)Convert.ChangeType(parameter.ValorBoleano, typeof(T));
                            else
                            if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
                                value = (T)Convert.ChangeType(parameter.ValorGuid, typeof(T));

                            break;
                    }
                }

                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el nombre completo del usuario por id
        /// </summary>
        /// <param name="userId">id de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre completo del usuario</returns>
        public string ObtenerNombreCompletoUsuario(Guid userId, IDbTransaction transaction = null)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT DBO.UsuarioNombreCompleto(@id) NombreCompleto;");

                var fullName = DataBase.ExecuteScalar<string>(sql.ToString(), param: new { id = userId }, transaction: transaction);

                return fullName ?? "SIN NOMBRE";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el nombre de usuario por id
        /// </summary>
        /// <param name="userId">id de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre completo del usuario</returns>
        public string ObtenerNombreUsuario(Guid userId, IDbTransaction transaction = null)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT u.UsuarioNombre FROM Usuario u");
                sql.AppendLine(@"WHERE u.UsuarioId = @id;");

                var fullName = DataBase.ExecuteScalar<string>(sql.ToString(), param: new { id = userId }, transaction: transaction);

                return fullName ?? "SIN NOMBRE";
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Consulta el nombre del rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre del rol</returns>
        public string ObtenerNombreRol(Guid rolId, IDbTransaction transaction = null)
        {
            try
            {

                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT r.Descripcion");
                sql.AppendLine(@"FROM Roles r");
                sql.AppendLine(@"WHERE r.RolId = @rolId;");

                var fullName = DataBase.ExecuteScalar<string>(sql.ToString(), param: new { rolId }, transaction: transaction);

                return fullName ?? "SIN ROL";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el nombre tercero por id
        /// </summary>
        /// <param name="terceroId">id tercero</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre del tercero</returns>
        public string ObtenerNombreTercero(Guid terceroId, IDbTransaction transaction = null)
        {
            try
            {

                var sql = new StringBuilder();
                sql.AppendLine(@"SELECT t.NombreComercial");
                sql.AppendLine(@"FROM Terceros t");
                sql.AppendLine(@"WHERE t.TerceroId = @tercero;");


                var fullName = DataBase.ExecuteScalar<string>(sql.ToString(), param: new { tercero = terceroId }, transaction: transaction);

                return fullName ?? "SIN CLIENTE";
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

        /// <summary>
        /// Consulta el nombre completo del usuario por id
        /// </summary>
        /// <param name="id">id de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre completo del usuario</returns>
        string ObtenerNombreCompletoUsuario(Guid id, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el nombre de usuario por id
        /// </summary>
        /// <param name="userId">id de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre completo del usuario</returns>
        string ObtenerNombreUsuario(Guid userId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el nombre del rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre del rol</returns>
        string ObtenerNombreRol(Guid rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el nombre tercero por id
        /// </summary>
        /// <param name="terceroId">id tercero</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>nombre del tercero</returns>
        string ObtenerNombreTercero(Guid terceroId, IDbTransaction transaction = null);

        /// <summary>
        /// Verifica si un rol es el rol de usuario invitado
        /// </summary>
        /// <param name="rolId">id del rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si es rol invitado, false si no</returns>
        bool IsRolInvitado(Guid rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el numero de intentos fallidos para bloquear un usuario en la aplicacion
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Numero de intentos fallidos</returns>
        int NumeroIntentosFallidos(IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene el lenguaje de aplicación por defecto
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Id lenguaje default App</returns>
        int DefaultLanguajeId(IDbTransaction transaction = null);
    }
}