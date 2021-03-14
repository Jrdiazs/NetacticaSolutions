using Netactica.Services;
using Netactica.Services.Response;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        /// <summary>
        /// Servicio de base de datos
        /// </summary>
        private readonly IUsuarioServices _services;

        /// <summary>
        /// Constructor de la clase con el objeto de servicio ya previamente instanciado
        /// </summary>
        /// <param name="services"></param>
        public UsuariosController(IUsuarioServices services)
        {
            _services = services;
        }

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
    }
}