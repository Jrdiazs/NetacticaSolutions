using Netactica.Services;
using Netactica.Services.Request;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    /// <summary>
    /// Controlador para menu
    /// </summary>
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        /// <summary>
        /// Servicio  para menu
        /// </summary>
        private readonly IMenuServices _services;

        /// <summary>
        /// Controlador para menu
        /// </summary>
        /// <param name="services">Servicio  para menu</param>
        public MenuController(IMenuServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Consulta el menu para un rol segun el rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>List MenuItemResponse</returns>
        [HttpGet]
        [Route("ConsultarMenusPorRolId")]
        public IHttpActionResult ConsultarMenusPorRolId(Guid rolId)
        {
            try
            {
                var menus = _services.ConsultarMenusPorRolId(rolId);
                return Ok(menus);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Inserta los Roles Menu para un rol en especial de manera masiva
        /// si no existe ningun registro en roles, significa que el usuario deselecciono todos los menus
        /// por lo cual se eliminaran todos los registros para el rol seleccionado,
        /// retorna de los menus que tiene el usuario actual, chequea los menus creados actualmente para el rol actual
        /// </summary>
        /// <param name="request">listado de roles a guardar</param>
        /// <returns>ResponseModel List MenuItemResponse</returns>
        [HttpPost]
        [Route("GuardarMenusRoles")]
        public IHttpActionResult GuardarMenusRoles([FromBody]RolesMenuSaveRequest request)
        {
            try
            {
                var menus = _services.GuardarMenusRoles(request);
                return Ok(menus);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}