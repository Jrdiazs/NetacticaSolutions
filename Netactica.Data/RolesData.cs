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
    /// Acceso a datos Roles
    /// </summary>
    public class RolesData : Repository<Roles>, IRolesData, IDisposable
    {
        /// <summary>
        /// Acceso a datos Roles
        /// </summary>
        public RolesData() : base()
        {
        }

        /// <summary>
        /// Consulta un rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Roles</returns>
        public Roles ConsultarRolPorId(Guid rolId, IDbTransaction transaction = null)
        {
            try
            {
                var query = ConsultarRoles(new RolesFiltro() { RolId = rolId }, transaction);
                var rol = query.FirstOrDefault();

                return rol;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el listado de roles segun el filtro aplicado
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Roles</returns>
        public List<Roles> ConsultarRoles(RolesFiltro filtro, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<Roles, Terceros, Roles>(sql: "NetacticaDB_SP_RolesConsultar", param: new
                {
                    RolId = filtro.RolId,
                    Descripcion = filtro.Descripcion,
                    Estado = filtro.Estado,
                    TerceroId = filtro.TerceroId
                },
                map: (r, t) => { r.Tercero = t; return r; },
                splitOn: "split",
                    transaction: transaction,
                    commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<Roles>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta los roles por Tercero Id
        /// </summary>
        /// <param name="TerceroId">id del tercero</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Roles</returns>
        public List<Roles> ConsultarRolesPorTercero(Guid TerceroId, IDbTransaction transaction = null)
        {
            try
            {
                return ConsultarRoles(new RolesFiltro { TerceroId = TerceroId }, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe el rol por id
        /// </summary>
        /// <param name="roles">rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>verifica si existe el rol por id</returns>
        private bool ExisteRolPorId(Roles roles, IDbTransaction transaction = null)
        {
            try
            {
                int count = 0;
                count = Count("WHERE RolId = @id", new { id = roles.RolId }, transaction);
                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe el rol por id
        /// </summary>
        /// <param name="roles">rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>verifica si existe el rol por id</returns>
        private bool ExisteRolPorNombre(Roles roles, bool newRol = false, IDbTransaction transaction = null)
        {
            try
            {
                int count = 0;

                if (newRol)
                {
                    count = Count("WHERE Descripcion = @nombre", new { nombre = roles.Descripcion }, transaction);
                    return count > 0;
                }

                if (ExisteRolPorId(roles, transaction))
                    count = Count("WHERE RolId <> @id AND Descripcion = @nombre", new { id = roles.RolId, nombre = roles.Descripcion }, transaction);
                else
                    count = Count("WHERE Descripcion = @nombre", new { nombre = roles.Descripcion }, transaction);

                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo rol en base de datos
        /// </summary>
        /// <param name="roles">rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Roles</returns>
        public Roles GuardarRol(Roles roles, IDbTransaction transaction = null)
        {
            try
            {
                roles.RolId = roles.RolId == Guid.Empty ? Guid.NewGuid() : roles.RolId;
                if (ExisteRolPorNombre(roles, true, transaction))
                    throw new BusinessException($"Ya existe un rol con el nombre {roles.Descripcion}, verifique!");

                bool isRolAdmin = IsRolAdmon(roles.RolIdCreate);

                if (!isRolAdmin && roles.EsSuperAdmon)
                    throw new BusinessException($"Solo el rol super administrador puede crear roles con super administrador");

                roles.FechaCreacion = DateTime.Now;
                roles.FechaModifica = null;
                roles.UsuarioModifica = null;

                var id = InsertGetKey<Guid>(roles, transaction);

                roles.RolId = id;

                return roles;
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
        /// Modifica un nuevo rol por id
        /// </summary>
        /// <param name="roles">rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Roles</returns>
        public Roles ModificarRol(Roles roles, IDbTransaction transaction = null)
        {
            try
            {
                roles.FechaModifica = DateTime.Now;

                if (!ExisteRolPorId(roles, transaction))
                    throw new BusinessException($"No existe el rol por id {roles.RolId}, verifique!");

                if (ExisteRolPorNombre(roles, transaction: transaction))
                    throw new BusinessException($"Ya existe un rol con el nombre {roles.Descripcion}, verifique!");

                bool isRolAdmin = IsRolAdmon(roles.RolIdCreate,transaction);

                if (!isRolAdmin && roles.EsSuperAdmon)
                    throw new BusinessException($"Solo el rol super administrador puede crear roles con super administrador");


                var oldRole = GetFindById(roles.RolId,transaction);

                if (oldRole == null)
                    throw new NotFoundException($"No existe rol con id {roles.RolId}");

                oldRole.Descripcion = roles.Descripcion;
                oldRole.EsSuperAdmon = roles.EsSuperAdmon;
                oldRole.Estado = roles.Estado;
                oldRole.FechaModifica = roles.FechaModifica;
                oldRole.TerceroId = roles.TerceroId;
                oldRole.UsuarioModifica = roles.UsuarioModifica;

                Update(oldRole, transaction);

                return oldRole;
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
    }

    /// <summary>
    /// Acceso a datos Roles
    /// </summary>
    public interface IRolesData : IRepository<Roles>, IDisposable
    {
        /// <summary>
        /// Consulta el listado de roles segun el filtro aplicado
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Roles</returns>
        List<Roles> ConsultarRoles(RolesFiltro filtro, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta los roles por Tercero Id
        /// </summary>
        /// <param name="TerceroId">id del tercero</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Roles</returns>
        List<Roles> ConsultarRolesPorTercero(Guid TerceroId, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta un nuevo rol en base de datos
        /// </summary>
        /// <param name="roles">rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Roles</returns>
        Roles GuardarRol(Roles roles, IDbTransaction transaction = null);

        /// <summary>
        /// Modifica un nuevo rol por id
        /// </summary>
        /// <param name="roles">rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Roles</returns>
        Roles ModificarRol(Roles roles, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Roles</returns>
        Roles ConsultarRolPorId(Guid rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Verifica si un rol es super administrador
        /// </summary>
        /// <param name="rolId">id del rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si es super administrador, false si no</returns>
        bool IsRolAdmon(Guid rolId, IDbTransaction transaction = null);
    }
}