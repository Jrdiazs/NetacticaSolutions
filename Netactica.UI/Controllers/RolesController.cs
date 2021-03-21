using Netactica.Services;
using Netactica.Services.Request;
using Netactica.Services.Response;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    /// <summary>
    /// Controlador para roles
    /// </summary>
    [RoutePrefix("api/Roles")]
    public class RolesController : ApiController
    {
        #region [Propiedades]

        /// <summary>
        /// Acceso a servicios de roles
        /// </summary>
        private readonly IRolesServices _services;

        #endregion [Propiedades]

        #region [Constructor]

        /// <summary>
        /// Controlador para roles
        /// </summary>
        /// <param name="services"></param>
        public RolesController(IRolesServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #endregion [Constructor]

        #region [Roles]

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

        #endregion [Roles]

        #region [Usuarios Roles]

        /// <summary>
        /// Consulta el usuario rol por id
        /// </summary>
        /// <param name="usuarioRolId">id usuario rol</param>
        /// <returns>ResponseModel UsuariosRolesResponse</returns>
        [HttpGet]
        [Route("ConsultarUsuarioRolPorId")]
        public IHttpActionResult ConsultarUsuarioRolPorId(Guid usuarioRolId)
        {
            try
            {
                var response = _services.ConsultarUsuarioRolPorId(usuarioRolId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda un nuevo usuario rol en la base de datos
        /// </summary>
        /// <param name="usuarioRol">UsuariosRolesResponse</param>
        /// <returns>UsuariosRolesResponse</returns>
        [HttpPost]
        [Route("GuardarUsuarioRol")]
        public IHttpActionResult GuardarUsuarioRol([FromBody] UsuarioRolesResponse usuarioRol)
        {
            try
            {
                var response = _services.GuardarUsuarioRol(usuarioRol);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un usuario rol por id en la base de datos
        /// </summary>
        /// <param name="usuarioRol">UsuariosRolesResponse</param>
        /// <returns>UsuariosRolesResponse</returns>
        [HttpPut]
        [Route("ModificarUsuarioRol")]
        public IHttpActionResult ModificarUsuarioRol([FromBody] UsuarioRolesResponse usuarioRol)
        {
            try
            {
                var response = _services.ModificarUsuarioRol(usuarioRol);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // <summary>
        /// Consulta el listado de roles por rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>ResponseModel List UsuarioRolesResponse</returns>
        [HttpGet]
        [Route("ConsultarUsuarioRolPorRol")]
        public IHttpActionResult ConsultarUsuarioRolPorRol(Guid rolId)
        {
            try
            {
                var response = _services.ConsultarUsuarioRolPorRol(rolId);

                return Ok(response);
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
        /// <returns></returns>
        [HttpGet]
        [Route("ConsultarUsuarioRolPorTercero")]
        public IHttpActionResult ConsultarUsuarioRolPorTercero(Guid terceroId)
        {
            try
            {
                var response = _services.ConsultarUsuarioRolPorTercero(terceroId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el listado de roles por usuario id
        /// </summary>
        /// <param name="usuarioId">rol id</param>
        /// <returns>ResponseModel List UsuarioRolesResponse</returns>
        [HttpGet]
        [Route("ConsultarUsuarioRolPorUsuario")]
        public IHttpActionResult ConsultarUsuarioRolPorUsuario(Guid usuarioId)
        {
            try
            {
                var response = _services.ConsultarUsuarioRolPorUsuario(usuarioId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Usuarios Roles]
    }
}