using Netactica.Models;
using Netactica.Services;
using Netactica.Tools;
using Netactica.Tools.StringTools;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    /// <summary>
    /// Controlador para las reservas
    /// </summary>
    [RoutePrefix("api/Reservas")]
    public class ReservasController : ApiController
    {
        /// <summary>
        /// Servicio de base de datos
        /// </summary>
        private readonly IReservasServices _services;

        /// <summary>
        /// Constructor de la clase con el objeto de servicio ya previamente instanciado
        /// </summary>
        /// <param name="services"></param>
        public ReservasController(IReservasServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Consulta la reserva por id
        /// </summary>
        /// <param name="reservaId">guid de la reserva</param>
        /// <returns></returns>

        [HttpGet]
        [Route("ConsultarReservaPorId")]
        public IHttpActionResult ConsultarReservaPorId(Guid reservaId)
        {
            try
            {
                var response = _services.ConsultarReservaPorId(reservaId);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la reserva por rango de fecha de creacion
        /// </summary>
        /// <param name="filtro">filtro con rango de fecha de creacion</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ConsultarReservaPorFechas")]
        public IHttpActionResult ConsultarReservaPorFechas([FromBody] ReservaFiltro filtro)
        {
            try
            {
                var json = filtro.SerializeObject();
                Logger.Info($"Filtro {json}");
                var response = _services.ConsultarReservas(filtro);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crear una reserva nueva en base de datos
        /// </summary>
        /// <param name="reservas">reserva</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GuardarReservas")]
        public IHttpActionResult GuardarReservas([FromBody] Reservas reservas)
        {
            try
            {
                var response = _services.GuardarReserva(reservas);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica la reserva por id
        /// </summary>
        /// <param name="reservas">reserva</param>
        /// <returns></returns>

        [HttpPost]
        [Route("ModificarReserva")]
        public IHttpActionResult ModificarReservas([FromBody] Reservas reservas)
        {
            try
            {
                var response = _services.ModificarReserva(reservas);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}