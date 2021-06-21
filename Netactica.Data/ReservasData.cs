using Dapper;
using Netactica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Netactica.Data
{
    /// <summary>
    /// Repository of Reservas
    /// </summary>
    public class ReservasData : Repository<Reservas>, IReservasData, IDisposable
    {
        public ReservasData() : base()
        {
        }

        public Reservas ConsultarReservaPorId(Guid reservaId)
        {
            try
            {
                var query = ConsultarReservas(new ReservaFiltro() { ReservaId = reservaId });

                if (query.Any())
                    return query.FirstOrDefault();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Reservas> ConsultarReservas(ReservaFiltro filtro)
        {
            try
            {
                var query = DataBase.Query<Reservas, TipoIdentificacion, Reservas>(sql: "CompanyDB_SP_ReservasConsultar",
                    param: new
                    {
                        filtro.ReservaId,
                        filtro.FechaCreacionIni,
                        filtro.FechaCreacionFin
                    }, map: (r, ti) => { r.TipoIdentificacion = ti; return r; }, splitOn: "split", commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<Reservas>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Repository of Reservas
    /// </summary>
    public interface IReservasData : IRepository<Reservas>, IDisposable
    {
        List<Reservas> ConsultarReservas(ReservaFiltro filtro);

        Reservas ConsultarReservaPorId(Guid reservaId);
    }
}