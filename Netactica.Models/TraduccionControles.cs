using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("TraduccionControles")]
    public class TraduccionControles
    {
        [Key]
        [Column("NombreControl")]
        public string NombreControl { get; set; }

        [Column("LenguajeId")]
        public int LenguajeId { get; set; }

        [Column("Texto")]
        public string Texto { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("FechaModifica")]
        public DateTime? FechaModifica { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [NotMapped]
        public Lenguaje Lenguaje { get; set; }
    }
}