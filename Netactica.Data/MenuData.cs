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
    /// Repositorio para consultar el menu
    /// </summary>
    public class MenuData : Repository<Menu>, IMenuData, IDisposable
    {
        public MenuData() : base()
        {
        }

        /// <summary>
        /// Consulta un menu por od
        /// </summary>
        /// <param name="menuId">menu por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Menu</returns>
        public Menu ConsultarMenuPorId(int menuId, IDbTransaction transaction = null) 
        {
            try
            {
                var query = ConsultarMenus(new MenuFiltro() { MenuId = menuId }, transaction);
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo menu en la base de datos, verifica que no exista el nombre en la base de datos duplicado
        /// </summary>
        /// <param name="menuId">menu por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Menu</returns>
        public Menu GuardarMenu(Menu menu, IDbTransaction transaction = null)
        {
            try
            {
                menu.FechaCreacion = DateTime.Now;
                menu.FechaModificacion = null;
                menu.UsuarioModifica = null;

                var count = Count("WHERE MenuNombre = @nombre", new { nombre = menu.MenuNombre }, transaction);
                if (count > 0)
                    throw new BusinessException($"Ya existe un menu con este nombre '{menu.MenuNombre}' verifique !!");

                var id = InsertGetKey<int>(menu, transaction);
                menu.MenuId = id;
                return menu;
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
        /// Inserta un nuevo menu en la base de datos, verifica que no exista el nombre en la base de datos duplicado
        /// </summary>
        /// <param name="menuId">menu por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Menu</returns>
        public Menu ModificarMenu(Menu menu, IDbTransaction transaction = null)
        {
            try
            {
                menu.FechaModificacion = DateTime.Now;

                var oldMenu = GetFindById(menu.MenuId, transaction);

                if (oldMenu == null)
                    throw new NotFoundException($"No existe el menu por id {menu.MenuId}");

                var count = Count("WHERE MenuNombre = @nombre AND MenuId <> @id", new { nombre = menu.MenuNombre, id = menu.MenuId }, transaction);
                if (count > 0)
                    throw new BusinessException($"Ya existe un menu con este nombre '{menu.MenuNombre}' verifique !!");

                oldMenu.Estado = menu.Estado;
                oldMenu.FechaModificacion = menu.FechaModificacion;
                oldMenu.MenuClass = menu.MenuClass;
                oldMenu.MenuNombre = menu.MenuNombre;
                oldMenu.MenuOrden = menu.MenuOrden;
                oldMenu.MenuPadreId = menu.MenuPadreId;
                oldMenu.MenuUrl = menu.MenuUrl;
                oldMenu.UsuarioModifica = menu.UsuarioModifica;
                Update(oldMenu, transaction);

                oldMenu = ConsultarMenuPorId(oldMenu.MenuId, transaction);
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
        /// Consulta un listado de menus segun el filtro aplicado
        /// </summary>
        /// <param name="filtro">filtro menu</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Menu</returns>

        public List<Menu> ConsultarMenus(MenuFiltro filtro, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<Menu, Menu, Menu>(sql: "NetacticaDB_SP_MenuConsultar", splitOn: "split", map: (m, MenuPadre) => { m.MenuPadre = MenuPadre; return m; }, param: new
                {
                    filtro.MenuId,
                    filtro.MenuPadreId,
                    filtro.Estado
                }, transaction: transaction, commandType: CommandType.StoredProcedure).ToList();
                return query ?? new List<Menu>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un listado de multiples menus
        /// </summary>
        /// <param name="menusId">listado de menus</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Menu</returns>

        public List<Menu> ConsultarMultiplesMenus(List<int> menusId, IDbTransaction transaction = null)
        {
            try
            {
                var parameterList = menusId.Select(x => new ParametroTVP() { Entero = x }).ToList();
                var dataTable = ParametroTVP.ListParametersToData(parameterList);
                var query = DataBase.Query<Menu, Menu, Menu>(sql: "NetacticaDB_SP_MenuAll", splitOn: "split", map: (m, MenuPadre) => { m.MenuPadre = MenuPadre; return m; }, param: new
                {
                    Lista = dataTable.AsTableValuedParameter("dbo.TVP_Lista")
                }, transaction: transaction, commandType: CommandType.StoredProcedure).ToList();
                return query ?? new List<Menu>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta todo el listado de menus de la base de datos
        /// </summary>
        /// <param name="transaction">transaction sql</param>
        /// <returns>List Menu</returns>
        public List<Menu> ConsultarMenusAll(IDbTransaction transaction = null)
        {
            try
            {
                var query = ConsultarMenus(new MenuFiltro()
                {
                    Estado = null,
                    MenuId = null,
                    MenuPadreId = null
                }, transaction);

                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Repositorio para consultar el menu
    /// </summary>
    public interface IMenuData : IRepository<Menu>, IDisposable
    {
        /// <summary>
        /// Consulta un listado de menus segun el filtro aplicado
        /// </summary>
        /// <param name="filtro">filtro menu</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Menu</returns>
        List<Menu> ConsultarMenus(MenuFiltro filtro, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta todo el listado de menus de la base de datos
        /// </summary>
        /// <param name="transaction">transaction sql</param>
        /// <returns>List Menu</returns>
        List<Menu> ConsultarMenusAll(IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un listado de multiples menus
        /// </summary>
        /// <param name="menusId">listado de menus</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>List Menu</returns>

        List<Menu> ConsultarMultiplesMenus(List<int> menusId, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un menu por od
        /// </summary>
        /// <param name="menuId">menu por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Menu</returns>
        Menu ConsultarMenuPorId(int menuId, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta un nuevo menu en la base de datos, verifica que no exista el nombre en la base de datos duplicado
        /// </summary>
        /// <param name="menuId">menu por id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Menu</returns>
        Menu GuardarMenu(Menu menu, IDbTransaction transaction = null);
    }
}