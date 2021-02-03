using Netactica.Models;
using Netactica.Services;
using Netactica.Tools;
using Netactica.Tools.StringTools;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    [RoutePrefix("api/Reservas")]
    public class ReservasController : ApiController
    {
        private readonly IReservasServices _services;

        public ReservasController(IReservasServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("ConsultarReservaPorId")]
        public IHttpActionResult ConsultarReservaPorId(Guid reservaId)
        {
            try
            {
                var reserva = _services.ConsultarReservaPorId(reservaId);

                return Ok(reserva);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("ConsultarReservaPorFechas")]
        public IHttpActionResult ConsultarReservaPorFechas([FromBody] ReservaFiltro filtro)
        {
            try
            {
                var json = filtro.SerializeObject();
                Logger.Info($"Filtro {json}");
                var reservas = _services.ConsultarReservas(filtro);

                return Ok(reservas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("GuardarReservas")]
        public IHttpActionResult GuardarReservas([FromBody] Reservas reservas)
        {
            try
            {
                reservas = _services.GuardarReserva(reservas);

                return Ok(reservas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("ModificarReserva")]
        public IHttpActionResult ModificarReservas([FromBody] Reservas reservas)
        {
            try
            {
                reservas = _services.ModificarReserva(reservas);

                return Ok(reservas);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}