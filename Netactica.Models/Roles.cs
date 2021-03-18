using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("TerceroId")]
        public Guid? TerceroId { get; set; }

        [Column("EsSuperAdmon")]
        public bool EsSuperAdmon { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("FechaModifica")]
        public DateTime? FechaModifica { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [NotMapped]
        public Terceros Tercero { get; set; }
    }
}