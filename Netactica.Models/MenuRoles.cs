using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("MenuRoles")]
    public class MenuRoles
    {
        [Key]
        [Column("MenuRolId")]
        public int MenuRolId { get; set; }

        [Column("MenuId")]
        public int MenuId { get; set; }

        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("Estado")]
        public bool? Estado { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("FechaModifica")]
        public DateTime? FechaModifica { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [NotMapped]
        public Menu Menu { get; set; }

        [NotMapped]
        public Roles Rol { get; set; }
    }
}