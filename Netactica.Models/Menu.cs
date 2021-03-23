using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Menu")]

    public class Menu
    {
        [Key]
        [Column("MenuId")]
        public int MenuId { get; set; }

        [Column("MenuNombre")]
        public string MenuNombre { get; set; }

        [Column("MenuPadreId")]
        public int? MenuPadreId { get; set; }

        [Column("MenuUrl")]
        public string MenuUrl { get; set; }

        [Column("MenuClass")]
        public string MenuClass { get; set; }

        [Column("MenuOrden")]
        public int? MenuOrden { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [Column("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [NotMapped]
        public Menu MenuPadre { get; set; }
    }
}
