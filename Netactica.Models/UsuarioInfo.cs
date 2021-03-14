using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("UsuarioInfo")]
    public class UsuarioInfo
    {
        [Key]
        [Column("UsuarioId")]
        public Guid UsuarioId { get; set; }

        [Column("TipoIdentificacionId")]
        public int? TipoIdentificacionId { get; set; }

        [Column("Documento")]
        public string Documento { get; set; }

        [Column("Nombres")]
        public string Nombres { get; set; }

        [Column("Apellidos")]
        public string Apellidos { get; set; }

        [Column("CorreoAlternativo")]
        public string CorreoAlternativo { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("FechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [NotMapped]
        public TipoIdentificacion TipoIdentificacion { get; set; }

        [NotMapped]
        public Usuario Usuario { get; set; }

    }
}
