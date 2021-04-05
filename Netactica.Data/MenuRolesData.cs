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
    /// Acceso a datos a la tabla MenuRoles
    /// </summary>
    public class MenuRolesData : Repository<MenuRoles>, IMenuRolesData, IDisposable
    {
        /// <summary>
        /// Acceso a datos a la tabla MenuRoles
        /// </summary>
        public MenuRolesData() : base()
        {
        }

        /// <summary>
        /// Consulta un menu rol por id
        /// </summary>
        /// <param name="rolId">id menu rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>MenuRoles</returns>
        public MenuRoles ConsultarMenuRolPorId(int rolId, IDbTransaction transaction = null)
        {
            try
            {
                var query = ConsultarMenuRoles(new MenuRolesFiltro() { MenuRolId = rolId }, transaction);
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta los Roles Menu para un rol en especial de manera masiva
        /// si no existe ningun registro en roles, significa que el usuario deselecciono todos los menus
        /// por lo cual se eliminaran todos los registros para el rol seleccionado
        /// </summary>
        /// <param name="roles">listado de roles</param>
        /// <param name="rolId">rol id</param>
        /// <param name="usuarioId">usuario id</param>
        /// <returns>numero de filas afectadas</returns>
        public int GuardarMenuRol(List<RolesMenuTVP> roles, Guid rolId, Guid? usuarioId)
        {
            IDbConnection connections = null;
            try
            {
                int rowsCount = 0;
                var table = RolesMenuTVP.ListRolesToTable(roles);
                using (connections = DataBase)
                {
                    connections.Open();
                    using (var trx = connections.BeginTransaction())
                    {
                        try
                        {
                            rowsCount = connections.Execute(sql: "NetacticaDB_SP_MenuRoles_Insertar",
                                transaction: trx,
                                commandType: CommandType.StoredProcedure,
                                param: new
                                {
                                    menus = table.AsTableValuedParameter("dbo.TVP_MenuRoles"),
                                    rolId,
                                    Usuario = usuarioId,
                                    Fecha = DateTime.Now
                                });

                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }

                return rowsCount;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connections != null && connections.State == ConnectionState.Open)
                    connections.Close();
            }
        }

        /// <summary>
        /// Inserta los menus de un rol hacia un rol nuevo
        /// </summary>
        /// <param name="menuCopy">menu copy</param>
        /// <returns>numero de filas afectadas</returns>
        public int CopiarMenuRol(MenuRolesCopy menuCopy)
        {
            IDbConnection connections = null;
            try
            {
                int rowsCount = 0;
                using (connections = DataBase)
                {
                    connections.Open();
                    using (var trx = connections.BeginTransaction())
                    {
                        try
                        {
                            rowsCount = connections.Execute(sql: "NetacticaDB_SP_MenuRoles_Copiar",
                                transaction: trx,
                                commandType: CommandType.StoredProcedure,
                                param: new
                                {
                                    rolIdSource = menuCopy.RoldIdSource,
                                    rolIdTarget = menuCopy.RolIdTarget,
                                    UserId = menuCopy.UsuarioId,
                                    DateNow = DateTime.Now
                                });

                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }

                return rowsCount;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connections != null && connections.State == ConnectionState.Open)
                    connections.Close();
            }
        }

        /// <summary>
        /// Consulta un menu rol por id
        /// </summary>
        /// <param name="rolId">id menu rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>MenuRoles</returns>
        public MenuRoles GuardarMenuRol(MenuRoles rolMenu, IDbTransaction transaction = null)
        {
            try
            {
                rolMenu.FechaCreacion = DateTime.Now;
                rolMenu.UsuarioModifica = null;
                rolMenu.FechaModifica = null;

                var count = Count("WHERE MenuId = @menu AND RolId = @rol", new
                {
                    menu = rolMenu.MenuId,
                    rol = rolMenu.RolId
                }, transaction);

                if (count > 0)
                    throw new BusinessException($"Ya existe un menu rol con estos datos verifique !!");

                var id = InsertGetKey<int>(rolMenu, transaction);

                rolMenu.MenuRolId = id;
                return rolMenu;
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
        /// Modifica un rol menu por id
        /// </summary>
        /// <param name="rolId">id menu rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>MenuRoles</returns>
        public MenuRoles ModificarMenuRol(MenuRoles rolMenu, IDbTransaction transaction = null)
        {
            try
            {
                rolMenu.FechaModifica = DateTime.Now;

                var oldMenu = GetFindById(rolMenu.MenuRolId, transaction);
                if (oldMenu == null)
                    throw new NotFoundException($"No existe el rol menu por id {rolMenu.MenuRolId}");

                var count = Count("WHERE MenuId = @menu AND RolId = @rol AND MenuRolId <> @id", new
                {
                    menu = rolMenu.MenuId,
                    rol = rolMenu.RolId,
                    id = rolMenu.MenuRolId
                }, transaction);

                if (count > 0)
                    throw new BusinessException($"Ya existe un menu rol con estos datos verifique !!");

                oldMenu.Estado = rolMenu.Estado;
                oldMenu.FechaModifica = rolMenu.FechaModifica;
                oldMenu.MenuId = rolMenu.MenuId;
                oldMenu.RolId = rolMenu.RolId;
                oldMenu.UsuarioModifica = rolMenu.UsuarioModifica;

                Update(oldMenu, transaction);

                return oldMenu;
            }
            catch (NotFoundException)
            {
                throw;
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
        /// Consulta un listado de Menu Roles segun el filtro
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List MenuRoles</returns>
        public List<MenuRoles> ConsultarMenuRoles(MenuRolesFiltro filtro, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<MenuRoles, Menu, Roles, MenuRoles>(sql: "NetacticaDB_SP_MenuRolesConsultar",
                    map: (mr, m, r) => { mr.Menu = m; mr.Rol = r; return mr; }, param: new
                    {
                        filtro.MenuRolId,
                        filtro.MenuId,
                        filtro.RolId,
                        filtro.Estado
                    }, splitOn: "split", transaction: transaction, commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<MenuRoles>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla MenuRoles
    /// </summary>
    public interface IMenuRolesData : IRepository<MenuRoles>, IDisposable
    {
        /// <summary>
        /// Consulta un listado de Menu Roles segun el filtro
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List MenuRoles</returns>
        List<MenuRoles> ConsultarMenuRoles(MenuRolesFiltro filtro, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un menu rol por id
        /// </summary>
        /// <param name="rolId">id menu rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>MenuRoles</returns>
        MenuRoles ConsultarMenuRolPorId(int rolId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un menu rol por id
        /// </summary>
        /// <param name="rolId">id menu rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>MenuRoles</returns>
        MenuRoles GuardarMenuRol(MenuRoles rolMenu, IDbTransaction transaction = null);

        /// <summary>
        /// Modifica un rol menu por id
        /// </summary>
        /// <param name="rolId">id menu rol</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>MenuRoles</returns>
        MenuRoles ModificarMenuRol(MenuRoles rolMenu, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta los Roles Menu para un rol en especial de manera masiva
        /// si no existe ningun registro en roles, significa que el usuario deselecciono todos los menus
        /// por lo cual se eliminaran todos los registros para el rol seleccionado
        /// </summary>
        /// <param name="roles">listado de roles</param>
        /// <param name="rolId">rol id</param>
        /// <param name="usuarioId">usuario id</param>
        /// <returns>numero de filas afectadas</returns>
        int GuardarMenuRol(List<RolesMenuTVP> roles, Guid rolId, Guid? usuarioId);

        /// <summary>
        /// Inserta los menus de un rol hacia un rol nuevo
        /// </summary>
        /// <param name="menuCopy">menu copy</param>
        /// <returns>numero de filas afectadas</returns>
        int CopiarMenuRol(MenuRolesCopy menuCopy);
    }
}