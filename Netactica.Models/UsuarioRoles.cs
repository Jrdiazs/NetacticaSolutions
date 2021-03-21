using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("UsuarioRoles")]
    public class UsuarioRoles
    {
        [Key]
        [Column("UsuarioRolId")]
        public Guid UsuarioRolId { get; set; }

        [Column("UsuarioId")]
        public Guid UsuarioId { get; set; }

        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("TerceroId")]
        public Guid TerceroId { get; set; }

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
        public Usuario Usuario { get; set; }

        [NotMapped]
        public Roles Roles { get; set; }

        [NotMapped]
        public Terceros Tercero { get; set; }
    }
}