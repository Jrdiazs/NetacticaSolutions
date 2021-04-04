using Netactica.Data;
using Netactica.Models;
using Netactica.Models.Exceptions;
using Netactica.Tools;
using System;

namespace Netactica.Services
{
    
    public class ReservasServices : BaseServices, IReservasServices, IDisposable
    
    {
        private readonly IReservasData _data;

        public ReservasServices(IReservasData data)
        {
            _data = data;
        }

        public ResponseModel ConsultarReservaPorId(Guid reservaId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var reserva = _data.ConsultarReservaPorId(reservaId);
                response.SuccesCall(reserva);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                response.Fail(ex, $"Error en => {nameof(ConsultarReservaPorId)}");
                Logger.ErrorFatal($"ReservasServices  {nameof(ConsultarReservaPorId)}", ex);
            }
            return response;
        }

        public ResponseModel ConsultarReservas(ReservaFiltro filtro)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                filtro.ReservaId = null;
                var reservas = _data.ConsultarReservas(filtro);

                response.SuccesCall(reservas);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                response.Fail(ex, $"Error en => {nameof(ConsultarReservas)}");
                Logger.ErrorFatal($"ReservasServices {nameof(ConsultarReservas)}", ex);
            }
            return response;
        }

        public ResponseModel GuardarReserva(Reservas reserva)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (reserva.FechaHoraPickup > reserva.FechaHoraDropoff)
                    throw new Exception($"La fecha de hora de Pickup debe ser menor que la fecha de Dropoff");

                Guid id = reserva.ReservaId;
                id = id == Guid.Empty ? Guid.NewGuid() : id;
                reserva.ReservaId = id;
                reserva.FechaCreacion = DateTime.Now;

                Validator<Reservas, ReservasValidator>(reserva);

                var newid = _data.InsertGetKey<Guid>(reserva);

                reserva = _data.ConsultarReservaPorId(id);

                response.SuccesCall(reserva, "Reserva guardada correctamente");
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                response.Fail(ex, $"Error en => {nameof(GuardarReserva)}");
                Logger.ErrorFatal($"ReservasServices {nameof(GuardarReserva)}", ex);
            }
            return response;
        }

        public ResponseModel ModificarReserva(Reservas reserva)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var reservaOld = _data.GetFindById(reserva.ReservaId);

                if (reservaOld == null)
                    throw new Exception($"No existe la reserva con id {reserva.ReservaId}");

                if (reserva.FechaHoraPickup > reserva.FechaHoraDropoff)
                    throw new Exception($"La fecha de hora de Pickup debe ser menor que la fecha de Dropoff");

                reservaOld.FechaHoraDropoff = reserva.FechaHoraDropoff;
                reservaOld.FechaHoraPickup = reserva.FechaHoraPickup;
                reservaOld.TipoIdentificacionId = reserva.TipoIdentificacionId;
                reservaOld.DocumentoIdentidad = reserva.DocumentoIdentidad;
                reservaOld.Apellidos = reserva.Apellidos;
                reservaOld.Nombres = reserva.Nombres;
                reservaOld.LugarDropoff = reserva.LugarDropoff;
                reservaOld.LugarPickup = reserva.LugarPickup;
                reservaOld.Marca = reserva.Marca;
                reservaOld.Modelo = reserva.Modelo;
                reservaOld.PrecioPorHora = reserva.PrecioPorHora;

                Validator<Reservas, ReservasValidator>(reservaOld);

                _data.Update(reservaOld);

                reservaOld = _data.ConsultarReservaPorId(reserva.ReservaId);

                response.SuccesCall(reservaOld, "Reserva modificada correctamente");
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                response.Fail(ex, $"Error en => {nameof(ModificarReserva)}");
                Logger.ErrorFatal($"ReservasServices {nameof(ModificarReserva)}", ex);
            }
            return response;
        }

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~ReservasServices()
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

    public interface IReservasServices : IBaseServices, IDisposable
    {
        ResponseModel ConsultarReservaPorId(Guid reservaId);

        ResponseModel ConsultarReservas(ReservaFiltro filtro);

        ResponseModel GuardarReserva(Reservas reserva);

        ResponseModel ModificarReserva(Reservas reserva);
    }
}