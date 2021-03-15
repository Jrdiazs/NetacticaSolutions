using Netactica.Services;
using Netactica.Services.Response;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        #region [Servicios]
        /// <summary>
        /// Servicio de base de datos
        /// </summary>
        private readonly IUsuarioServices _services; 
        #endregion

        #region [Constructor]
        /// <summary>
        /// Constructor de la clase con el objeto de servicio ya previamente instanciado
        /// </summary>
        /// <param name="services"></param>
        public UsuariosController(IUsuarioServices services)
        {
            _services = services;
        } 
        #endregion

        #region [Usuarios]

        /// <summary>
        /// Consulta el usuario por id
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <returns>UsuarioResponse</returns>
        [HttpGet]
        [Route("ConsultarUsuarioPorId")]
        public IHttpActionResult ConsultarUsuarioPorId(Guid usuarioId)
        {
            try
            {
                var response = _services.ConsultarUsuarioPorId(usuarioId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guardar un usuario nuevo en la base de datos
        /// </summary>
        /// <param name="userResponse">UsuarioResponse usuario nuevo a guardar en BD</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPost]
        [Route("GuardarUsuario")]
        public IHttpActionResult GuardarUsuario([FromBody] UsuarioResponse usuarioResponse)
        {
            try
            {
                var response = _services.GuardarUsuario(usuarioResponse);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modificar un usuario existente en base de datos por id
        /// </summary>
        /// <param name="userResponse">UsuarioResponse</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPut]
        [Route("ModificarUsuario")]
        public IHttpActionResult ModificarUsuario([FromBody] UsuarioResponse usuarioResponse)
        {
            try
            {
                var response = _services.ModificarUsuario(usuarioResponse);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica el lenguaje del usuario
        /// </summary>
        /// <param name="userResponse">UsuarioResponse</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPut]
        [Route("ModificarLenguaje")]
        public IHttpActionResult ModificarLenguaje([FromBody] UsuarioResponse usuarioResponse)
        {
            try
            {
                var response = _services.ModificarLenguaje(usuarioResponse);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica la contraseña de un usuario por id de usuario
        /// las contraseñas tienen que coincidir Password y PasswordConfirm
        /// </summary>
        /// <param name="userResponse">UsuarioResponse contraseña a modificar</param>
        /// <returns>UsuarioResponse</returns>
        [HttpPut]
        [Route("ModificarPassword")]
        public IHttpActionResult ModificarPassword([FromBody] UsuarioResponse usuarioResponse)
        {
            try
            {
                var response = _services.ModificarPassword(usuarioResponse);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta el usuario por nombre de usuario
        /// </summary>
        /// <param name="nombreUsuario">nombre de usuario</param>
        /// <returns>UsuarioResponse</returns>
        [HttpGet]
        [Route("ConsultarUsuarioPorNombre")]
        public IHttpActionResult ConsultarUsuarioPorNombre(string nombreUsuario)
        {
            try
            {
                var response = _services.ConsultarUsuarioPorNombre(nombreUsuario);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Usuarios]

        #region [UsuariosInfo]

        /// <summary>
        /// Consulta la informacion complementaria del usuario por id
        /// </summary>
        /// <param name="usuarioId">id del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        [HttpGet]
        [Route("ConsultarUsuarioInfoPorId")]
        public IHttpActionResult ConsultarUsuarioInfoPorId(Guid usuarioId)
        {
            try
            {
                var response = _services.ConsultarUsuarioInfoPorId(usuarioId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta la informacion complementaria si el usuario no la tiena
        /// </summary>
        /// <param name="userResponse">informacion complementaria del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        [HttpPost]
        [Route("GuardarInformacionUsuario")]
        public IHttpActionResult GuardarInformacionUsuario([FromBody] UsuarioInfoResponse usuarioInfoResponse)
        {
            try
            {
                var response = _services.GuardarInformacionUsuario(usuarioInfoResponse);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta la informacion complementaria si el usuario no la tiena
        /// </summary>
        /// <param name="userResponse">informacion complementaria del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        [HttpPut]
        [Route("ModificarInformacionUsuario")]
        public IHttpActionResult ModificarInformacionUsuario([FromBody] UsuarioInfoResponse usuarioInfoResponse)
        {
            try
            {
                var response = _services.ModificarInformacionUsuario(usuarioInfoResponse);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [UsuariosInfo]

        #region [Estados Usuarios]
        /// <summary>
        /// Consulta el listado de estdos de los usuarios
        /// </summary>
        /// <returns>List UsuarioResponse</returns>

        [HttpGet]
        [Route("ConsultarEstadosUsuarios")]
        public IHttpActionResult ConsultarEstadosUsuarios()
        {
            try
            {
                var response = _services.ConsultarEstadosUsuarios();

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion
    }
}