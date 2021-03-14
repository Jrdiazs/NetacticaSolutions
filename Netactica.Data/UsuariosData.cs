using Dapper;
using Netactica.Models;
using Netactica.Models.Exceptions;
using System;
using System.Data;
using System.Linq;

namespace Netactica.Data
{
    /// <summary>
    /// Acceso a datos a la tabla Usuario
    /// </summary>
    public class UsuariosData : Repository<Usuario>, IDisposable, IUsuariosData
    {
        /// <summary>
        /// Acceso a datos a la tabla Usuario
        /// </summary>
        public UsuariosData() : base()
        {
        }

        /// <summary>
        /// Guarda un usuario nuevo en base de datos
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>Usuario</returns>

        public Usuario GuardarUsuario(Usuario usuario)
        {
            IDbConnection connection = null;
            usuario.UsuarioId = usuario.UsuarioId == Guid.Empty ? Guid.NewGuid() : usuario.UsuarioId;
            try
            {

                using (connection = DataBase) 
                {
                    connection.Open();
                    using (var trx = connection.BeginTransaction()) 
                    {
                        try
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("UsuarioId", usuario.UsuarioId, dbType: DbType.Guid, direction: ParameterDirection.Output);
                            parameters.Add("UsuarioNombre", usuario.UsuarioNombre);
                            parameters.Add("UsuarioCorreo", usuario.UsuarioCorreo);
                            parameters.Add("UsuarioCrea", usuario.UsuarioCrea);
                            parameters.Add("Pw", usuario.Pw);
                            parameters.Add("LenguajeId", usuario.LenguajeId);

                            connection.Execute("NetacticaDB_SP_Usuario_Insertar", param: parameters, transaction: trx, commandType: CommandType.StoredProcedure);

                            var id = parameters.Get<Guid>("UsuarioId");

                            usuario = ConsultarUsuario(usuarioId: id, transaction: trx);

                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                if (connection != null)
                    connection.Dispose();
                
            }
        }

        /// <summary>
        /// Modificar un usuario existente en base de datos por id
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Usuario</returns>
        public Usuario ModificarUsuario(Usuario usuario)
        {
            try
            {
                usuario.FechaModificacion = DateTime.Now;

                if (ExisteUsuarioPorNombre(usuario))
                    throw new BusinessException($"Ya existe un usuario con este nombre '{usuario.UsuarioNombre}' verifique !!");

                var oldUser = GetFindById(usuario.UsuarioId);
                if (oldUser == null)
                    throw new BusinessException($"No existe el usuario por id {usuario.UsuarioId}");

                oldUser.UsuarioCorreo = usuario.UsuarioCorreo;
                oldUser.FechaModificacion = usuario.FechaModificacion;
                oldUser.FechaUltimoIngreso = usuario.FechaUltimoIngreso;
                oldUser.LenguajeId = usuario.LenguajeId;
                oldUser.NumItentos = usuario.NumItentos;
                oldUser.UsuarioEstadoId = usuario.UsuarioEstadoId;
                oldUser.UsuarioModifica = usuario.UsuarioModifica;
                oldUser.UsuarioNombre = usuario.UsuarioNombre;

                Update(oldUser);

                usuario = ConsultarUsuario(usuario.UsuarioId);

                usuario.Pw = null;

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un usuairo por id o por nombre de usuario
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <param name="nombreUsuario">nombre de usuario</param>
        /// <returns>Usuario</returns>
        public Usuario ConsultarUsuario(Guid? usuarioId = null, string nombreUsuario = null, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<Usuario, UsuariosEstado, Lenguaje, Usuario>(sql: "NetacticaDB_SP_UsuarioConsultar", map: (u, ue, l) =>
                    { u.UsuariosEstado = ue; u.Lenguaje = l; return u; }, splitOn: "split", param:
                    new
                    {
                        UsuarioId = usuarioId,
                        UsuarioNombre = nombreUsuario
                    }, commandType: CommandType.StoredProcedure, transaction: transaction).ToList();

                if (query.Any())
                    return query.FirstOrDefault();

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe un usuario por de base de datos
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>true si existe, false si no existe</returns>
        private bool ExisteUsuarioPorId(Usuario usuario, IDbTransaction transaction = null)
        {
            try
            {
                int count = Count("WHERE UsuarioId = @id", new { id = usuario.UsuarioId },transaction : transaction);

                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe un usuario por nombre para no duplicarlo en base de datos
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>true si existe, false si no existe</returns>
        private bool ExisteUsuarioPorNombre(Usuario usuario, IDbTransaction transaction = null)
        {
            try
            {
                int count = 0;
                if (ExisteUsuarioPorId(usuario,transaction))
                    count = Count("WHERE UsuarioNombre = @nombre AND UsuarioId <> @id", new { id = usuario.UsuarioId, nombre = usuario.UsuarioNombre }, transaction: transaction);
                else
                    count = Count("WHERE UsuarioNombre = @nombre", new { nombre = usuario.UsuarioNombre }, transaction: transaction);

                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica la contraseña de un usuario por id
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Usuario</returns>
        public Usuario ModificarPassword(Usuario usuario)
        {
            try
            {
                var oldUser = GetFindById(usuario.UsuarioId);
                if (oldUser == null)
                    throw new BusinessException($"No existe el usuario por id {usuario.UsuarioId}");

                oldUser.Pw = usuario.Pw;
                oldUser.FechaModificacion = DateTime.Now;
                oldUser.UsuarioModifica = usuario.UsuarioModifica;
                oldUser.RestauraClave = usuario.RestauraClave;

                Update(oldUser);

                usuario = ConsultarUsuario(usuario.UsuarioId);

                usuario.Pw = null;

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla Usuario
    /// </summary>
    public interface IUsuariosData : IRepository<Usuario>, IDisposable
    {
        /// <summary>
        /// Consulta un usuairo por id o por nombre de usuario
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <param name="nombreUsuario">nombre de usuario</param>
        /// <returns>Usuario</returns>
        Usuario ConsultarUsuario(Guid? usuarioId = null, string nombreUsuario = null, IDbTransaction transaction = null);

        /// <summary>
        /// Guarda un usuario nuevo en base de datos
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>Usuario</returns>
        Usuario GuardarUsuario(Usuario usuario);

        /// <summary>
        /// Modificar un usuario existente en base de datos por id
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Usuario</returns>
        Usuario ModificarUsuario(Usuario usuario);

        /// <summary>
        /// Modifica la contraseña de un usuario por id
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Usuario</returns>
        Usuario ModificarPassword(Usuario usuario);
    }
}