using Dapper;
using Netactica.Models;
using Netactica.Models.Exceptions;
using System;
using System.Collections.Generic;
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
        /// Guarda un usuario nuevo en base de datos, guarda la informacion complementaria vacia y tambien guarda el rol del usuario invitado temporalmente
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>Usuario</returns>

        public Usuario GuardarUsuario(Usuario usuario)
        {
            IDbConnection connection = null;
            usuario.UsuarioId = usuario.UsuarioId == Guid.Empty ? Guid.NewGuid() : usuario.UsuarioId;

            try
            {
                if (ExisteUsuarioPorId(usuario))
                    throw new BusinessException($"Ya existe un usuario con este id {usuario.UsuarioId}");

                if (ExisteUsuarioPorNombre(usuario, true))
                    throw new BusinessException($"Ya existe un usuario con este nombre {usuario.UsuarioNombre}");

                using (connection = DataBase)
                {
                    connection.Open();
                    using (var trx = connection.BeginTransaction())
                    {
                        try
                        {
                            var parameters = new DynamicParameters();
                            parameters.Add("UsuarioId", usuario.UsuarioId, dbType: DbType.Guid, direction: ParameterDirection.Output);
                            parameters.Add("RolId", dbType: DbType.Guid, direction: ParameterDirection.Output);
                            parameters.Add("UsuarioNombre", usuario.UsuarioNombre);
                            parameters.Add("UsuarioCorreo", usuario.UsuarioCorreo);
                            parameters.Add("UsuarioCrea", usuario.UsuarioCrea);
                            parameters.Add("Pw", usuario.Pw);
                            parameters.Add("LenguajeId", usuario.LenguajeId);

                            connection.Execute("NetacticaDB_SP_Usuario_Insertar", param: parameters, transaction: trx, commandType: CommandType.StoredProcedure);

                            var id = parameters.Get<Guid>("UsuarioId");
                            var rolId = parameters.Get<Guid>("RolId");

                            usuario = ConsultarUsuario(usuarioId: id, transaction: trx);
                            usuario.Pw = null;
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
                    throw new NotFoundException($"No existe el usuario por id {usuario.UsuarioId}");

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
            catch (BusinessException)
            {
                throw;
            }
            catch (NotFoundException)
            {
                throw;
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
                int count = Count("WHERE UsuarioId = @id", new { id = usuario.UsuarioId }, transaction: transaction);

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
        private bool ExisteUsuarioPorNombre(Usuario usuario, bool newUser = false, IDbTransaction transaction = null)
        {
            try
            {
                int count = 0;

                if (newUser)
                {
                    count = Count("WHERE UsuarioNombre = @nombre", new { nombre = usuario.UsuarioNombre }, transaction: transaction);
                    return count > 0;
                }

                if (ExisteUsuarioPorId(usuario, transaction))
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
                    throw new NotFoundException($"No existe el usuario por id {usuario.UsuarioId}");

                oldUser.Pw = usuario.Pw;
                oldUser.FechaModificacion = DateTime.Now;
                oldUser.UsuarioModifica = usuario.UsuarioModifica;
                oldUser.RestauraClave = usuario.RestauraClave;

                Update(oldUser);

                usuario = ConsultarUsuario(usuario.UsuarioId);

                usuario.Pw = null;

                return usuario;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza el lenguaje del usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Usuario</returns>
        public Usuario ModificarLenguaje(Usuario usuario)
        {
            try
            {
                var oldUser = GetFindById(usuario.UsuarioId);
                if (oldUser == null)
                    throw new NotFoundException($"No existe el usuario por id {usuario.UsuarioId}");

                oldUser.LenguajeId = usuario.LenguajeId;
                oldUser.FechaModificacion = DateTime.Now;
                oldUser.UsuarioModifica = usuario.UsuarioModifica;

                Update(oldUser);

                usuario = ConsultarUsuario(usuario.UsuarioId);

                usuario.Pw = null;

                return usuario;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
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
                bool isAdmon = DataCommon.IsRolAdmon(rolId, transaction);
                return isAdmon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el listado de usuarios para un super administrador
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List UsuariosListado</returns>
        public List<UsuariosListado> ConsultarUsuariosConsultaSuperAdmon(UsuarioFiltro filtro, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<UsuariosListado>(sql: "NetacticaDB_SP_UsuariosConsultar_Admon", param: new
                {
                    UsuarioNombre = filtro.NameUser,
                    UsuarioEstadoId = filtro.Estado,
                    Documento = filtro.Identificacion,
                    NombreCompleto = filtro.NombresCompletos,
                    TerceroId = filtro.Tercero,
                    UsuarioId = filtro.Usuario
                }, transaction: transaction, commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<UsuariosListado>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el listado de usuarios para un administrador cliente
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List UsuariosListado</returns>
        public List<UsuariosListado> ConsultarUsuariosConsultaAdmonCliente(UsuarioFiltro filtro, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<UsuariosListado>(sql: "NetacticaDB_SP_UsuariosConsultar_NoAdmon", param: new
                {
                    UsuarioNombre = filtro.NameUser,
                    UsuarioEstadoId = filtro.Estado,
                    Documento = filtro.Identificacion,
                    NombreCompleto = filtro.NombresCompletos,
                    TerceroId = filtro.Tercero,
                    UsuarioId = filtro.Usuario
                }, transaction: transaction, commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<UsuariosListado>();
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
        /// Guarda un usuario nuevo en base de datos, guarda la informacion complementaria vacia y tambien guarda el rol del usuario invitado temporalmente
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

        /// <summary>
        /// Actualiza el lenguaje del usuario
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Usuario</returns>
        Usuario ModificarLenguaje(Usuario usuario);

        /// <summary>
        /// Verifica si un rol es super administrador
        /// </summary>
        /// <param name="rolId">id del rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si es super administrador, false si no</returns>
        bool IsRolAdmon(Guid rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el listado de usuarios para un super administrador
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List UsuariosListado</returns>
        List<UsuariosListado> ConsultarUsuariosConsultaSuperAdmon(UsuarioFiltro filtro, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el listado de usuarios para un administrador cliente
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List UsuariosListado</returns>
        List<UsuariosListado> ConsultarUsuariosConsultaAdmonCliente(UsuarioFiltro filtro, IDbTransaction transaction = null);
    }
}