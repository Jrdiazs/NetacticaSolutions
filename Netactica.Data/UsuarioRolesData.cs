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
    /// Clase de acceso a datos a la tabla UsuarioRoles
    /// </summary>
    public class UsuarioRolesData : Repository<UsuarioRoles>, IDisposable, IUsuarioRolesData
    {
        /// <summary>
        /// Clase de acceso a datos a la tabla UsuarioRoles
        /// </summary>
        public UsuarioRolesData() : base()
        {
        }

        /// <summary>
        /// Consulta el usuario rol por id
        /// </summary>
        /// <param name="rolId">id rol usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public UsuarioRoles ConsultarUsuarioRolPorId(Guid rolId, IDbTransaction transaction = null)
        {
            try
            {
                var query = ConsultarUsuarioRol(new UsuariosRolesFiltro() { Id = rolId }, transaction);
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el listado de roles por rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public List<UsuarioRoles> ConsultarUsuarioRolPorRol(Guid rolId, IDbTransaction transaction = null)
        {
            try
            {
                return ConsultarUsuarioRol(new UsuariosRolesFiltro() { Rol = rolId }, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el listado de usuarios roles por id de usuario
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public List<UsuarioRoles> ConsultarUsuarioRolPorUsuario(Guid usuarioId, IDbTransaction transaction = null)
        {
            try
            {
                return ConsultarUsuarioRol(new UsuariosRolesFiltro() { Usuario = usuarioId }, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta los roles de los usuario por tercero id
        /// </summary>
        /// <param name="terceroId">tercero id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public List<UsuarioRoles> ConsultarUsuarioRolPorTercero(Guid terceroId, IDbTransaction transaction = null)
        {
            try
            {
                return ConsultarUsuarioRol(new UsuariosRolesFiltro() { Tercero = terceroId }, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta toda la lista de usuarios segun el filtro
        /// </summary>
        /// <param name="filtro">filtro de usuarios roles</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public List<UsuarioRoles> ConsultarUsuarioRol(UsuariosRolesFiltro filtro, IDbTransaction transaction = null)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", filtro.Id, dbType: DbType.Guid);
                param.Add("@Rol", filtro.Rol, dbType: DbType.Guid);
                param.Add("@Usuario", filtro.Usuario, dbType: DbType.Guid);
                param.Add("@Estado", filtro.Estado, dbType: DbType.Boolean);
                param.Add("@Tercero", filtro.Tercero, dbType: DbType.Guid);

                var query = DataBase.Query<UsuarioRoles, Usuario, Terceros, Roles, UsuarioRoles>(sql: "NetacticaDB_SP_UsuarioRolesConsultar",
                    param: param, map: (ur, u, t, r) => { ur.Usuario = u; ur.Tercero = t; ur.Roles = r; return ur; },
                    splitOn: "split", transaction: transaction, commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<UsuarioRoles>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe un rol por usuario, rol y tercero en el momento de insertar un rol usuario
        /// </summary>
        /// <param name="usuario">rol usuario a validar</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        private bool ExisteRolInsertar(UsuarioRoles usuario, IDbTransaction transaction = null)
        {
            try
            {
                var count = Count("WHERE UsuarioId =@usuario AND RolId = @rol AND TerceroId = @tercero", new
                {
                    usuario = usuario.UsuarioId,
                    rol = usuario.RolId,
                    tercero = usuario.TerceroId
                }, transaction: transaction);

                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe un rol por usuario, rol y tercero en el momento de modificar un rol usuario
        /// </summary>
        /// <param name="usuario">rol usuario a validar</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        private bool ExisteRolModificar(UsuarioRoles usuario, IDbTransaction transaction = null)
        {
            try
            {
                var count = Count("WHERE UsuarioRolId <> @id AND UsuarioId =@usuario AND RolId = @rol AND TerceroId = @tercero", new
                {
                    id = usuario.UsuarioRolId,
                    usuario = usuario.UsuarioId,
                    rol = usuario.RolId,
                    tercero = usuario.TerceroId
                }, transaction: transaction);

                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda un nuevo usuario rol en la base de datos
        /// </summary>
        /// <param name="usuario">nuevo usuario rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>

        public UsuarioRoles GuardarUsuarioRol(UsuarioRoles usuario, IDbTransaction transaction = null)
        {
            try
            {
                usuario.UsuarioRolId = usuario.UsuarioRolId == Guid.Empty ? Guid.NewGuid() : usuario.UsuarioRolId;
                usuario.FechaCreacion = DateTime.Now;

                if (ExisteRolInsertar(usuario, transaction))
                    throw new BusinessException($"Ya existe un usuario rol con estos datos");

                var id = InsertGetKey<Guid>(usuario, transaction);
                usuario.UsuarioRolId = id;

                usuario = ConsultarUsuarioRolPorId(id, transaction);
                return usuario;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica el usuario rol por id
        /// </summary>
        /// <param name="usuario">usuario rol para modificar por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioRoles</returns>
        public UsuarioRoles ModificarUsuarioRol(UsuarioRoles usuario, IDbTransaction transaction = null)
        {
            try
            {
                usuario.FechaModifica = DateTime.Now;

                if (ExisteRolModificar(usuario, transaction))
                    throw new BusinessException($"Ya existe un usuario rol con estos datos");

                var oldRoleUser = GetFindById(usuario.UsuarioRolId);

                if (oldRoleUser == null)
                    throw new NotFoundException($"No existe el rol del usuario por id {usuario.UsuarioRolId}");

                oldRoleUser.Estado = usuario.Estado;
                oldRoleUser.FechaModifica = usuario.FechaModifica;
                oldRoleUser.UsuarioModifica = usuario.UsuarioModifica;

                Update(oldRoleUser, transaction);

                oldRoleUser = ConsultarUsuarioRolPorId(usuario.UsuarioRolId, transaction);
                return oldRoleUser;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina el usuario rol por id
        /// </summary>
        /// <param name="rold">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        public int EliminarUsuarioRol(Guid rold, IDbTransaction transaction = null)
        {
            try
            {
                var delete = Delete(rold, transaction);
                return delete;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Clase de acceso a datos a la tabla UsuarioRoles
    /// </summary>
    public interface IUsuarioRolesData : IRepository<UsuarioRoles>, IDisposable
    {
        /// <summary>
        /// Consulta el listado de roles por rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        List<UsuarioRoles> ConsultarUsuarioRolPorRol(Guid rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta los roles de los usuario por tercero id
        /// </summary>
        /// <param name="terceroId">tercero id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        List<UsuarioRoles> ConsultarUsuarioRolPorTercero(Guid terceroId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta toda la lista de usuarios segun el filtro
        /// </summary>
        /// <param name="filtro">filtro de usuarios roles</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        List<UsuarioRoles> ConsultarUsuarioRol(UsuariosRolesFiltro filtro, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el usuario rol por id
        /// </summary>
        /// <param name="rolId">id rol usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        UsuarioRoles ConsultarUsuarioRolPorId(Guid rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Elimina el usuario rol por id
        /// </summary>
        /// <param name="rold">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        int EliminarUsuarioRol(Guid rold, IDbTransaction transaction = null);

        /// <summary>
        /// Guarda un nuevo usuario rol en la base de datos
        /// </summary>
        /// <param name="usuario">nuevo usuario rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        UsuarioRoles GuardarUsuarioRol(UsuarioRoles usuario, IDbTransaction transaction = null);

        /// <summary>
        /// Modifica el usuario rol por id
        /// </summary>
        /// <param name="usuario">usuario rol para modificar por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioRoles</returns>
        UsuarioRoles ModificarUsuarioRol(UsuarioRoles usuario, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el listado de usuarios roles por id de usuario
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns></returns>
        List<UsuarioRoles> ConsultarUsuarioRolPorUsuario(Guid usuarioId, IDbTransaction transaction = null);
    }
}