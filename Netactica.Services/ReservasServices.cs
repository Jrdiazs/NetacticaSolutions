using Netactica.Data;
using Netactica.Models;
using Netactica.Tools;
using System;
using System.Collections.Generic;

namespace Netactica.Services
{
    public class ReservasServices : IReservasServices, IDisposable
    {
        private readonly IReservasData _data;

        public ReservasServices(IReservasData data)
        {
            _data = data;
        }

        public Reservas ConsultarReservaPorId(Guid reservaId)
        {
            try
            {
                return _data.ConsultarReservaPorId(reservaId);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("ReservasServices ConsultarReservaPorId", ex);
                throw ex;
            }
        }

        public List<Reservas> ConsultarReservas(ReservaFiltro filtro)
        {
            try
            {
                filtro.ReservaId = null;
                return _data.ConsultarReservas(filtro);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("ReservasServices ConsultarReservas", ex);
                throw ex;
            }
        }

        public Reservas GuardarReserva(Reservas reserva)
        {
            try
            {
                if (reserva.FechaHoraPickup > reserva.FechaHoraDropoff)
                    throw new Exception($"La fecha de hora de Pickup debe ser menor que la fecha de Dropoff");

                Guid id = reserva.ReservaId;

                id = id == Guid.Empty ? Guid.NewGuid() : id;

                reserva.ReservaId = id;
                reserva.FechaCreacion = DateTime.Now;
                var newid = _data.InsertGetKey<Guid>(reserva);

                reserva = _data.ConsultarReservaPorId(id);

                return reserva;
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("ReservasServices GuardarReserva", ex);
                throw ex;
            }
        }

        public Reservas ModificarReserva(Reservas reserva)
        {
            try
            {
                var reservaOld = _data.GetFindById(reserva.ReservaId);

                if (reservaOld == null)
                    throw new Exception($"No existe la reserva con id {reserva.ReservaId}");

                if (reserva.FechaHoraPickup > reserva.FechaHoraDropoff)
                    throw new Exception($"La fecha de hora de Pickup debe ser menor que la fecha de Dropoff");

                reservaOld.FechaHoraDropoff = reserva.FechaHoraDropoff;
                reservaOld.FechaHoraPickup = reserva.FechaHoraPickup;

                reservaOld.LugarDropoff = reserva.LugarDropoff;
                reservaOld.LugarPickup = reserva.LugarPickup;
                reservaOld.Marca = reserva.Marca;
                reserva.Modelo = reserva.Modelo;
                reserva.PrecioPorHora = reserva.PrecioPorHora;

                _data.Update(reservaOld);

                reservaOld = _data.ConsultarReservaPorId(reserva.ReservaId);

                return reservaOld;
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("ReservasServices ModificarReserva", ex);
                throw ex;
            }
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

    public interface IReservasServices : IDisposable
    {
        Reservas ConsultarReservaPorId(Guid reservaId);

        List<Reservas> ConsultarReservas(ReservaFiltro filtro);

        Reservas GuardarReserva(Reservas reserva);

        Reservas ModificarReserva(Reservas reserva);
    }
}