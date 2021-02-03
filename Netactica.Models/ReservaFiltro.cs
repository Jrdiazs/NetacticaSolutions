using System;

namespace Netactica.Models
{
    public class ReservaFiltro
    {
        public Guid? ReservaId { get; set; }

        public DateTime? FechaCreacionIni { get; set; }

        public DateTime? FechaCreacionFin { get; set; }
    }
}