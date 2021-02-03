using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    /// <summary>
    /// Clase entidad que representa la tabla reservas
    /// </summary>
    [Table("Reservas")]
    public class Reservas
    {
        /// <summary>
        /// Id de la reserva
        /// </summary>
        [Key]
        [Column("ReservaId")]
        public Guid ReservaId { get; set; }

        /// <summary>
        /// Documento de indentidad del tomador
        /// </summary>
        [Column("DocumentoIdentidad")]
        public string DocumentoIdentidad { get; set; }

        /// <summary>
        /// Tipo de identificacion del usuario 1 es cedula de ciudadania
        /// </summary>
        [Column("TipoIdentificacionId")]
        public int TipoIdentificacionId { get; set; }

        /// <summary>
        /// Fecha de recogida del auto
        /// </summary>
        [Column("FechaHoraPickup")]
        public DateTime FechaHoraPickup { get; set; }

        /// <summary>
        /// Fecha de entrega del auto
        /// </summary>

        [Column("FechaHoraDropoff")]
        public DateTime FechaHoraDropoff { get; set; }

        /// <summary>
        /// Fecha de creacion de la reserva
        /// </summary>
        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Lugar de recogida del vehiculo
        /// </summary>
        [Column("LugarPickup")]
        public string LugarPickup { get; set; }

        /// <summary>
        /// Lugar de entrega del vehiculo
        /// </summary>
        [Column("LugarDropoff")]
        public string LugarDropoff { get; set; }

        /// <summary>
        /// marca del carro
        /// </summary>
        [Column("Marca")]
        public string Marca { get; set; }

        /// <summary>
        /// modelo del carro
        /// </summary>
        [Column("Modelo")]
        public string Modelo { get; set; }

        /// <summary>
        /// valor hora de la reserva
        /// </summary>
        [Column("PrecioPorHora")]
        public decimal PrecioPorHora { get; set; }

        /// <summary>
        /// Nombres del tomador
        /// </summary>
        [Column("Nombres")]
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos del tomador
        /// </summary>
        [Column("Apellidos")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Total de horas calculado segun la fecha de recogida
        /// </summary>
        [NotMapped]
        public int? TotalHoras { get; set; }

        /// <summary>
        /// Calculo segun el total de horas de alquiler por el valor de precio hora
        /// </summary>
        [NotMapped]
        public decimal? PrecioTotal { get; set; }

        /// <summary>
        /// Tipo de identificacion del tomador
        /// </summary>
        [NotMapped]
        public TipoIdentificacion TipoIdentificacion { get; set; }
    }
}