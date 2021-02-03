using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Reservas")]
    public class Reservas
    {
        [Key]
        [Column("ReservaId")]
        public Guid ReservaId { get; set; }

        [Column("DocumentoIdentidad")]
        public string DocumentoIdentidad { get; set; }

        [Column("TipoIdentificacionId")]
        public int TipoIdentificacionId { get; set; }

        [Column("FechaHoraPickup")]
        public DateTime FechaHoraPickup { get; set; }

        [Column("FechaHoraDropoff")]
        public DateTime FechaHoraDropoff { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("LugarPickup")]
        public string LugarPickup { get; set; }

        [Column("LugarDropoff")]
        public string LugarDropoff { get; set; }

        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Modelo")]
        public string Modelo { get; set; }

        [Column("PrecioPorHora")]
        public decimal PrecioPorHora { get; set; }

        [Column("Nombres")]
        public string Nombres { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [NotMapped]
        public int? TotalHoras { get; set; }

        [NotMapped]
        public decimal? PrecioTotal { get; set; }

        [NotMapped]
        public TipoIdentificacion TipoIdentificacion { get; set; }
    }
}