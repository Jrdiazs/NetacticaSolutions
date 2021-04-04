using AutoMapper;
using Netactica.Data;
using Netactica.Models;
using Netactica.Models.Exceptions;
using Netactica.Services.Request;
using Netactica.Services.Response;
using Netactica.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Netactica.Services
{
    /// <summary>
    /// Clase de servicios para menus
    /// </summary>
    public class MenuServices : BaseServices, IMenuServices, IDisposable
    {
        #region [Propiedades]

        /// <summary>
        /// Repositorio de datos para menus
        /// </summary>
        private readonly IMenuData _data;

        /// <summary>
        /// Repositorio de datos para roles menus
        /// </summary>
        private readonly IMenuRolesData _dataRoles;

        #endregion [Propiedades]

        #region [Constructor]

        /// <summary>
        /// Clase de servicios para menus
        /// </summary>
        /// <param name="data">Repositorio de datos para menus</param>
        /// <param name="dataRoles">Repositorio de datos para roles menus</param>
        public MenuServices(IMenuData data, IMenuRolesData dataRoles)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _dataRoles = dataRoles ?? throw new ArgumentNullException(nameof(dataRoles));
        }

        #endregion [Constructor]

        #region [Roles Menus]

        /// <summary>
        /// Inserta los Roles Menu para un rol en especial de manera masiva
        /// si no existe ningun registro en roles, significa que el usuario deselecciono todos los menus
        /// por lo cual se eliminaran todos los registros para el rol seleccionado,
        /// retorna de los menus que tiene el usuario actual, chequea los menus creados actualmente para el rol actual
        /// </summary>
        /// <param name="request">listado de roles a guardar</param>
        /// <returns></returns>
        public ResponseModel GuardarMenusRoles(RolesMenuSaveRequest request) 
        {
            ResponseModel response = new ResponseModel();
            try
            {
                request.Menus = request.Menus ?? new List<RolesMenuTVPRequest>();
                var roles = Mapper.Map<List<RolesMenuTVPRequest>, List<RolesMenuTVP>>(request.Menus);
                var count = _dataRoles.GuardarMenuRol(roles, request.RolId, request.UserId);
                //Consulta los menus del usuario que inicia sesion
                var menusUsuarioCrea = ConsultarMenuPorRol(request.RolUserId);
                //Consulta los menus que se acaban de crear para el rol
                var menusCreados = _dataRoles.ConsultarMenuRoles(new MenuRolesFiltro() { RolId = request.RolId });

                /// de la plantilla de menus del usuario que crea
                /// checkea los items de los menus creados en la transaccion creada
                foreach (var item in menusUsuarioCrea)
                {
                    if (menusCreados.Any(x => x.MenuId == item.Menu.Id)) 
                    {
                        CheckedMenu(item, menusCreados);
                    }
                }

                response.SuccesCall(menusUsuarioCrea, $"Total de menus creados {count}");
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(MenuServices)}  {nameof(GuardarMenusRoles)}", ex);
                response.Fail(ex, $"Error en => {nameof(GuardarMenusRoles)}");
            }
            return response;
        }

        /// <summary>
        /// Funcion iterativa para checkear los menus de un rol
        /// </summary>
        /// <param name="menu"></param>
        private void CheckedMenu(MenuItem menu,List<MenuRoles> menus) 
        {
            if (menu.Menu == null)
                return;
            menu.Menu.Checked = true;

            if (menu.Childrens.Count > 0)
            {
                foreach (var children in menu.Childrens)
                {
                    CheckedMenu(children, menus);
                }
            }
            else return;

        }

        /// <summary>
        /// Consulta el menu para un rol segun el rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>List MenuItemResponse</returns>
        public ResponseModel ConsultarMenusPorRolId(Guid rolId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                List<MenuItem> menusResponse = ConsultarMenuPorRol(rolId);

                response.SuccesCall(menusResponse, $"Total de menus cargados {menusResponse.Count}");
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(MenuServices)}  {nameof(ConsultarMenusPorRolId)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarMenusPorRolId)}");
            }

            return response;
        }

        /// <summary>
        /// Consulta el listado de menus por rol id
        /// </summary>
        /// <param name="rolId">rol Id</param>
        /// <returns>List MenuItem</returns>

        private List<MenuItem> ConsultarMenuPorRol(Guid rolId)
        {
            try
            {
                var menusResponse = new List<MenuItem>();
                ///Consulta los roles Menus por rol activos
                var rolesMenus = _dataRoles.ConsultarMenuRoles(new MenuRolesFiltro()
                {
                    RolId = rolId,
                    Estado = true
                });

                //verifica si es el rol es super administrador
                bool isAdmon = _dataRoles.DataCommon.IsRolAdmon(rolId);

                //si es super administrador consulta todos los menus
                //si no es super adiministrador solo trae los menus activos
                var menus = new List<Menu>();
                menus = isAdmon ? rolesMenus.Select(x => x.Menu).ToList() :
                    rolesMenus.Select(x => x.Menu).Where(x => x.Estado).ToList();

                //Selecciona los menus de primer nivel que no tienen padre
                var menusParents = menus.Where(x => !x.MenuPadreId.HasValue).ToList();

                foreach (var menuParent in menusParents)
                {
                    MenuItem itemMenu = new MenuItem
                    {
                        Menu = Mapper.Map<Menu, MenuItemResponse>(menuParent)
                    };

                    var childrens = SearchChildrens(itemMenu, menus);
                    if (childrens.Any())
                        itemMenu.Childrens.AddRange(childrens);

                    menusResponse.Add(itemMenu);
                }

                return menusResponse;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// Busca los menus hijos para un menu
        /// </summary>
        /// <param name="menu">menu item</param>
        /// <param name="menus">Listado de menus</param>
        /// <returns></returns>
        private List<MenuItem> SearchChildrens(MenuItem menu, List<Menu> menus)
        {
            try
            {
                var menusChildrens = new List<MenuItem>();
                if (menus.Any(x => x.MenuPadreId == menu.Menu.Id))
                {
                    var menusSearch = menus.Where(x => x.MenuPadreId == menu.Menu.Id).OrderBy(x => x.MenuOrden).ToList();
                    foreach (var menuParent in menusSearch)
                    {
                        MenuItem item = new MenuItem
                        {
                            Menu = Mapper.Map<Menu, MenuItemResponse>(menuParent)
                        };


                        if (menus.Any(x => x.MenuPadreId == menuParent.MenuId))
                        {
                            var childrens = SearchChildrens(item, menus);
                            if (childrens.Any())
                                item.Childrens.AddRange(childrens);
                        }

                        menusChildrens.Add(item);
                    }
                }
                return menusChildrens;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Roles Menus]

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)

                    if (_data != null)
                        _data.Dispose();

                    if (_dataRoles != null)
                        _dataRoles.Dispose();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~MenuServices()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Clase de servicios para menus
    /// </summary>
    public interface IMenuServices : IBaseServices, IDisposable
    {
        #region [Roles Menus]

        /// <summary>
        /// Consulta el menu para un rol segun el rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>List MenuItemResponse</returns>
        ResponseModel ConsultarMenusPorRolId(Guid rolId);

        /// <summary>
        /// Inserta los Roles Menu para un rol en especial de manera masiva
        /// si no existe ningun registro en roles, significa que el usuario deselecciono todos los menus
        /// por lo cual se eliminaran todos los registros para el rol seleccionado,
        /// retorna de los menus que tiene el usuario actual, chequea los menus creados actualmente para el rol actual
        /// </summary>
        /// <param name="request">listado de roles a guardar</param>
        /// <returns>ResponseModel List MenuItemResponse</returns>
        ResponseModel GuardarMenusRoles(RolesMenuSaveRequest request);

        #endregion [Roles Menus]
    }
}