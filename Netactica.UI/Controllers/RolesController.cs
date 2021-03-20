using Netactica.Services;
using Netactica.Services.Request;
using Netactica.Services.Response;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    [RoutePrefix("api/Roles")]
    public class RolesController : ApiController
    {
        private readonly IRolesServices _services;

        public RolesController(IRolesServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Consulta un rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>Roles</returns>
        [HttpGet]
        [Route("ConsultarRolPorId")]
        public IHttpActionResult ConsultarRolPorId(Guid rolId)
        {
            try
            {
                var response = _services.ConsultarRolPorId(rolId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Identifica si el rol es rol administrador
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>Roles</returns>
        [HttpGet]
        [Route("EsRolAdministrador")]
        public IHttpActionResult EsRolAdministrador(Guid rolId)
        {
            try
            {
                var response = _services.EsRolAdministrador(rolId);
                return Ok(response);
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
        /// <returns>List Roles</returns>
        [HttpPost]
        [Route("ConsultarRoles")]
        public IHttpActionResult ConsultarRoles([FromBody] RolesFiltroRequest filtroRequest)
        {
            try
            {
                var response = _services.ConsultarRoles(filtroRequest);
                return Ok(response);
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
        /// <returns>Roles</returns>
        [HttpPost]
        [Route("GuardarRol")]
        public IHttpActionResult GuardarRol([FromBody] RolesResponse rol)
        {
            try
            {
                var response = _services.GuardarRol(rol);
                return Ok(response);
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
        /// <returns>Roles</returns>
        [HttpPut]
        [Route("ModificarRol")]
        public IHttpActionResult ModificarRol([FromBody] RolesResponse rol)
        {
            try
            {
                var response = _services.ModificarRol(rol);
                return Ok(response);
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
        /// <returns>List Roles</returns>
        [HttpGet]
        [Route("ConsultarRolesPorTercero")]
        public IHttpActionResult ConsultarRolesPorTercero(Guid terceroId)
        {
            try
            {
                var response = _services.ConsultarRolesPorTercero(terceroId);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}