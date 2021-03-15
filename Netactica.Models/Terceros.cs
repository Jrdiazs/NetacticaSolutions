using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Terceros")]
    public class Terceros
    {
        [Key]
        [Column("TerceroId")]
        public Guid TerceroId { get; set; }

        [Column("TipoIdentificacionId")]
        public int? TipoIdentificacionId { get; set; }

        [Column("TipoTerceroId")]
        public int TipoTerceroId { get; set; }

        [Column("Documento")]
        public string Documento { get; set; }

        [Column("RazonSocial")]
        public string RazonSocial { get; set; }

        [Column("NombreComercial")]
        public string NombreComercial { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("FechaModifica")]
        public DateTime? FechaModifica { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [NotMapped]
        public TipoIdentificacion TipoIdentificacion { get; set; }


        [NotMapped]
        public TipoTercero TipoTercero { get; set; }
    }
}
